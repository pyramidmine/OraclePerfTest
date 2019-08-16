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
			this.labelIp = new System.Windows.Forms.Label();
			this.labelPort = new System.Windows.Forms.Label();
			this.labelId = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelDatabase = new System.Windows.Forms.Label();
			this.labelUserCount = new System.Windows.Forms.Label();
			this.labelQueryRate = new System.Windows.Forms.Label();
			this.labelQueryPerSecond = new System.Windows.Forms.Label();
			this.labelTotalQueryRate = new System.Windows.Forms.Label();
			this.textBoxTotalQueryRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelQuery = new System.Windows.Forms.Label();
			this.labelArguments = new System.Windows.Forms.Label();
			this.listBoxLogs = new System.Windows.Forms.ListBox();
			this.labelLogs = new System.Windows.Forms.Label();
			this.groupBoxServer = new System.Windows.Forms.GroupBox();
			this.groupBoxStress = new System.Windows.Forms.GroupBox();
			this.groupBoxQuery = new System.Windows.Forms.GroupBox();
			this.textBoxIp = new System.Windows.Forms.TextBox();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.numericUpDownUserCount = new System.Windows.Forms.NumericUpDown();
			this.textBoxQueryRate = new System.Windows.Forms.TextBox();
			this.textBoxArguments = new System.Windows.Forms.TextBox();
			this.textBoxQuery = new System.Windows.Forms.TextBox();
			this.groupBoxServer.SuspendLayout();
			this.groupBoxStress.SuspendLayout();
			this.groupBoxQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserCount)).BeginInit();
			this.SuspendLayout();
			// 
			// labelIp
			// 
			this.labelIp.AutoSize = true;
			this.labelIp.Location = new System.Drawing.Point(6, 23);
			this.labelIp.Name = "labelIp";
			this.labelIp.Size = new System.Drawing.Size(20, 12);
			this.labelIp.TabIndex = 0;
			this.labelIp.Text = "IP:";
			// 
			// labelPort
			// 
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new System.Drawing.Point(6, 50);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(31, 12);
			this.labelPort.TabIndex = 0;
			this.labelPort.Text = "Port:";
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(6, 104);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(20, 12);
			this.labelId.TabIndex = 0;
			this.labelId.Text = "ID:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(6, 131);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(66, 12);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Password:";
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(84, 101);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(168, 21);
			this.textBoxId.TabIndex = 3;
			this.textBoxId.Text = "MANNA";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(84, 128);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(168, 21);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.Text = "Ekswnr59";
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(6, 77);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(62, 12);
			this.labelDatabase.TabIndex = 0;
			this.labelDatabase.Text = "Database:";
			// 
			// labelUserCount
			// 
			this.labelUserCount.AutoSize = true;
			this.labelUserCount.Location = new System.Drawing.Point(6, 22);
			this.labelUserCount.Name = "labelUserCount";
			this.labelUserCount.Size = new System.Drawing.Size(72, 12);
			this.labelUserCount.TabIndex = 0;
			this.labelUserCount.Text = "User Count:";
			// 
			// labelQueryRate
			// 
			this.labelQueryRate.AutoSize = true;
			this.labelQueryRate.Location = new System.Drawing.Point(6, 49);
			this.labelQueryRate.Name = "labelQueryRate";
			this.labelQueryRate.Size = new System.Drawing.Size(72, 12);
			this.labelQueryRate.TabIndex = 0;
			this.labelQueryRate.Text = "Query Rate:";
			// 
			// labelQueryPerSecond
			// 
			this.labelQueryPerSecond.AutoSize = true;
			this.labelQueryPerSecond.Location = new System.Drawing.Point(184, 49);
			this.labelQueryPerSecond.Name = "labelQueryPerSecond";
			this.labelQueryPerSecond.Size = new System.Drawing.Size(76, 12);
			this.labelQueryPerSecond.TabIndex = 0;
			this.labelQueryPerSecond.Text = "query / sec.";
			// 
			// labelTotalQueryRate
			// 
			this.labelTotalQueryRate.AutoSize = true;
			this.labelTotalQueryRate.Location = new System.Drawing.Point(6, 77);
			this.labelTotalQueryRate.Name = "labelTotalQueryRate";
			this.labelTotalQueryRate.Size = new System.Drawing.Size(104, 12);
			this.labelTotalQueryRate.TabIndex = 0;
			this.labelTotalQueryRate.Text = "Total Query Rate:";
			// 
			// textBoxTotalQueryRate
			// 
			this.textBoxTotalQueryRate.Location = new System.Drawing.Point(116, 74);
			this.textBoxTotalQueryRate.Name = "textBoxTotalQueryRate";
			this.textBoxTotalQueryRate.ReadOnly = true;
			this.textBoxTotalQueryRate.Size = new System.Drawing.Size(62, 21);
			this.textBoxTotalQueryRate.TabIndex = 1;
			this.textBoxTotalQueryRate.TabStop = false;
			this.textBoxTotalQueryRate.Text = "1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(184, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "query / sec.";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(12, 526);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(93, 526);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 2;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(697, 526);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 3;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// labelQuery
			// 
			this.labelQuery.AutoSize = true;
			this.labelQuery.Location = new System.Drawing.Point(9, 20);
			this.labelQuery.Name = "labelQuery";
			this.labelQuery.Size = new System.Drawing.Size(43, 12);
			this.labelQuery.TabIndex = 0;
			this.labelQuery.Text = "Query:";
			// 
			// labelArguments
			// 
			this.labelArguments.AutoSize = true;
			this.labelArguments.Location = new System.Drawing.Point(9, 196);
			this.labelArguments.Name = "labelArguments";
			this.labelArguments.Size = new System.Drawing.Size(70, 12);
			this.labelArguments.TabIndex = 0;
			this.labelArguments.Text = "Arguments:";
			// 
			// listBoxLogs
			// 
			this.listBoxLogs.FormattingEnabled = true;
			this.listBoxLogs.ItemHeight = 12;
			this.listBoxLogs.Location = new System.Drawing.Point(12, 308);
			this.listBoxLogs.Name = "listBoxLogs";
			this.listBoxLogs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxLogs.Size = new System.Drawing.Size(760, 208);
			this.listBoxLogs.TabIndex = 0;
			// 
			// labelLogs
			// 
			this.labelLogs.AutoSize = true;
			this.labelLogs.Location = new System.Drawing.Point(12, 293);
			this.labelLogs.Name = "labelLogs";
			this.labelLogs.Size = new System.Drawing.Size(37, 12);
			this.labelLogs.TabIndex = 0;
			this.labelLogs.Text = "Logs:";
			// 
			// groupBoxServer
			// 
			this.groupBoxServer.Controls.Add(this.labelIp);
			this.groupBoxServer.Controls.Add(this.textBoxIp);
			this.groupBoxServer.Controls.Add(this.labelPassword);
			this.groupBoxServer.Controls.Add(this.textBoxPassword);
			this.groupBoxServer.Controls.Add(this.labelId);
			this.groupBoxServer.Controls.Add(this.labelPort);
			this.groupBoxServer.Controls.Add(this.labelDatabase);
			this.groupBoxServer.Controls.Add(this.textBoxDatabase);
			this.groupBoxServer.Controls.Add(this.textBoxPort);
			this.groupBoxServer.Controls.Add(this.textBoxId);
			this.groupBoxServer.Location = new System.Drawing.Point(12, 12);
			this.groupBoxServer.Name = "groupBoxServer";
			this.groupBoxServer.Size = new System.Drawing.Size(267, 164);
			this.groupBoxServer.TabIndex = 6;
			this.groupBoxServer.TabStop = false;
			this.groupBoxServer.Text = "Server";
			// 
			// groupBoxStress
			// 
			this.groupBoxStress.Controls.Add(this.labelUserCount);
			this.groupBoxStress.Controls.Add(this.numericUpDownUserCount);
			this.groupBoxStress.Controls.Add(this.labelQueryRate);
			this.groupBoxStress.Controls.Add(this.textBoxQueryRate);
			this.groupBoxStress.Controls.Add(this.textBoxTotalQueryRate);
			this.groupBoxStress.Controls.Add(this.labelTotalQueryRate);
			this.groupBoxStress.Controls.Add(this.label1);
			this.groupBoxStress.Controls.Add(this.labelQueryPerSecond);
			this.groupBoxStress.Location = new System.Drawing.Point(12, 182);
			this.groupBoxStress.Name = "groupBoxStress";
			this.groupBoxStress.Size = new System.Drawing.Size(267, 108);
			this.groupBoxStress.TabIndex = 7;
			this.groupBoxStress.TabStop = false;
			this.groupBoxStress.Text = "Stress";
			// 
			// groupBoxQuery
			// 
			this.groupBoxQuery.Controls.Add(this.labelQuery);
			this.groupBoxQuery.Controls.Add(this.textBoxArguments);
			this.groupBoxQuery.Controls.Add(this.textBoxQuery);
			this.groupBoxQuery.Controls.Add(this.labelArguments);
			this.groupBoxQuery.Location = new System.Drawing.Point(285, 12);
			this.groupBoxQuery.Name = "groupBoxQuery";
			this.groupBoxQuery.Size = new System.Drawing.Size(487, 278);
			this.groupBoxQuery.TabIndex = 8;
			this.groupBoxQuery.TabStop = false;
			this.groupBoxQuery.Text = "Query";
			// 
			// textBoxIp
			// 
			this.textBoxIp.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "ServerIp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxIp.Location = new System.Drawing.Point(84, 20);
			this.textBoxIp.Name = "textBoxIp";
			this.textBoxIp.Size = new System.Drawing.Size(168, 21);
			this.textBoxIp.TabIndex = 0;
			this.textBoxIp.Text = global::OraclePerfTest.Properties.Settings.Default.ServerIp;
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "DatabaseName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxDatabase.Location = new System.Drawing.Point(84, 74);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.Size = new System.Drawing.Size(168, 21);
			this.textBoxDatabase.TabIndex = 2;
			this.textBoxDatabase.Text = global::OraclePerfTest.Properties.Settings.Default.DatabaseName;
			// 
			// textBoxPort
			// 
			this.textBoxPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "ServerPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxPort.Location = new System.Drawing.Point(84, 47);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(168, 21);
			this.textBoxPort.TabIndex = 1;
			this.textBoxPort.Text = global::OraclePerfTest.Properties.Settings.Default.ServerPort;
			// 
			// numericUpDownUserCount
			// 
			this.numericUpDownUserCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::OraclePerfTest.Properties.Settings.Default, "UserCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.numericUpDownUserCount.Location = new System.Drawing.Point(84, 20);
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
			this.numericUpDownUserCount.TabIndex = 0;
			this.numericUpDownUserCount.ThousandsSeparator = true;
			this.numericUpDownUserCount.Value = global::OraclePerfTest.Properties.Settings.Default.UserCount;
			this.numericUpDownUserCount.TextChanged += new System.EventHandler(this.numericUpDownUserCount_TextChanged);
			// 
			// textBoxQueryRate
			// 
			this.textBoxQueryRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "QueryRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxQueryRate.Location = new System.Drawing.Point(84, 47);
			this.textBoxQueryRate.Name = "textBoxQueryRate";
			this.textBoxQueryRate.Size = new System.Drawing.Size(94, 21);
			this.textBoxQueryRate.TabIndex = 1;
			this.textBoxQueryRate.Text = global::OraclePerfTest.Properties.Settings.Default.QueryRate;
			this.textBoxQueryRate.TextChanged += new System.EventHandler(this.textBoxQueryRate_TextChanged);
			// 
			// textBoxArguments
			// 
			this.textBoxArguments.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "QueryArguments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxArguments.Location = new System.Drawing.Point(9, 211);
			this.textBoxArguments.Multiline = true;
			this.textBoxArguments.Name = "textBoxArguments";
			this.textBoxArguments.Size = new System.Drawing.Size(468, 54);
			this.textBoxArguments.TabIndex = 1;
			this.textBoxArguments.Text = global::OraclePerfTest.Properties.Settings.Default.QueryArguments;
			// 
			// textBoxQuery
			// 
			this.textBoxQuery.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "Query", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxQuery.Location = new System.Drawing.Point(11, 35);
			this.textBoxQuery.Multiline = true;
			this.textBoxQuery.Name = "textBoxQuery";
			this.textBoxQuery.Size = new System.Drawing.Size(466, 150);
			this.textBoxQuery.TabIndex = 0;
			this.textBoxQuery.Text = global::OraclePerfTest.Properties.Settings.Default.Query;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.listBoxLogs);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.labelLogs);
			this.Controls.Add(this.groupBoxServer);
			this.Controls.Add(this.groupBoxStress);
			this.Controls.Add(this.groupBoxQuery);
			this.Name = "Main";
			this.Text = "Oracle Performance Test";
			this.groupBoxServer.ResumeLayout(false);
			this.groupBoxServer.PerformLayout();
			this.groupBoxStress.ResumeLayout(false);
			this.groupBoxStress.PerformLayout();
			this.groupBoxQuery.ResumeLayout(false);
			this.groupBoxQuery.PerformLayout();
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
		private System.Windows.Forms.TextBox textBoxQueryRate;
		private System.Windows.Forms.Label labelQueryPerSecond;
		private System.Windows.Forms.Label labelTotalQueryRate;
		private System.Windows.Forms.TextBox textBoxTotalQueryRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelQuery;
		private System.Windows.Forms.TextBox textBoxQuery;
		private System.Windows.Forms.Label labelArguments;
		private System.Windows.Forms.TextBox textBoxArguments;
		private System.Windows.Forms.ListBox listBoxLogs;
		private System.Windows.Forms.Label labelLogs;
		private System.Windows.Forms.GroupBox groupBoxServer;
		private System.Windows.Forms.GroupBox groupBoxStress;
		private System.Windows.Forms.GroupBox groupBoxQuery;
	}
}

