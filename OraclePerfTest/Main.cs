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
			this.stat = new Statistics();

			this.rand = new Random(RANDOM_SEED);
		}

		private void ButtonCBT_Click(object sender, EventArgs e)
		{
			AddLog("ButtonCBT_Click, started.");

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
							if (GenerateOracleCommand(cmd))
							{
								if (this.radioButtonConnected.Checked)
								{
									using (OracleDataReader reader = cmd.ExecuteReader())
									{
										reader.FetchSize = long.Parse(Config.Default.FetchSize);
										int rows = 0;
										int fields = 0;
										while (reader.Read())
										{
											rows++;
											fields = reader.FieldCount;
										}
										AddLog($"ButtonCBT_Click, OracleDataReader, row count = {rows}, fields = {fields}");
									}
								}
								else
								{
									using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
									{
										DataTable dataTable = new DataTable();
										adapter.Fill(dataTable);
										AddLog($"ButtonCBT_Click, OracleDataAdapter, row count = {dataTable.Rows.Count}, columns = {dataTable.Columns.Count}");
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
			Config.Default.Save();
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

		private bool GenerateOracleCommand(OracleCommand cmd)
		{
			try
			{
				cmd.AddToStatementCache = true;
				cmd.CommandText = Config.Default.Query.Replace("\r\n", "");

				List<string> arquments = Config.Default.QueryArguments.Split('\n').ToList();
				for (int i = 0; i < arquments.Count; i++)
				{
					//
					// TODO: Use correct OracleDbType
					//
					OracleParameter paramPeriod = new OracleParameter();
					paramPeriod.OracleDbType = OracleDbType.Decimal;
					paramPeriod.Value = int.Parse(arquments[i].Trim());
					cmd.Parameters.Add(paramPeriod);
				}
			}
			catch (OracleException ex)
			{
				AddLog($"GenerateOracleCommand, {ex.ToString()}, {ex.Message}");
				return false;
			}
			return true;
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

		private void ReadingJob(MockClient mock, CancellationToken cancellationToken)
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
							if (GenerateOracleCommand(cmd))
							{
								if (this.radioButtonConnected.Checked)
								{
									using (OracleDataReader reader = cmd.ExecuteReader())
									{
										this.stat.AddReadCount();
										reader.FetchSize = long.Parse(Config.Default.FetchSize);
										while (reader.Read() && !cancellationToken.IsCancellationRequested)
										{
											this.stat.AddRowCount();
											this.stat.AddFieldCount(reader.FieldCount);
										}
									}
								}
								else
								{
									using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
									{
										this.stat.AddReadCount();
										DataTable dataTable = new DataTable();
										adapter.Fill(dataTable);
										this.stat.AddRowCount(dataTable.Rows.Count);
										this.stat.AddColumnCount(dataTable.Columns.Count);
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
                    this.stat.AddReadRequestCount();
					mock = this.mocks[randomIndex[i]];
					Task.Factory.StartNew(() => ReadingJob(mock, this.readingCancellationToken));
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
				this.textBoxQuery.Enabled = false;
				this.textBoxArguments.Enabled = false;
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
				this.textBoxQuery.Enabled = true;
				this.textBoxArguments.Enabled = true;
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

		class Statistics
		{
			object lockObject = new object();
			long openCount;
			long readCount;
            long readRequestCount;
			long rowCount;
			long columnCount;
			long fieldCount;
			long errorCount;

			public Statistics()
			{
				Reset();
			}

			public long AddOpenCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.openCount, count);
				}
			}

			public long AddReadCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.readCount, count);
				}
			}

			public long AddReadRequestCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.readRequestCount, count);
				}
			}

			public long AddRowCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.rowCount, count);
				}
			}

			public long AddColumnCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.columnCount, count);
				}
			}

			public long AddFieldCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.fieldCount, count);
				}
			}

			public long AddErrorCount(long count = 1)
			{
				lock (this.lockObject)
				{
					return Interlocked.Add(ref this.errorCount, count);
				}
			}

			public string ReportAndReset()
			{
				StringBuilder sb = new StringBuilder(128);
				lock (this.lockObject)
				{
					sb.AppendFormat($"OpenCnt:{this.openCount,2}, RequestCnt:{this.readRequestCount,3}, ReadCnt:{this.readCount,4}, RowCnt:{this.rowCount,5}, AverageRowCnt:{this.rowCount / Math.Max(1, this.readCount),4}, ErrorCnt:{this.errorCount,2}, ThreadCnt:{Process.GetCurrentProcess().Threads.Count,3}");
					Reset();
				}
				return sb.ToString();
			}

			public void Reset()
			{
				lock (this.lockObject)
				{
					this.openCount = 0;
                    this.readRequestCount = 0;
					this.readCount = 0;
					this.rowCount = 0;
					this.errorCount = 0;
				}
			}
		}
	}
}
