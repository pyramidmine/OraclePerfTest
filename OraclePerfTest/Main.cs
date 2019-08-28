using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using Config = OraclePerfTest.Properties.Settings;

namespace OraclePerfTest
{
	public partial class Main : Form
	{
		static private readonly int MAX_LOG_COUNT = 1024;
		static private readonly int RANDOM_SEED = 8987;
		static private readonly int STAT_REPORT_INTERVAL = 1000;

		List<MockClient> mocks = new List<MockClient>();

		CancellationTokenSource openingCancellation;
		CancellationToken openingCancellationToken = CancellationToken.None;
		CancellationTokenSource readingCancellation;
		CancellationToken readingCancellationToken = CancellationToken.None;

		System.Timers.Timer openingTimer;
		System.Timers.Timer readingTimer;
		System.Windows.Forms.Timer statTimer;
		Statistics stat;
		Random rand;
		List<QuerySetting> querySettings = new List<QuerySetting>();
		List<Tuple<int, int>> weights = new List<Tuple<int, int>>();

		public Main()
		{
			InitializeComponent();

			this.buttonStop.Enabled = false;

			this.openingTimer = new System.Timers.Timer();
			this.openingTimer.Elapsed += OpeningTimerHandler;

			this.readingTimer = new System.Timers.Timer();
			this.readingTimer.Elapsed += ReadingTimerHandler;

			this.statTimer = new System.Windows.Forms.Timer();
			this.statTimer.Interval = STAT_REPORT_INTERVAL;
			this.statTimer.Tick += StatTimerHandler;
			this.stat = new Statistics(this.tabControlQuery.TabCount);

			this.rand = new Random(RANDOM_SEED);
		}

		private void ButtonCBT_Click(object sender, EventArgs e)
		{
			AddLog("ButtonCBT_Click, started.");

			CollectQuerySettings();
			QuerySetting querySetting = GetCurrentQuerySetting();

			try
			{
				string connectionString = GenerateConnectionString(Config.Default.ServerIp, Config.Default.ServerPort, Config.Default.DatabaseName, Config.Default.DatabaseId, Config.Default.DatabasePassword);
				using (OracleConnection conn = new OracleConnection(connectionString))
				{
					conn.Open();
					if (conn.State == ConnectionState.Open)
					{
						AddLog("ButtonCBT_Click, opened.");
						using (OracleCommand cmd = new OracleCommand())
						{
							cmd.Connection = conn;
							if (GenerateOracleCommand(cmd, querySetting.Query, querySetting.Arguments))
							{
								if (querySetting.Connected)
								{
									using (OracleDataReader reader = cmd.ExecuteReader())
									{
										if (querySetting.SelectRead)
										{
											reader.FetchSize = querySetting.FetchSize;
											int rows = 0;
											int fields = 0;
											while (reader.Read())
											{
												rows++;
												fields = reader.FieldCount;
											}
											AddLog($"ButtonCBT_Click, OracleDataReader, row count = {rows}, fields = {fields}");
										}
										else
										{
											AddLog($"ButtonCBT_Click, OracleDataReader, has rows = {reader.HasRows}");
										}
									}
								}
								else
								{
									using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
									{
										if (querySetting.SelectRead)
										{
											DataTable dataTable = new DataTable();
											adapter.Fill(dataTable);
											AddLog($"ButtonCBT_Click, OracleDataAdapter, row count = {dataTable.Rows.Count}, columns = {dataTable.Columns.Count}");
										}
										else
										{
											AddLog($"ButtonCBT_Click, OracleDataAdapter, done.");
										}
									}
								}
							}
						}
					}
					else
					{
						AddLog($"ButtonCBT_Click, open failed, connection state = {conn.State.ToString()}");
					}
				}
			}
			catch (OracleException ex)
			{
				AddLog($"ButtonCBT_Click, OracleException, {ex.Message}");
			}
			catch (Exception ex)
			{
				AddLog($"ButtonCBT_Click, {ex.ToString()}, {ex.Message}");
			}
			finally
			{
				AddLog("ButtonCBT_Click, ended.");
			}
		}

		private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			AddLog("ButtonStart_Click, started.");

			// 
			// Create connections
			//
			try
			{
				string connectionString = GenerateConnectionString(Config.Default.ServerIp, Config.Default.ServerPort, Config.Default.DatabaseName, Config.Default.DatabaseId, Config.Default.DatabasePassword);

				for (int i = 0; i < Config.Default.UserCount; i++)
				{
					var mock = new MockClient(i, new OracleConnection(connectionString));
					this.mocks.Add(mock);
				}
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, create connections, {ex.ToString()}, {ex.Message}");
				this.stat.AddErrorCount();
				ClearConnections();
				return;
			}

			//
			// Open connections periodically
			//
			try
			{
				this.openingCancellation = new CancellationTokenSource();
				this.openingCancellationToken = this.openingCancellation.Token;
				this.openingTimer.Interval = 1000 / double.Parse(Config.Default.OpenRate);
				this.openingTimer.Start();
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, open connections, {ex.ToString()}, {ex.Message}");
				this.stat.AddErrorCount();
				ClearConnections();
				ResetOpeningJob();
				return;
			}

			//
			// Run periodic test process
			//
			try
			{
				CollectQuerySettings();
				{
					StringBuilder sb = new StringBuilder(1024);
					sb.Append(@"ButtonStart_Click, weights:{");
					for (int i = 0; i < this.weights.Count; i++)
					{
						sb.AppendFormat($"{this.weights[i].Item1}:{this.weights[i].Item2}{(i < this.weights.Count - 1 ? "," : "")}");
					}
					sb.Append(@"}");
					AddLog(sb.ToString());
				}
				this.readingCancellation = new CancellationTokenSource();
				this.readingCancellationToken = this.readingCancellation.Token;
				this.readingTimer.Interval = 1000 / double.Parse(Config.Default.QueryRate);
				this.readingTimer.Start();

				this.statTimer.Start();

				AddLog("ButtonStart_Click, job scheduled.");
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, send queries, {ex.ToString()}, {ex.Message}");
				this.stat.AddErrorCount();
				ClearConnections();
				ResetOpeningJob();
				ResetReadingJob();
				return;
			}

			SetButtonState(true);
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			StopJobs();
			this.stat.ReportAndReset();
			AddLog("ButtonStop_Click, stopped.");
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.buttonStart.Enabled == false && this.buttonStop.Enabled == true)
			{
				DialogResult result = MessageBox.Show(
					"테스트가 진행중인 것 같습니다.\n\n그래도 종료하시겠습니까?",
					"종료 확인",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Question);
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}
				else
				{
					StopJobs();
				}
			}

			Config.Default.Save();
		}

		private void NumericUpDownUserCount_TextChanged(object sender, EventArgs e)
		{
			CalculateTotalQueryRate();
		}

		private void TextBoxQueryRate_TextChanged(object sender, EventArgs e)
		{
			CalculateTotalQueryRate();
		}

		private void AddLog(string text)
		{
			if (this.listBoxLogs.InvokeRequired)
			{
				this.listBoxLogs.Invoke(new Action(() => AddLog(text)));
			}
			else
			{
				if (MAX_LOG_COUNT < this.listBoxLogs.Items.Count)
				{
					this.listBoxLogs.Items.RemoveAt(0);
				}
				this.listBoxLogs.Items.Add(text);
				this.listBoxLogs.TopIndex = this.listBoxLogs.Items.Count - 1;
			}
		}

		private void CalculateTotalQueryRate()
		{
			try
			{
				float userCount = (float)this.numericUpDownUserCount.Value;
				float queryRate = float.Parse(this.textBoxQueryRate.Text);
				float totalQueryRate = userCount * queryRate;
				SetTotalQueryRate(totalQueryRate);
			}
			catch (FormatException ex)
			{
				Console.WriteLine($"Main.CalculateTotalQueryRate, {ex.ToString()}, {ex.Message}");
				SetTotalQueryRate(0);
			}
		}

		private void ClearConnections()
		{
			CancellationTokenSource cts = new CancellationTokenSource();
			try
			{
				cts.CancelAfter(3000);
				CancellationToken ct = cts.Token;
				Task.Factory.StartNew(() =>
				{
					bool allClosed = false;
					while (!allClosed && !ct.IsCancellationRequested)
					{
						allClosed = true;
						foreach (var mock in this.mocks)
						{
							if (mock.IsBusy == 1)
							{
								allClosed = false;
							}
							else if (mock.Connection.State == ConnectionState.Open)
							{
								mock.Connection.Close();
								allClosed = false;
							}
						}
					}
				});
			}
			catch (OperationCanceledException ex)
			{
				// Operation cancelled
			}
			catch (Exception ex)
			{
				AddLog($"ClearConnections, {ex.ToString()}, {ex.Message}");
				this.stat.AddErrorCount();
			}
			this.mocks.Clear();
		}

		private string GenerateConnectionString(string serverIp, string serverPort, string databaseName, string databaseId, string databasePassword)
		{
			return $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={serverIp})(PORT={serverPort})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={databaseName})));User ID={databaseId};Password={databasePassword};Connection Timeout=30;Pooling=true;Statement Cache Size=1;";
		}

		private bool GenerateOracleCommand(OracleCommand cmd, string query, string arguments)
		{
			try
			{
				cmd.AddToStatementCache = true;
				cmd.CommandText = query.Replace("\r\n", ""); ;

				List<string> argumentTokens = arguments.Split('\n').ToList();
				for (int i = 0; i < argumentTokens.Count && !string.IsNullOrWhiteSpace(argumentTokens[i]); i++)
				{
					//
					// TODO: Use correct OracleDbType
					//
					OracleParameter param = new OracleParameter($":{i+1}", OracleDbType.Decimal);
					param.Value = int.Parse(argumentTokens[i].Trim());
					cmd.Parameters.Add(param);
				}
			}
			catch (OracleException ex)
			{
				AddLog($"GenerateOracleCommand, {ex.ToString()}, {ex.Message}");
				return false;
			}
			return true;
		}

		private QuerySetting GetCurrentQuerySetting()
		{
			return this.querySettings[this.tabControlQuery.SelectedIndex];
		}

		private QuerySetting GetRandomQuerySetting()
		{
			int randomNumber = this.rand.Next(this.weights.Last().Item2);
			int index = this.weights.Find(x => randomNumber < x.Item2).Item1;
			return this.querySettings[index];
		}

		private void OpeningTimerHandler(object sender, ElapsedEventArgs args)
		{
			var randomIndex = Enumerable.Range(0, this.mocks.Count).OrderBy(x => Guid.NewGuid()).ToList();

			int i = 0;
			while (this.openingCancellationToken != CancellationToken.None
				&& !this.openingCancellationToken.IsCancellationRequested
				&& i < randomIndex.Count)
			{
				MockClient mock = null;
				try
				{
					mock = this.mocks[randomIndex[i]];
					if (CanOpen(mock.Connection.State) && Interlocked.Exchange(ref mock.IsBusy, 1) == 0)
					{
						try
						{
							mock.Connection.Open();
							if (mock.Connection.State == ConnectionState.Open)
							{
								this.stat.AddOpenCount();
							}
						}
						catch (Exception ex)
						{
							AddLog($"OpeningJob, {ex.ToString()}, {ex.Message}");
							this.stat.AddErrorCount();
						}
						finally
						{
							Interlocked.Exchange(ref mock.IsBusy, 0);
						}
					}
				}
				catch (Exception ex)
				{
					AddLog($"OpeningTimerHandler, mock index = {randomIndex[i]}, {ex.ToString()}, {ex.Message}");
					this.stat.AddErrorCount();
				}
				finally
				{
					i++;
				}
			}

			bool CanOpen(ConnectionState state)
			{
				bool result = false;
				switch (state)
				{
					case ConnectionState.Closed:
					case ConnectionState.Broken:
						result = true;
						break;
					default:
						result = false;
						break;
				}
				return result;
			}
		}

		private void ReadingJob(MockClient mock, QuerySetting querySetting, CancellationToken cancellationToken)
		{
			try
			{
				if (CanRead(mock.Connection.State) && Interlocked.Exchange(ref mock.IsBusy, 1) == 0)
				{
					try
					{
						using (OracleCommand cmd = new OracleCommand())
						{
							cmd.Connection = mock.Connection;
							if (GenerateOracleCommand(cmd, querySetting.Query, querySetting.Arguments))
							{
								if (this.radioButtonConnectionModeConnected1.Checked)
								{
									using (OracleDataReader reader = cmd.ExecuteReader())
									{
										this.stat.AddReadCount(querySetting.Index, 1);
										if (this.radioButtonReadingModeSelectRead1.Checked)
										{
											reader.FetchSize = querySetting.FetchSize;
											while (reader.Read() && !cancellationToken.IsCancellationRequested)
											{
												this.stat.AddRowCount(querySetting.Index, 1);
												this.stat.AddBytes(querySetting.Index, reader.RowSize);
											}
										}
									}
								}
								else
								{
									using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
									{
										this.stat.AddReadCount(querySetting.Index, 1);
										if (this.radioButtonReadingModeSelectRead1.Checked)
										{
											DataTable dataTable = new DataTable();
											adapter.Fill(dataTable);
											this.stat.AddRowCount(querySetting.Index, 1);
										}
									}
								}
							}
						}
					}
					finally
					{
						Interlocked.Exchange(ref mock.IsBusy, 0);
					}
				}
			}
			catch (OperationCanceledException ex)
			{
				// Operation cancelled
			}
			catch (Exception ex)
			{
				AddLog($"ReadingJob, mock index = {mock.SerialNumber}, {ex.ToString()}, {ex.Message}");
				this.stat.AddErrorCount();
			}

			bool CanRead(ConnectionState state)
			{
				bool result = false;
				switch (state)
				{
					case ConnectionState.Open:
						result = true;
						break;
					default:
						result = false;
						break;
				}
				return result;
			}
		}

		private void ReadingTimerHandler(object sender, ElapsedEventArgs args)
		{
			var randomIndex = Enumerable.Range(0, this.mocks.Count).OrderBy(x => Guid.NewGuid()).ToList();

			int i = 0;
			while (this.readingCancellationToken != CancellationToken.None 
				&& !this.readingCancellationToken.IsCancellationRequested
				&& i < randomIndex.Count)
			{
				MockClient mock = null;
				try
				{
					QuerySetting querySetting = GetRandomQuerySetting();
					this.stat.AddReadRequestCount(querySetting.Index, 1);
					mock = this.mocks[randomIndex[i]];
					Task.Factory.StartNew(() => ReadingJob(mock, querySetting, this.readingCancellationToken));
				}
				catch (Exception ex)
				{
					AddLog($"OpeningTimerHandler, mock index = {randomIndex[i]}, {ex.ToString()}, {ex.Message}");
					this.stat.AddErrorCount();
				}
				finally
				{
					i++;
				}
			}
		}

		private void ResetOpeningJob()
		{
			this.openingCancellation?.Dispose();
			this.openingCancellation = null;
			this.openingCancellationToken = CancellationToken.None;
			this.openingTimer.Stop();
		}

		private void ResetReadingJob()
		{
			this.readingCancellation?.Dispose();
			this.readingCancellation = null;
			this.readingCancellationToken = CancellationToken.None;
			this.readingTimer.Stop();
		}

		private void SetButtonState(bool running)
		{
			if (running)
			{
				this.buttonStart.Enabled = false;
				this.buttonStop.Enabled = true;         // only Stop button is enabled
				this.textBoxIp.Enabled = false;
				this.textBoxPort.Enabled = false;
				this.textBoxDatabase.Enabled = false;
				this.textBoxId.Enabled = false;
				this.textBoxPassword.Enabled = false;
				this.tabControlQuery.Enabled = false;
			}
			else
			{
				this.buttonStart.Enabled = true;
				this.buttonStop.Enabled = false;        // only Stop button is disabled
				this.textBoxIp.Enabled = true;
				this.textBoxPort.Enabled = true;
				this.textBoxDatabase.Enabled = true;
				this.textBoxId.Enabled = true;
				this.textBoxPassword.Enabled = true;
				this.tabControlQuery.Enabled = true;
			}
		}

		private void CollectQuerySettings()
		{
			this.querySettings.Clear();
			this.weights.Clear();

			int totalWeight = 0;
			for (int i = 0; i < this.tabControlQuery.TabCount; i++)
			{
				QuerySetting querySetting = new QuerySetting();
				{
					TabPage page = this.tabControlQuery.TabPages[i];
					querySetting.Index = i;
					querySetting.UseQuery = (page.Controls[$"checkBoxUseQuery{i+1}"] as CheckBox).Checked;
					querySetting.Query = Config.Default[$"Query{i + 1}"].ToString();
					querySetting.Arguments = Config.Default[$"QueryArguments{i + 1}"].ToString();
					querySetting.FetchSize = long.Parse(Config.Default[$"FetchSize{i + 1}"].ToString());
					querySetting.Weight = int.Parse(Config.Default[$"Weight{i + 1}"].ToString());
					querySetting.Connected = (page.Controls.Find($"radioButtonConnectionModeConnected{i+1}", true)[0] as RadioButton).Checked;
					querySetting.SelectRead = (page.Controls.Find($"radioButtonReadingModeSelectRead{i+1}", true)[0] as RadioButton).Checked;
					this.querySettings.Add(querySetting);
				}

				if (querySetting.UseQuery)
				{
					totalWeight += querySetting.Weight;
					this.weights.Add(new Tuple<int, int>(i, totalWeight));
				}
			}
		}

		private void SetTotalQueryRate(float value)
		{
			if (this.textBoxTotalQueryRate.InvokeRequired)
			{
				this.textBoxTotalQueryRate.Invoke(new Action(() => SetTotalQueryRate(value)));
			}
			else
			{
				this.textBoxTotalQueryRate.Text = string.Format($"{value:F2}");
			}
		}

		private void StatTimerHandler(object sender, EventArgs args)
		{
			AddLog(this.stat.ReportAndReset());
		}

		private void StopJobs()
		{
			try
			{
				this.statTimer.Stop();

				this.readingCancellation.Cancel();
				this.readingTimer.Stop();

				this.openingCancellation.Cancel();
				this.openingTimer.Stop();
			}
			catch (Exception ex)
			{
				AddLog($"StopJobs, {ex.ToString()}, {ex.Message}");
			}

			ResetOpeningJob();
			ResetReadingJob();
			ClearConnections();

			SetButtonState(false);
		}

		class MockClient
		{
			public OracleConnection Connection { get; set; }
			public int IsBusy;
			public int SerialNumber { get; set; }

			public MockClient(int serialNumber, OracleConnection conn = null)
			{
				Connection = conn;
				IsBusy = 0;
				SerialNumber = serialNumber;
			}
		}

		class QuerySetting
		{
			public int Index { get; set; }
			public bool UseQuery { get; set; }
			public string Query { get; set; }
			public string Arguments { get; set; }
			public long FetchSize { get; set; }
			public int Weight { get; set; }
			public bool Connected { get; set; }
			public bool SelectRead { get; set; }
		}

		class Statistics
		{
			object lockObject = new object();
			long openCount;
			long[] readRequests;
			long[] reads;
			long[] rows;
			long[] bytes;
			long errorCount;

			public Statistics(int queryCount)
			{
				this.readRequests = new long[queryCount];
				this.reads = new long[queryCount];
				this.rows = new long[queryCount];
				this.bytes = new long[queryCount];

				Reset();
			}

			public long AddOpenCount(long count = 1)
			{
				return Interlocked.Add(ref this.openCount, count);
			}

			public long AddReadRequestCount(int index, long count)
			{
				return Interlocked.Add(ref this.readRequests[index], count);
			}

			public long AddReadCount(int index, long count)
			{
				return Interlocked.Add(ref this.reads[index], count);
			}


			public long AddRowCount(int index, long count)
			{
				return Interlocked.Add(ref this.rows[index], count);
			}

			public long AddBytes(int index, long count)
			{
				return Interlocked.Add(ref this.bytes[index], count);
			}

			public long AddErrorCount(long count = 1)
			{
				return Interlocked.Add(ref this.errorCount, count);
			}

			public string ReportAndReset()
			{
				StringBuilder sb = new StringBuilder(256);
				{
					sb.AppendFormat($"OC:{Interlocked.Exchange(ref this.openCount, 0)},");
					for (int i = 0; i < this.readRequests.Length; i++)
					{
						long rowCount = Interlocked.Exchange(ref this.rows[i], 0);

						sb.AppendFormat("QR#{0}:{{{1},{2},{3:F0},{4}}},",
							i,
							Interlocked.Exchange(ref this.readRequests[i], 0),
							Interlocked.Exchange(ref this.reads[i], 0),
							rowCount,
							Interlocked.Exchange(ref this.bytes[i], 0) / (double)Math.Max(1, rowCount));
					}
					sb.AppendFormat($",EC:{Interlocked.Exchange(ref this.errorCount, 0)}");
				}
				return sb.ToString();
			}

			public void Reset()
			{
				lock (this.lockObject)
				{
					this.openCount = 0;
					Array.Clear(this.readRequests, 0, this.readRequests.Length);
					Array.Clear(this.reads, 0, this.reads.Length);
					Array.Clear(this.rows, 0, this.rows.Length);
					Array.Clear(this.bytes, 0, this.bytes.Length);
					this.errorCount = 0;
				}
			}
		}
	}
}
