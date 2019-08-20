using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OraclePerfTest
{
	public partial class Main : Form
	{
		static private readonly int MAX_LOG_COUNT = 1024;

		List<OracleConnection> connections = new List<OracleConnection>();

		public Main()
		{
			InitializeComponent();

			/*
			string inputQuery = "WHERE TO_DATA('$1')";
			string query = inputQuery.Replace("$1", "20190814173544");
			Console.WriteLine(query);
			*/
			this.buttonStop.Enabled = false;
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
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;			// only Stop button is enabled
			this.textBoxIp.Enabled = false;
			this.textBoxPort.Enabled = false;
			this.textBoxDatabase.Enabled = false;
			this.textBoxId.Enabled = false;
			this.textBoxPassword.Enabled = false;
			this.textBoxQuery.Enabled = false;
			this.textBoxArguments.Enabled = false;


		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			this.buttonStart.Enabled = true;
			this.buttonStop.Enabled = false;		// only Stop button is disabled
			this.textBoxIp.Enabled = true;
			this.textBoxPort.Enabled = true;
			this.textBoxDatabase.Enabled = true;
			this.textBoxId.Enabled = true;
			this.textBoxPassword.Enabled = true;
			this.textBoxQuery.Enabled = true;
			this.textBoxArguments.Enabled = true;
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
					// TODO: Stop testing
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
	}
}
