namespace OraclePerfTest
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.labelIp = new System.Windows.Forms.Label();
			this.textBoxIp = new System.Windows.Forms.TextBox();
			this.labelPort = new System.Windows.Forms.Label();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.labelId = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelDatabase = new System.Windows.Forms.Label();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.labelUserCount = new System.Windows.Forms.Label();
			this.numericUpDownUserCount = new System.Windows.Forms.NumericUpDown();
			this.labelQueryRate = new System.Windows.Forms.Label();
			this.textBoxSendRate = new System.Windows.Forms.TextBox();
			this.labelQueryPerSecond = new System.Windows.Forms.Label();
			this.labelTotalQueryRate = new System.Windows.Forms.Label();
			this.textBoxTotalSendRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelQuery = new System.Windows.Forms.Label();
			this.textBoxQuery = new System.Windows.Forms.TextBox();
			this.labelParameters = new System.Windows.Forms.Label();
			this.textBoxParameters = new System.Windows.Forms.TextBox();
			this.listBoxLogs = new System.Windows.Forms.ListBox();
			this.labelLogs = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserCount)).BeginInit();
			this.SuspendLayout();
			// 
			// labelIp
			// 
			this.labelIp.AutoSize = true;
			this.labelIp.Location = new System.Drawing.Point(62, 69);
			this.labelIp.Name = "labelIp";
			this.labelIp.Size = new System.Drawing.Size(20, 12);
			this.labelIp.TabIndex = 0;
			this.labelIp.Text = "IP:";
			// 
			// textBoxIp
			// 
			this.textBoxIp.Location = new System.Drawing.Point(88, 66);
			this.textBoxIp.Name = "textBoxIp";
			this.textBoxIp.Size = new System.Drawing.Size(100, 21);
			this.textBoxIp.TabIndex = 1;
			this.textBoxIp.Text = "211.171.200.221";
			// 
			// labelPort
			// 
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new System.Drawing.Point(62, 105);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(31, 12);
			this.labelPort.TabIndex = 0;
			this.labelPort.Text = "Port:";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Location = new System.Drawing.Point(99, 102);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(100, 21);
			this.textBoxPort.TabIndex = 1;
			this.textBoxPort.Text = "1521";
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(62, 176);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(20, 12);
			this.labelId.TabIndex = 0;
			this.labelId.Text = "ID:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(62, 199);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(66, 12);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Password:";
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(88, 173);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(100, 21);
			this.textBoxId.TabIndex = 1;
			this.textBoxId.Text = "MANNA";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(134, 199);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(100, 21);
			this.textBoxPassword.TabIndex = 1;
			this.textBoxPassword.Text = "Ekswnr59";
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(62, 139);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(62, 12);
			this.labelDatabase.TabIndex = 0;
			this.labelDatabase.Text = "Database:";
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.Location = new System.Drawing.Point(134, 136);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.Size = new System.Drawing.Size(100, 21);
			this.textBoxDatabase.TabIndex = 1;
			this.textBoxDatabase.Text = "ALADIN";
			// 
			// labelUserCount
			// 
			this.labelUserCount.AutoSize = true;
			this.labelUserCount.Location = new System.Drawing.Point(62, 254);
			this.labelUserCount.Name = "labelUserCount";
			this.labelUserCount.Size = new System.Drawing.Size(72, 12);
			this.labelUserCount.TabIndex = 0;
			this.labelUserCount.Text = "User Count:";
			// 
			// numericUpDownUserCount
			// 
			this.numericUpDownUserCount.Location = new System.Drawing.Point(140, 252);
			this.numericUpDownUserCount.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownUserCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownUserCount.Name = "numericUpDownUserCount";
			this.numericUpDownUserCount.Size = new System.Drawing.Size(94, 21);
			this.numericUpDownUserCount.TabIndex = 2;
			this.numericUpDownUserCount.ThousandsSeparator = true;
			this.numericUpDownUserCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelQueryRate
			// 
			this.labelQueryRate.AutoSize = true;
			this.labelQueryRate.Location = new System.Drawing.Point(62, 290);
			this.labelQueryRate.Name = "labelQueryRate";
			this.labelQueryRate.Size = new System.Drawing.Size(72, 12);
			this.labelQueryRate.TabIndex = 0;
			this.labelQueryRate.Text = "Query Rate:";
			// 
			// textBoxSendRate
			// 
			this.textBoxSendRate.Location = new System.Drawing.Point(140, 287);
			this.textBoxSendRate.Name = "textBoxSendRate";
			this.textBoxSendRate.Size = new System.Drawing.Size(100, 21);
			this.textBoxSendRate.TabIndex = 1;
			this.textBoxSendRate.Text = "1";
			// 
			// labelQueryPerSecond
			// 
			this.labelQueryPerSecond.AutoSize = true;
			this.labelQueryPerSecond.Location = new System.Drawing.Point(246, 290);
			this.labelQueryPerSecond.Name = "labelQueryPerSecond";
			this.labelQueryPerSecond.Size = new System.Drawing.Size(76, 12);
			this.labelQueryPerSecond.TabIndex = 0;
			this.labelQueryPerSecond.Text = "query / sec.";
			// 
			// labelTotalQueryRate
			// 
			this.labelTotalQueryRate.AutoSize = true;
			this.labelTotalQueryRate.Location = new System.Drawing.Point(62, 328);
			this.labelTotalQueryRate.Name = "labelTotalQueryRate";
			this.labelTotalQueryRate.Size = new System.Drawing.Size(104, 12);
			this.labelTotalQueryRate.TabIndex = 0;
			this.labelTotalQueryRate.Text = "Total Query Rate:";
			// 
			// textBoxTotalSendRate
			// 
			this.textBoxTotalSendRate.Location = new System.Drawing.Point(172, 325);
			this.textBoxTotalSendRate.Name = "textBoxTotalSendRate";
			this.textBoxTotalSendRate.ReadOnly = true;
			this.textBoxTotalSendRate.Size = new System.Drawing.Size(100, 21);
			this.textBoxTotalSendRate.TabIndex = 1;
			this.textBoxTotalSendRate.Text = "1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(278, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "query / sec.";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(64, 380);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(145, 380);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 3;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(226, 380);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 3;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// labelQuery
			// 
			this.labelQuery.AutoSize = true;
			this.labelQuery.Location = new System.Drawing.Point(396, 53);
			this.labelQuery.Name = "labelQuery";
			this.labelQuery.Size = new System.Drawing.Size(43, 12);
			this.labelQuery.TabIndex = 0;
			this.labelQuery.Text = "Query:";
			// 
			// textBoxQuery
			// 
			this.textBoxQuery.Location = new System.Drawing.Point(398, 69);
			this.textBoxQuery.Multiline = true;
			this.textBoxQuery.Name = "textBoxQuery";
			this.textBoxQuery.Size = new System.Drawing.Size(359, 223);
			this.textBoxQuery.TabIndex = 4;
			this.textBoxQuery.Text = resources.GetString("textBoxQuery.Text");
			// 
			// labelParameters
			// 
			this.labelParameters.AutoSize = true;
			this.labelParameters.Location = new System.Drawing.Point(396, 314);
			this.labelParameters.Name = "labelParameters";
			this.labelParameters.Size = new System.Drawing.Size(74, 12);
			this.labelParameters.TabIndex = 0;
			this.labelParameters.Text = "Parameters:";
			// 
			// textBoxParameters
			// 
			this.textBoxParameters.Location = new System.Drawing.Point(398, 329);
			this.textBoxParameters.Multiline = true;
			this.textBoxParameters.Name = "textBoxParameters";
			this.textBoxParameters.Size = new System.Drawing.Size(359, 54);
			this.textBoxParameters.TabIndex = 4;
			// 
			// listBoxLogs
			// 
			this.listBoxLogs.FormattingEnabled = true;
			this.listBoxLogs.ItemHeight = 12;
			this.listBoxLogs.Location = new System.Drawing.Point(64, 461);
			this.listBoxLogs.Name = "listBoxLogs";
			this.listBoxLogs.Size = new System.Drawing.Size(693, 88);
			this.listBoxLogs.TabIndex = 5;
			// 
			// labelLogs
			// 
			this.labelLogs.AutoSize = true;
			this.labelLogs.Location = new System.Drawing.Point(62, 446);
			this.labelLogs.Name = "labelLogs";
			this.labelLogs.Size = new System.Drawing.Size(37, 12);
			this.labelLogs.TabIndex = 0;
			this.labelLogs.Text = "Logs:";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.listBoxLogs);
			this.Controls.Add(this.textBoxParameters);
			this.Controls.Add(this.textBoxQuery);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.numericUpDownUserCount);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxDatabase);
			this.Controls.Add(this.textBoxTotalSendRate);
			this.Controls.Add(this.textBoxSendRate);
			this.Controls.Add(this.textBoxId);
			this.Controls.Add(this.textBoxPort);
			this.Controls.Add(this.textBoxIp);
			this.Controls.Add(this.labelDatabase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelQueryPerSecond);
			this.Controls.Add(this.labelLogs);
			this.Controls.Add(this.labelParameters);
			this.Controls.Add(this.labelQuery);
			this.Controls.Add(this.labelTotalQueryRate);
			this.Controls.Add(this.labelQueryRate);
			this.Controls.Add(this.labelUserCount);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelId);
			this.Controls.Add(this.labelPort);
			this.Controls.Add(this.labelIp);
			this.Name = "Main";
			this.Text = "Oracle Performance Test";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelIp;
		private System.Windows.Forms.TextBox textBoxIp;
		private System.Windows.Forms.Label labelPort;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelDatabase;
		private System.Windows.Forms.TextBox textBoxDatabase;
		private System.Windows.Forms.Label labelUserCount;
		private System.Windows.Forms.NumericUpDown numericUpDownUserCount;
		private System.Windows.Forms.Label labelQueryRate;
		private System.Windows.Forms.TextBox textBoxSendRate;
		private System.Windows.Forms.Label labelQueryPerSecond;
		private System.Windows.Forms.Label labelTotalQueryRate;
		private System.Windows.Forms.TextBox textBoxTotalSendRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelQuery;
		private System.Windows.Forms.TextBox textBoxQuery;
		private System.Windows.Forms.Label labelParameters;
		private System.Windows.Forms.TextBox textBoxParameters;
		private System.Windows.Forms.ListBox listBoxLogs;
		private System.Windows.Forms.Label labelLogs;
	}
}

