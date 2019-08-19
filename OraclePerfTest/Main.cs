﻿using System;
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

        private void buttonClose_Click(object sender, EventArgs e)
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

		private void numericUpDownUserCount_TextChanged(object sender, EventArgs e)
		{
			CalculateTotalQueryRate();
		}

		private void textBoxQueryRate_TextChanged(object sender, EventArgs e)
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
