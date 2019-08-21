using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace OraclePerfTest
{
	public partial class Main : Form
	{
		static private readonly int MAX_LOG_COUNT = 1024;
		static private readonly int RANDOM_SEED = 8987;

		List<MockClient> mocks = new List<MockClient>();

		CancellationTokenSource openingCancellation;
		CancellationToken openingCancellationToken = CancellationToken.None;
		CancellationTokenSource readingCancellation;
		CancellationToken readingCancellationToken = CancellationToken.None;

		System.Timers.Timer openingTimer;
		System.Timers.Timer readingTimer;
		string readingQuery;
		Random rand;

		public Main()
		{
			InitializeComponent();

			/*
			string inputQuery = "WHERE TO_DATA('$1')";
			string query = inputQuery.Replace("$1", "20190814173544");
			Console.WriteLine(query);
			*/
			this.buttonStop.Enabled = false;

			this.openingTimer = new System.Timers.Timer();
			this.openingTimer.Elapsed += OpeningTimerHandler;

			this.readingTimer = new System.Timers.Timer();
			this.readingTimer.Elapsed += ReadingTimerHandler;

			this.rand = new Random(RANDOM_SEED);
		}

		private void ButtonCBT_Click(object sender, EventArgs e)
		{
			string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={Properties.Settings.Default.ServerIp})(PORT={Properties.Settings.Default.ServerPort})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={Properties.Settings.Default.DatabaseName})));User ID={Properties.Settings.Default.DatabaseId};Password={Properties.Settings.Default.DatabasePassword};Connection Timeout=30;";

			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				try
				{
					conn.Open();
					if (conn.State == ConnectionState.Open)
					{
						string query = Properties.Settings.Default.Query.Replace("\r\n", "");
						List<string> arquments = Properties.Settings.Default.QueryArguments.Split('\n').ToList();
						for (int i = 0; i < arquments.Count; i++)
						{
							string arg = $"${i + 1}";
							query = query.Replace(arg, arquments[i]);
						}

						if (this.radioButtonConnection.Checked)
						{
							using (OracleCommand cmd = new OracleCommand())
							{
								cmd.Connection = conn;
								cmd.CommandText = query;
								using (OracleDataReader reader = cmd.ExecuteReader())
								{
									while (reader.Read())
									{
										AddLog($"OracleDataReader, field count = {reader.FieldCount}");
									}
								}
							}
						}
						else
						{
							using (OracleDataAdapter adapter = new OracleDataAdapter(query, conn))
							{
								DataTable dataTable = new DataTable();
								adapter.Fill(dataTable);
								AddLog($"OracleDataAdapter, columns = {dataTable.Columns}, rows = {dataTable.Rows}");
							}
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
			}
		}

		private void ButtonClose_Click(object sender, EventArgs e)
        {
			Properties.Settings.Default.Save();
            this.Close();
        }

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			// 
			// Create connections
			//
			try
			{
				string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={Properties.Settings.Default.ServerIp})(PORT={Properties.Settings.Default.ServerPort})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={Properties.Settings.Default.DatabaseName})));User ID={Properties.Settings.Default.DatabaseId};Password={Properties.Settings.Default.DatabasePassword};Connection Timeout=30;";

				for (int i = 0; i < Properties.Settings.Default.UserCount; i++)
				{
					var mock = new MockClient(new OracleConnection(connectionString));
					this.mocks.Add(mock);
				}
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, create connections, {ex.ToString()}, {ex.Message}");
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
				this.openingTimer.Interval = 1000 / double.Parse(Properties.Settings.Default.OpenRate);
				this.openingTimer.Start();
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, open connections, {ex.ToString()}, {ex.Message}");
				ClearConnections();
				ResetOpeningJob();
				return;
			}

			//
			// Run periodic test process
			//
			try
			{
				StringBuilder sb = new StringBuilder(1024);
				sb.Append(Properties.Settings.Default.Query);
				sb.Replace("\r\n", "");
				List<string> arquments = Properties.Settings.Default.QueryArguments.Split('\n').ToList();
				for (int i = 0; i < arquments.Count; i++)
				{
					string arg = $"${i + 1}";
					sb.Replace(arg, arquments[i]);
				}
				this.readingQuery = sb.ToString();

				this.readingCancellation = new CancellationTokenSource();
				this.readingCancellationToken = this.readingCancellation.Token;
				this.readingTimer.Interval = 1000 / double.Parse(Properties.Settings.Default.QueryRate);
				this.readingTimer.Start();
			}
			catch (Exception ex)
			{
				AddLog($"ButtonStart_Click, send queries, {ex.ToString()}, {ex.Message}");
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
			try
			{
				foreach (var mock in this.mocks)
				{
					mock?.Connection?.Dispose();
				}
				this.mocks.Clear();
			}
			catch (Exception ex)
			{
				AddLog($"ClearConnections, {ex.ToString()}, {ex.Message}");
			}
		}

		private void OpeningTimerHandler(object sender, ElapsedEventArgs args)
		{
			var randomIndex = Enumerable.Range(0, this.mocks.Count);

			while (this.openingCancellationToken != CancellationToken.None && !this.openingCancellationToken.IsCancellationRequested)
			{
				MockClient mock = null;
				int mockIndex = -1;
				try
				{
					mockIndex = this.rand.Next(this.mocks.Count);
					mock = this.mocks[mockIndex];
					Task.Factory.StartNew(() =>
					{
						if (CanOpen(mock.Connection.State) && Interlocked.Exchange(ref mock.IsBusy, 1) == 0)
						{
							try
							{
								mock.Connection.Open();
								if (mock.Connection.State == ConnectionState.Open)
								{
									AddLog($"OpeningTimerHandler, mock index = {mockIndex}, connected");
								}
							}
							catch (Exception ex)
							{
								throw ex;
							}
							finally
							{
								Interlocked.Exchange(ref mock.IsBusy, 0);
							}
						}
					}, this.openingCancellationToken);
				}
				catch (Exception ex)
				{
					AddLog($"OpeningTimerHandler, mock index = {mockIndex}, {ex.ToString()}, {ex.Message}");
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

		private void ReadingTimerHandler(object sender, ElapsedEventArgs args)
		{
			while (this.readingCancellationToken != CancellationToken.None && !this.readingCancellationToken.IsCancellationRequested)
			{
				MockClient mock = null;
				int mockIndex = -1;
				try
				{
					mockIndex = this.rand.Next(this.mocks.Count);
					mock = this.mocks[mockIndex];
					Task.Factory.StartNew(() =>
					{
						if (CanRead(mock.Connection.State) && Interlocked.Exchange(ref mock.IsBusy, 1) == 0)
						{
							AddLog($"ReadingTimerHandler, Task, mock index = {mockIndex}");
							try
							{
								if (this.radioButtonConnection.Checked)
								{
									using (OracleCommand cmd = new OracleCommand())
									{
										cmd.Connection = mock.Connection;
										cmd.CommandText = this.readingQuery;
										using (OracleDataReader reader = cmd.ExecuteReader())
										{
											while (reader.Read())
											{
												AddLog($"OracleDataReader, field count = {reader.FieldCount}");
											}
										}
									}
								}
								else
								{
									using (OracleDataAdapter adapter = new OracleDataAdapter(this.readingQuery, mock.Connection))
									{
										DataTable dataTable = new DataTable();
										adapter.Fill(dataTable);
										AddLog($"OracleDataAdapter, columns = {dataTable.Columns}, rows = {dataTable.Rows}");
									}
								}
							}
							catch (Exception)
							{
								throw;
							}
							finally
							{
								Interlocked.Exchange(ref mock.IsBusy, 0);
							}
						}
					}, this.openingCancellationToken);
				}
				catch (Exception ex)
				{
					AddLog($"OpeningTimerHandler, mock index = {mockIndex}, {ex.ToString()}, {ex.Message}");
				}
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

		private void StopJobs()
		{
			try
			{
				this.readingCancellation.Cancel();
				this.readingTimer.Stop();

				this.openingCancellation.Cancel();
				this.openingTimer.Stop();
			}
			catch (Exception ex)
			{
				AddLog($"StopJobs, {ex.ToString()}, {ex.Message}");
			}
			finally
			{
				ResetOpeningJob();
				ResetReadingJob();
				ClearConnections();
				SetButtonState(false);
			}
		}

		class MockClient
		{
			public OracleConnection Connection { get; set; }
			public int IsBusy;

			public MockClient(OracleConnection conn = null)
			{
				Connection = conn;
				IsBusy = 0;
			}
		}
	}
}
