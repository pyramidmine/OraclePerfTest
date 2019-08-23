﻿namespace OraclePerfTest
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
			this.textBoxIp = new System.Windows.Forms.TextBox();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.groupBoxStress = new System.Windows.Forms.GroupBox();
			this.numericUpDownUserCount = new System.Windows.Forms.NumericUpDown();
			this.labelOpenRate = new System.Windows.Forms.Label();
			this.textBoxOpenRate = new System.Windows.Forms.TextBox();
			this.textBoxQueryRate = new System.Windows.Forms.TextBox();
			this.labelRequestPerSecond = new System.Windows.Forms.Label();
			this.groupBoxQuery = new System.Windows.Forms.GroupBox();
			this.groupBoxReadingMode = new System.Windows.Forms.GroupBox();
			this.radioButtonReadingModeSelect = new System.Windows.Forms.RadioButton();
			this.radioButtonReadingModeSelectRead = new System.Windows.Forms.RadioButton();
			this.groupBoxConnectionMode = new System.Windows.Forms.GroupBox();
			this.radioButtonDisconnected = new System.Windows.Forms.RadioButton();
			this.radioButtonConnected = new System.Windows.Forms.RadioButton();
			this.textBoxFetchSize = new System.Windows.Forms.TextBox();
			this.textBoxArguments = new System.Windows.Forms.TextBox();
			this.textBoxQuery = new System.Windows.Forms.TextBox();
			this.labelFetchSize = new System.Windows.Forms.Label();
			this.buttonCBT = new System.Windows.Forms.Button();
			this.groupBoxServer.SuspendLayout();
			this.groupBoxStress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserCount)).BeginInit();
			this.groupBoxQuery.SuspendLayout();
			this.groupBoxReadingMode.SuspendLayout();
			this.groupBoxConnectionMode.SuspendLayout();
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
			this.buttonStart.Location = new System.Drawing.Point(11, 559);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(92, 559);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(696, 559);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
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
			this.labelArguments.Location = new System.Drawing.Point(9, 222);
			this.labelArguments.Name = "labelArguments";
			this.labelArguments.Size = new System.Drawing.Size(70, 12);
			this.labelArguments.TabIndex = 1;
			this.labelArguments.Text = "Arguments:";
			// 
			// listBoxLogs
			// 
			this.listBoxLogs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxLogs.FormattingEnabled = true;
			this.listBoxLogs.HorizontalScrollbar = true;
			this.listBoxLogs.ItemHeight = 14;
			this.listBoxLogs.Location = new System.Drawing.Point(11, 341);
			this.listBoxLogs.Name = "listBoxLogs";
			this.listBoxLogs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxLogs.Size = new System.Drawing.Size(760, 200);
			this.listBoxLogs.TabIndex = 6;
			this.listBoxLogs.TabStop = false;
			// 
			// labelLogs
			// 
			this.labelLogs.AutoSize = true;
			this.labelLogs.Location = new System.Drawing.Point(11, 326);
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
			this.groupBoxServer.TabIndex = 3;
			this.groupBoxServer.TabStop = false;
			this.groupBoxServer.Text = "Server";
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
			// groupBoxStress
			// 
			this.groupBoxStress.Controls.Add(this.labelUserCount);
			this.groupBoxStress.Controls.Add(this.numericUpDownUserCount);
			this.groupBoxStress.Controls.Add(this.labelOpenRate);
			this.groupBoxStress.Controls.Add(this.labelQueryRate);
			this.groupBoxStress.Controls.Add(this.textBoxOpenRate);
			this.groupBoxStress.Controls.Add(this.textBoxQueryRate);
			this.groupBoxStress.Controls.Add(this.textBoxTotalQueryRate);
			this.groupBoxStress.Controls.Add(this.labelTotalQueryRate);
			this.groupBoxStress.Controls.Add(this.labelRequestPerSecond);
			this.groupBoxStress.Controls.Add(this.label1);
			this.groupBoxStress.Controls.Add(this.labelQueryPerSecond);
			this.groupBoxStress.Location = new System.Drawing.Point(12, 182);
			this.groupBoxStress.Name = "groupBoxStress";
			this.groupBoxStress.Size = new System.Drawing.Size(267, 134);
			this.groupBoxStress.TabIndex = 4;
			this.groupBoxStress.TabStop = false;
			this.groupBoxStress.Text = "Stress";
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
			this.numericUpDownUserCount.TextChanged += new System.EventHandler(this.NumericUpDownUserCount_TextChanged);
			// 
			// labelOpenRate
			// 
			this.labelOpenRate.AutoSize = true;
			this.labelOpenRate.Location = new System.Drawing.Point(6, 103);
			this.labelOpenRate.Name = "labelOpenRate";
			this.labelOpenRate.Size = new System.Drawing.Size(68, 12);
			this.labelOpenRate.TabIndex = 0;
			this.labelOpenRate.Text = "Open Rate:";
			// 
			// textBoxOpenRate
			// 
			this.textBoxOpenRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "OpenRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxOpenRate.Location = new System.Drawing.Point(84, 101);
			this.textBoxOpenRate.Name = "textBoxOpenRate";
			this.textBoxOpenRate.Size = new System.Drawing.Size(94, 21);
			this.textBoxOpenRate.TabIndex = 2;
			this.textBoxOpenRate.Text = global::OraclePerfTest.Properties.Settings.Default.OpenRate;
			this.textBoxOpenRate.TextChanged += new System.EventHandler(this.TextBoxQueryRate_TextChanged);
			// 
			// textBoxQueryRate
			// 
			this.textBoxQueryRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "QueryRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxQueryRate.Location = new System.Drawing.Point(84, 47);
			this.textBoxQueryRate.Name = "textBoxQueryRate";
			this.textBoxQueryRate.Size = new System.Drawing.Size(94, 21);
			this.textBoxQueryRate.TabIndex = 1;
			this.textBoxQueryRate.Text = global::OraclePerfTest.Properties.Settings.Default.QueryRate;
			this.textBoxQueryRate.TextChanged += new System.EventHandler(this.TextBoxQueryRate_TextChanged);
			// 
			// labelRequestPerSecond
			// 
			this.labelRequestPerSecond.AutoSize = true;
			this.labelRequestPerSecond.Location = new System.Drawing.Point(184, 103);
			this.labelRequestPerSecond.Name = "labelRequestPerSecond";
			this.labelRequestPerSecond.Size = new System.Drawing.Size(66, 12);
			this.labelRequestPerSecond.TabIndex = 0;
			this.labelRequestPerSecond.Text = "req. / sec.";
			// 
			// groupBoxQuery
			// 
			this.groupBoxQuery.Controls.Add(this.groupBoxReadingMode);
			this.groupBoxQuery.Controls.Add(this.groupBoxConnectionMode);
			this.groupBoxQuery.Controls.Add(this.labelQuery);
			this.groupBoxQuery.Controls.Add(this.textBoxFetchSize);
			this.groupBoxQuery.Controls.Add(this.textBoxArguments);
			this.groupBoxQuery.Controls.Add(this.textBoxQuery);
			this.groupBoxQuery.Controls.Add(this.labelFetchSize);
			this.groupBoxQuery.Controls.Add(this.labelArguments);
			this.groupBoxQuery.Location = new System.Drawing.Point(285, 12);
			this.groupBoxQuery.Name = "groupBoxQuery";
			this.groupBoxQuery.Size = new System.Drawing.Size(487, 304);
			this.groupBoxQuery.TabIndex = 5;
			this.groupBoxQuery.TabStop = false;
			this.groupBoxQuery.Text = "Query";
			// 
			// groupBoxReadingMode
			// 
			this.groupBoxReadingMode.Controls.Add(this.radioButtonReadingModeSelect);
			this.groupBoxReadingMode.Controls.Add(this.radioButtonReadingModeSelectRead);
			this.groupBoxReadingMode.Location = new System.Drawing.Point(350, 222);
			this.groupBoxReadingMode.Name = "groupBoxReadingMode";
			this.groupBoxReadingMode.Size = new System.Drawing.Size(127, 72);
			this.groupBoxReadingMode.TabIndex = 6;
			this.groupBoxReadingMode.TabStop = false;
			this.groupBoxReadingMode.Text = "Reading Mode:";
			// 
			// radioButtonReadingModeSelect
			// 
			this.radioButtonReadingModeSelect.AutoSize = true;
			this.radioButtonReadingModeSelect.Location = new System.Drawing.Point(6, 43);
			this.radioButtonReadingModeSelect.Name = "radioButtonReadingModeSelect";
			this.radioButtonReadingModeSelect.Size = new System.Drawing.Size(96, 16);
			this.radioButtonReadingModeSelect.TabIndex = 1;
			this.radioButtonReadingModeSelect.TabStop = true;
			this.radioButtonReadingModeSelect.Text = "Select (only)";
			this.radioButtonReadingModeSelect.UseVisualStyleBackColor = true;
			// 
			// radioButtonReadingModeSelectRead
			// 
			this.radioButtonReadingModeSelectRead.AutoSize = true;
			this.radioButtonReadingModeSelectRead.Checked = true;
			this.radioButtonReadingModeSelectRead.Location = new System.Drawing.Point(6, 21);
			this.radioButtonReadingModeSelectRead.Name = "radioButtonReadingModeSelectRead";
			this.radioButtonReadingModeSelectRead.Size = new System.Drawing.Size(93, 16);
			this.radioButtonReadingModeSelectRead.TabIndex = 0;
			this.radioButtonReadingModeSelectRead.TabStop = true;
			this.radioButtonReadingModeSelectRead.Text = "Select/Read";
			this.radioButtonReadingModeSelectRead.UseVisualStyleBackColor = true;
			// 
			// groupBoxConnectionMode
			// 
			this.groupBoxConnectionMode.Controls.Add(this.radioButtonDisconnected);
			this.groupBoxConnectionMode.Controls.Add(this.radioButtonConnected);
			this.groupBoxConnectionMode.Location = new System.Drawing.Point(217, 222);
			this.groupBoxConnectionMode.Name = "groupBoxConnectionMode";
			this.groupBoxConnectionMode.Size = new System.Drawing.Size(127, 72);
			this.groupBoxConnectionMode.TabIndex = 5;
			this.groupBoxConnectionMode.TabStop = false;
			this.groupBoxConnectionMode.Text = "Connection Mode:";
			// 
			// radioButtonDisconnected
			// 
			this.radioButtonDisconnected.AutoSize = true;
			this.radioButtonDisconnected.Location = new System.Drawing.Point(6, 44);
			this.radioButtonDisconnected.Name = "radioButtonDisconnected";
			this.radioButtonDisconnected.Size = new System.Drawing.Size(100, 16);
			this.radioButtonDisconnected.TabIndex = 1;
			this.radioButtonDisconnected.Text = "Disconnected";
			this.radioButtonDisconnected.UseVisualStyleBackColor = true;
			// 
			// radioButtonConnected
			// 
			this.radioButtonConnected.AutoSize = true;
			this.radioButtonConnected.Checked = true;
			this.radioButtonConnected.Location = new System.Drawing.Point(6, 20);
			this.radioButtonConnected.Name = "radioButtonConnected";
			this.radioButtonConnected.Size = new System.Drawing.Size(84, 16);
			this.radioButtonConnected.TabIndex = 0;
			this.radioButtonConnected.TabStop = true;
			this.radioButtonConnected.Text = "Connected";
			this.radioButtonConnected.UseVisualStyleBackColor = true;
			// 
			// textBoxFetchSize
			// 
			this.textBoxFetchSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "FetchSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxFetchSize.Location = new System.Drawing.Point(123, 237);
			this.textBoxFetchSize.Name = "textBoxFetchSize";
			this.textBoxFetchSize.Size = new System.Drawing.Size(88, 21);
			this.textBoxFetchSize.TabIndex = 4;
			this.textBoxFetchSize.Text = global::OraclePerfTest.Properties.Settings.Default.FetchSize;
			// 
			// textBoxArguments
			// 
			this.textBoxArguments.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "QueryArguments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxArguments.Location = new System.Drawing.Point(11, 237);
			this.textBoxArguments.Multiline = true;
			this.textBoxArguments.Name = "textBoxArguments";
			this.textBoxArguments.Size = new System.Drawing.Size(106, 56);
			this.textBoxArguments.TabIndex = 2;
			this.textBoxArguments.Text = global::OraclePerfTest.Properties.Settings.Default.QueryArguments;
			// 
			// textBoxQuery
			// 
			this.textBoxQuery.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::OraclePerfTest.Properties.Settings.Default, "Query", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxQuery.Location = new System.Drawing.Point(11, 35);
			this.textBoxQuery.Multiline = true;
			this.textBoxQuery.Name = "textBoxQuery";
			this.textBoxQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxQuery.Size = new System.Drawing.Size(466, 176);
			this.textBoxQuery.TabIndex = 0;
			this.textBoxQuery.Text = global::OraclePerfTest.Properties.Settings.Default.Query;
			this.textBoxQuery.WordWrap = false;
			// 
			// labelFetchSize
			// 
			this.labelFetchSize.AutoSize = true;
			this.labelFetchSize.Location = new System.Drawing.Point(121, 222);
			this.labelFetchSize.Name = "labelFetchSize";
			this.labelFetchSize.Size = new System.Drawing.Size(69, 12);
			this.labelFetchSize.TabIndex = 3;
			this.labelFetchSize.Text = "Fetch Size:";
			// 
			// buttonCBT
			// 
			this.buttonCBT.Location = new System.Drawing.Point(173, 559);
			this.buttonCBT.Name = "buttonCBT";
			this.buttonCBT.Size = new System.Drawing.Size(75, 23);
			this.buttonCBT.TabIndex = 7;
			this.buttonCBT.TabStop = false;
			this.buttonCBT.Text = "CBT";
			this.buttonCBT.UseVisualStyleBackColor = true;
			this.buttonCBT.Click += new System.EventHandler(this.ButtonCBT_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 594);
			this.Controls.Add(this.buttonCBT);
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.groupBoxServer.ResumeLayout(false);
			this.groupBoxServer.PerformLayout();
			this.groupBoxStress.ResumeLayout(false);
			this.groupBoxStress.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserCount)).EndInit();
			this.groupBoxQuery.ResumeLayout(false);
			this.groupBoxQuery.PerformLayout();
			this.groupBoxReadingMode.ResumeLayout(false);
			this.groupBoxReadingMode.PerformLayout();
			this.groupBoxConnectionMode.ResumeLayout(false);
			this.groupBoxConnectionMode.PerformLayout();
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
		private System.Windows.Forms.Button buttonCBT;
		private System.Windows.Forms.GroupBox groupBoxConnectionMode;
		private System.Windows.Forms.RadioButton radioButtonDisconnected;
		private System.Windows.Forms.RadioButton radioButtonConnected;
		private System.Windows.Forms.Label labelOpenRate;
		private System.Windows.Forms.TextBox textBoxOpenRate;
		private System.Windows.Forms.Label labelRequestPerSecond;
		private System.Windows.Forms.TextBox textBoxFetchSize;
		private System.Windows.Forms.Label labelFetchSize;
		private System.Windows.Forms.GroupBox groupBoxReadingMode;
		private System.Windows.Forms.RadioButton radioButtonReadingModeSelect;
		private System.Windows.Forms.RadioButton radioButtonReadingModeSelectRead;
	}
}

