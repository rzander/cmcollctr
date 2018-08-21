namespace CMHealthMon
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.computerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLoggedOnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.AgentVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastRebootDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnlineStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnlineTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.healthTimeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorTimeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRebootDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HealthRebootIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.HealthUpdateMissingIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.HealthInstallationRunningIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.HealthIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.computerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tPing = new System.Windows.Forms.Timer(this.components);
            this.tHealthCheck = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslPingThreadsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPingThreads = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslHealthCheckThreadsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslHealthCheckThreads = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCopyRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.tThreadCheck = new System.Windows.Forms.Timer(this.components);
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonHost1 = new System.Windows.Forms.RibbonHost();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbPingAll = new System.Windows.Forms.RibbonButton();
            this.rbPingOffline = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.rbCheckAll = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.rbRemoveOffline = new System.Windows.Forms.RibbonButton();
            this.rbRemoveWarnings = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.rbStop = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.cbPing = new System.Windows.Forms.RibbonCheckBox();
            this.cbHealthCheck = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rbAddConsoleExtension = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.rbRemoveConsoleExtension = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.rtb_MaxPingThreads = new System.Windows.Forms.RibbonTextBox();
            this.rtb_MaxCheckThreads = new System.Windows.Forms.RibbonTextBox();
            this.rtb_PingTimeout = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.rtb_DNSSuffix = new System.Windows.Forms.RibbonTextBox();
            this.rtb_WinRMPort = new System.Windows.Forms.RibbonTextBox();
            this.rcb_WinRMSSL = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel10 = new System.Windows.Forms.RibbonPanel();
            this.rtbUsername = new System.Windows.Forms.RibbonTextBox();
            this.rtbPassword = new System.Windows.Forms.RibbonTextBox();
            this.rBPasswordManager = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.rblVersion = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel3 = new System.Windows.Forms.RibbonLabel();
            this.rlbFileVersion = new System.Windows.Forms.RibbonLabel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox2 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.computerNameDataGridViewTextBoxColumn,
            this.iPAddressDataGridViewTextBoxColumn,
            this.SiteCode,
            this.UserLoggedOnIcon,
            this.AgentVersion,
            this.LastRebootDiff,
            this.StatusMessage,
            this.OnlineStatus,
            this.errorDataGridViewTextBoxColumn,
            this.errorMessageDataGridViewTextBoxColumn,
            this.OnlineTimeStamp,
            this.healthTimeStampDataGridViewTextBoxColumn,
            this.errorTimeStampDataGridViewTextBoxColumn,
            this.lastRebootDataGridViewTextBoxColumn,
            this.HealthRebootIcon,
            this.HealthUpdateMissingIcon,
            this.HealthInstallationRunningIcon,
            this.HealthIcon});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.computerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersWidth = 12;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 373);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // computerNameDataGridViewTextBoxColumn
            // 
            this.computerNameDataGridViewTextBoxColumn.DataPropertyName = "ComputerName";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.computerNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.computerNameDataGridViewTextBoxColumn.HeaderText = "ComputerName";
            this.computerNameDataGridViewTextBoxColumn.Name = "computerNameDataGridViewTextBoxColumn";
            // 
            // iPAddressDataGridViewTextBoxColumn
            // 
            this.iPAddressDataGridViewTextBoxColumn.DataPropertyName = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.HeaderText = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.Name = "iPAddressDataGridViewTextBoxColumn";
            this.iPAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SiteCode
            // 
            this.SiteCode.DataPropertyName = "SiteCode";
            this.SiteCode.HeaderText = "SiteCode";
            this.SiteCode.Name = "SiteCode";
            this.SiteCode.ReadOnly = true;
            this.SiteCode.Visible = false;
            this.SiteCode.Width = 54;
            // 
            // UserLoggedOnIcon
            // 
            this.UserLoggedOnIcon.DataPropertyName = "UsersLoggedOnIcon";
            this.UserLoggedOnIcon.HeaderText = "Users LoggedOn ";
            this.UserLoggedOnIcon.Name = "UserLoggedOnIcon";
            this.UserLoggedOnIcon.ReadOnly = true;
            // 
            // AgentVersion
            // 
            this.AgentVersion.DataPropertyName = "AgentVersion";
            this.AgentVersion.HeaderText = "AgentVersion";
            this.AgentVersion.Name = "AgentVersion";
            this.AgentVersion.ReadOnly = true;
            this.AgentVersion.Visible = false;
            // 
            // LastRebootDiff
            // 
            this.LastRebootDiff.DataPropertyName = "LastRebootDiff";
            this.LastRebootDiff.HeaderText = "LastRebootDiff";
            this.LastRebootDiff.Name = "LastRebootDiff";
            this.LastRebootDiff.ReadOnly = true;
            // 
            // StatusMessage
            // 
            this.StatusMessage.DataPropertyName = "StatusMessage";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.StatusMessage.HeaderText = "Command Results";
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.ReadOnly = true;
            this.StatusMessage.ToolTipText = "result of the Powershell commands";
            this.StatusMessage.Width = 250;
            // 
            // OnlineStatus
            // 
            this.OnlineStatus.DataPropertyName = "OnlineStatus";
            this.OnlineStatus.HeaderText = "OnlineStatus";
            this.OnlineStatus.Name = "OnlineStatus";
            this.OnlineStatus.ReadOnly = true;
            this.OnlineStatus.Width = 16;
            // 
            // errorDataGridViewTextBoxColumn
            // 
            this.errorDataGridViewTextBoxColumn.DataPropertyName = "Error";
            this.errorDataGridViewTextBoxColumn.HeaderText = "Error";
            this.errorDataGridViewTextBoxColumn.Name = "errorDataGridViewTextBoxColumn";
            this.errorDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorDataGridViewTextBoxColumn.Width = 16;
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            this.errorMessageDataGridViewTextBoxColumn.DataPropertyName = "ErrorMessage";
            this.errorMessageDataGridViewTextBoxColumn.HeaderText = "ErrorMessage";
            this.errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            this.errorMessageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // OnlineTimeStamp
            // 
            this.OnlineTimeStamp.DataPropertyName = "OnlineTimeStamp";
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.OnlineTimeStamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.OnlineTimeStamp.HeaderText = "OnlineTimeStamp";
            this.OnlineTimeStamp.Name = "OnlineTimeStamp";
            this.OnlineTimeStamp.ReadOnly = true;
            // 
            // healthTimeStampDataGridViewTextBoxColumn
            // 
            this.healthTimeStampDataGridViewTextBoxColumn.DataPropertyName = "HealthTimeStamp";
            dataGridViewCellStyle4.Format = "T";
            dataGridViewCellStyle4.NullValue = null;
            this.healthTimeStampDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.healthTimeStampDataGridViewTextBoxColumn.HeaderText = "HealthTimeStamp";
            this.healthTimeStampDataGridViewTextBoxColumn.Name = "healthTimeStampDataGridViewTextBoxColumn";
            this.healthTimeStampDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorTimeStampDataGridViewTextBoxColumn
            // 
            this.errorTimeStampDataGridViewTextBoxColumn.DataPropertyName = "ErrorTimeStamp";
            dataGridViewCellStyle5.Format = "T";
            this.errorTimeStampDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.errorTimeStampDataGridViewTextBoxColumn.HeaderText = "ErrorTimeStamp";
            this.errorTimeStampDataGridViewTextBoxColumn.Name = "errorTimeStampDataGridViewTextBoxColumn";
            this.errorTimeStampDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastRebootDataGridViewTextBoxColumn
            // 
            this.lastRebootDataGridViewTextBoxColumn.DataPropertyName = "LastReboot";
            this.lastRebootDataGridViewTextBoxColumn.HeaderText = "LastReboot";
            this.lastRebootDataGridViewTextBoxColumn.Name = "lastRebootDataGridViewTextBoxColumn";
            this.lastRebootDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // HealthRebootIcon
            // 
            this.HealthRebootIcon.DataPropertyName = "HealthRebootIcon";
            this.HealthRebootIcon.HeaderText = "HealthRebootIcon";
            this.HealthRebootIcon.Name = "HealthRebootIcon";
            this.HealthRebootIcon.ReadOnly = true;
            this.HealthRebootIcon.Width = 32;
            // 
            // HealthUpdateMissingIcon
            // 
            this.HealthUpdateMissingIcon.DataPropertyName = "HealthUpdateMissingIcon";
            this.HealthUpdateMissingIcon.HeaderText = "HealthUpdateMissingIcon";
            this.HealthUpdateMissingIcon.Name = "HealthUpdateMissingIcon";
            this.HealthUpdateMissingIcon.ReadOnly = true;
            this.HealthUpdateMissingIcon.Visible = false;
            this.HealthUpdateMissingIcon.Width = 32;
            // 
            // HealthInstallationRunningIcon
            // 
            this.HealthInstallationRunningIcon.DataPropertyName = "HealthInstallationRunningIcon";
            this.HealthInstallationRunningIcon.HeaderText = "HealthInstallationRunningIcon";
            this.HealthInstallationRunningIcon.Name = "HealthInstallationRunningIcon";
            this.HealthInstallationRunningIcon.ReadOnly = true;
            this.HealthInstallationRunningIcon.Visible = false;
            this.HealthInstallationRunningIcon.Width = 32;
            // 
            // HealthIcon
            // 
            this.HealthIcon.DataPropertyName = "HealthIcon";
            this.HealthIcon.HeaderText = "Icon";
            this.HealthIcon.Name = "HealthIcon";
            this.HealthIcon.ReadOnly = true;
            this.HealthIcon.Width = 32;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // computerBindingSource
            // 
            this.computerBindingSource.DataSource = typeof(CMHealthMon.Computer);
            this.computerBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.computerBindingSource_ListChanged);
            // 
            // tPing
            // 
            this.tPing.Enabled = true;
            this.tPing.Interval = 1000;
            this.tPing.Tick += new System.EventHandler(this.tPing_Tick);
            // 
            // tHealthCheck
            // 
            this.tHealthCheck.Enabled = true;
            this.tHealthCheck.Interval = 3100;
            this.tHealthCheck.Tick += new System.EventHandler(this.tHealthCheck_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPingThreadsLabel,
            this.tslPingThreads,
            this.toolStripStatusLabel1,
            this.tslHealthCheckThreadsLabel,
            this.tslHealthCheckThreads,
            this.toolStripStatusLabel2,
            this.tslCountLabel,
            this.tslCount,
            this.tslCopyRight});
            this.statusStrip1.Location = new System.Drawing.Point(0, 513);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslPingThreadsLabel
            // 
            this.tslPingThreadsLabel.Name = "tslPingThreadsLabel";
            this.tslPingThreadsLabel.Size = new System.Drawing.Size(34, 17);
            this.tslPingThreadsLabel.Text = "Ping:";
            // 
            // tslPingThreads
            // 
            this.tslPingThreads.Name = "tslPingThreads";
            this.tslPingThreads.Size = new System.Drawing.Size(13, 17);
            this.tslPingThreads.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // tslHealthCheckThreadsLabel
            // 
            this.tslHealthCheckThreadsLabel.Name = "tslHealthCheckThreadsLabel";
            this.tslHealthCheckThreadsLabel.Size = new System.Drawing.Size(76, 17);
            this.tslHealthCheckThreadsLabel.Text = "Healthcheck:";
            // 
            // tslHealthCheckThreads
            // 
            this.tslHealthCheckThreads.Name = "tslHealthCheckThreads";
            this.tslHealthCheckThreads.Size = new System.Drawing.Size(13, 17);
            this.tslHealthCheckThreads.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.Text = " | ";
            // 
            // tslCountLabel
            // 
            this.tslCountLabel.Name = "tslCountLabel";
            this.tslCountLabel.Size = new System.Drawing.Size(48, 17);
            this.tslCountLabel.Text = "Online: ";
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(38, 17);
            this.tslCount.Text = "( 0/0 )";
            // 
            // tslCopyRight
            // 
            this.tslCopyRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslCopyRight.Name = "tslCopyRight";
            this.tslCopyRight.Size = new System.Drawing.Size(884, 17);
            this.tslCopyRight.Spring = true;
            this.tslCopyRight.Text = "Copyright (c) 2018 by Roger Zander";
            this.tslCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tslCopyRight.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tThreadCheck
            // 
            this.tThreadCheck.Enabled = true;
            this.tThreadCheck.Interval = 700;
            this.tThreadCheck.Tick += new System.EventHandler(this.tThreadCheck_Tick);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonHost1
            // 
            this.ribbonHost1.HostedControl = null;
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1184, 139);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Text = "Main";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rbPingAll);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel2.Items.Add(this.rbCheckAll);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel2.Items.Add(this.rbRemoveOffline);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator3);
            this.ribbonPanel2.Items.Add(this.rbStop);
            this.ribbonPanel2.Text = "Actions";
            // 
            // rbPingAll
            // 
            this.rbPingAll.DropDownItems.Add(this.rbPingOffline);
            this.rbPingAll.Image = global::CMHealthMon.Properties.Resources.Radar_48;
            this.rbPingAll.MinimumSize = new System.Drawing.Size(80, 40);
            this.rbPingAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbPingAll.SmallImage")));
            this.rbPingAll.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbPingAll.Text = "Ping All...";
            this.rbPingAll.ToolTip = "Ping all systems and resolve the IP address.";
            this.rbPingAll.Click += new System.EventHandler(this.rbPingAll_Click);
            // 
            // rbPingOffline
            // 
            this.rbPingOffline.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbPingOffline.Image = ((System.Drawing.Image)(resources.GetObject("rbPingOffline.Image")));
            this.rbPingOffline.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbPingOffline.SmallImage")));
            this.rbPingOffline.Text = "Ping Offline...";
            this.rbPingOffline.ToolTip = "Ping all systems that are offline.";
            this.rbPingOffline.Click += new System.EventHandler(this.rbPingOffline_Click);
            // 
            // rbCheckAll
            // 
            this.rbCheckAll.DrawIconsBar = false;
            this.rbCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("rbCheckAll.Image")));
            this.rbCheckAll.MinimumSize = new System.Drawing.Size(80, 0);
            this.rbCheckAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCheckAll.SmallImage")));
            this.rbCheckAll.Text = "Check All...";
            this.rbCheckAll.ToolTip = "Run a health check against all online systems.";
            this.rbCheckAll.Click += new System.EventHandler(this.rbCheckAll_Click);
            // 
            // rbRemoveOffline
            // 
            this.rbRemoveOffline.DropDownItems.Add(this.rbRemoveWarnings);
            this.rbRemoveOffline.Image = ((System.Drawing.Image)(resources.GetObject("rbRemoveOffline.Image")));
            this.rbRemoveOffline.MinimumSize = new System.Drawing.Size(80, 0);
            this.rbRemoveOffline.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRemoveOffline.SmallImage")));
            this.rbRemoveOffline.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
            this.rbRemoveOffline.Text = "Remove offline...";
            this.rbRemoveOffline.ToolTip = "Remove all systems from the List that are offline.";
            this.rbRemoveOffline.Click += new System.EventHandler(this.rbRemoveOffline_Click);
            // 
            // rbRemoveWarnings
            // 
            this.rbRemoveWarnings.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbRemoveWarnings.Image = ((System.Drawing.Image)(resources.GetObject("rbRemoveWarnings.Image")));
            this.rbRemoveWarnings.SmallImage = global::CMHealthMon.Properties.Resources.Waring;
            this.rbRemoveWarnings.Text = "Remove all Warnings...";
            this.rbRemoveWarnings.ToolTip = "Remove all systems with a Warning";
            this.rbRemoveWarnings.Click += new System.EventHandler(this.rbRemoveWarnings_Click);
            // 
            // rbStop
            // 
            this.rbStop.Image = ((System.Drawing.Image)(resources.GetObject("rbStop.Image")));
            this.rbStop.MinimumSize = new System.Drawing.Size(80, 0);
            this.rbStop.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbStop.SmallImage")));
            this.rbStop.Text = "Stop commands...";
            this.rbStop.ToolTip = "Stop all running activities (ping, healthcheck and powershell commands)";
            this.rbStop.Click += new System.EventHandler(this.rbStop_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.cbPing);
            this.ribbonPanel3.Items.Add(this.cbHealthCheck);
            this.ribbonPanel3.Text = "Autoupdate";
            // 
            // cbPing
            // 
            this.cbPing.Checked = true;
            this.cbPing.Text = "Ping";
            this.cbPing.ToolTip = "Automatically check if all systems are online.";
            this.cbPing.CheckBoxCheckChanged += new System.EventHandler(this.cbPing_CheckedChanged);
            // 
            // cbHealthCheck
            // 
            this.cbHealthCheck.Checked = true;
            this.cbHealthCheck.Text = "Health Check";
            this.cbHealthCheck.ToolTip = "Automatically check the health state of all systems that are online.";
            this.cbHealthCheck.CheckBoxCheckChanged += new System.EventHandler(this.cbHealthCheck_CheckBoxCheckChanged);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Panels.Add(this.ribbonPanel7);
            this.ribbonTab3.Panels.Add(this.ribbonPanel8);
            this.ribbonTab3.Panels.Add(this.ribbonPanel10);
            this.ribbonTab3.Text = "Settings";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.rbAddConsoleExtension);
            this.ribbonPanel4.Items.Add(this.ribbonSeparator4);
            this.ribbonPanel4.Items.Add(this.rbRemoveConsoleExtension);
            this.ribbonPanel4.Text = "Configuration Manager 2012";
            // 
            // rbAddConsoleExtension
            // 
            this.rbAddConsoleExtension.Image = global::CMHealthMon.Properties.Resources.Microsoft_CM12_small___Copy;
            this.rbAddConsoleExtension.MinimumSize = new System.Drawing.Size(80, 0);
            this.rbAddConsoleExtension.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddConsoleExtension.SmallImage")));
            this.rbAddConsoleExtension.Text = "Add Console extension...";
            this.rbAddConsoleExtension.ToolTip = "Integrate Collection Commander as Right-Click tool in the CM12 Console.";
            this.rbAddConsoleExtension.Click += new System.EventHandler(this.rbAddConsoleExtension_Click);
            // 
            // rbRemoveConsoleExtension
            // 
            this.rbRemoveConsoleExtension.Image = global::CMHealthMon.Properties.Resources.Microsoft_CM12_small___Copy;
            this.rbRemoveConsoleExtension.MinimumSize = new System.Drawing.Size(80, 0);
            this.rbRemoveConsoleExtension.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRemoveConsoleExtension.SmallImage")));
            this.rbRemoveConsoleExtension.Text = "Remove Console extension...";
            this.rbRemoveConsoleExtension.ToolTip = "Remove the CM12 console extension.";
            this.rbRemoveConsoleExtension.Click += new System.EventHandler(this.rbRemoveConsoleExtension_Click);
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Items.Add(this.rtb_MaxPingThreads);
            this.ribbonPanel7.Items.Add(this.rtb_MaxCheckThreads);
            this.ribbonPanel7.Items.Add(this.rtb_PingTimeout);
            this.ribbonPanel7.Text = "Performance Settings";
            // 
            // rtb_MaxPingThreads
            // 
            this.rtb_MaxPingThreads.LabelWidth = 120;
            this.rtb_MaxPingThreads.Text = "max. Ping Threads:";
            this.rtb_MaxPingThreads.TextBoxText = "";
            this.rtb_MaxPingThreads.ToolTip = "maximum concurrent threads to ping devices.";
            this.rtb_MaxPingThreads.TextBoxTextChanged += new System.EventHandler(this.rtb_MaxPingThreads_TextBoxTextChanged);
            // 
            // rtb_MaxCheckThreads
            // 
            this.rtb_MaxCheckThreads.LabelWidth = 120;
            this.rtb_MaxCheckThreads.Text = "max. Check Threads:";
            this.rtb_MaxCheckThreads.TextBoxText = "";
            this.rtb_MaxCheckThreads.ToolTip = "concurrent working threads for Healthcheck or PS Code.";
            this.rtb_MaxCheckThreads.TextBoxTextChanged += new System.EventHandler(this.rtb_MaxCheckThreads_TextBoxTextChanged);
            // 
            // rtb_PingTimeout
            // 
            this.rtb_PingTimeout.LabelWidth = 120;
            this.rtb_PingTimeout.Text = "Ping Timeout (ms):";
            this.rtb_PingTimeout.TextBoxText = "";
            this.rtb_PingTimeout.ToolTipTitle = "Timeout (ms) if a device does not answer on a ping request.";
            this.rtb_PingTimeout.TextBoxTextChanged += new System.EventHandler(this.rtb_PingTimeout_TextBoxTextChanged);
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Items.Add(this.rtb_DNSSuffix);
            this.ribbonPanel8.Items.Add(this.rtb_WinRMPort);
            this.ribbonPanel8.Items.Add(this.rcb_WinRMSSL);
            this.ribbonPanel8.Text = "Conection Settings";
            // 
            // rtb_DNSSuffix
            // 
            this.rtb_DNSSuffix.LabelWidth = 75;
            this.rtb_DNSSuffix.Text = "DNS Suffix:";
            this.rtb_DNSSuffix.TextBoxText = "";
            this.rtb_DNSSuffix.TextBoxWidth = 200;
            this.rtb_DNSSuffix.TextBoxTextChanged += new System.EventHandler(this.rtb_DNSSuffix_TextBoxTextChanged);
            // 
            // rtb_WinRMPort
            // 
            this.rtb_WinRMPort.LabelWidth = 75;
            this.rtb_WinRMPort.Text = "WinRM Port:";
            this.rtb_WinRMPort.TextBoxText = "5985";
            this.rtb_WinRMPort.TextBoxWidth = 60;
            this.rtb_WinRMPort.Value = "5985";
            this.rtb_WinRMPort.TextBoxTextChanged += new System.EventHandler(this.rtb_WinRMPort_TextBoxTextChanged);
            // 
            // rcb_WinRMSSL
            // 
            this.rcb_WinRMSSL.CheckBoxOrientation = System.Windows.Forms.RibbonCheckBox.CheckBoxOrientationEnum.Right;
            this.rcb_WinRMSSL.Text = "WinRM SSL:";
            this.rcb_WinRMSSL.CheckBoxCheckChanged += new System.EventHandler(this.rcb_WinRMSSL_CheckBoxCheckChanged);
            // 
            // ribbonPanel10
            // 
            this.ribbonPanel10.Items.Add(this.rtbUsername);
            this.ribbonPanel10.Items.Add(this.rtbPassword);
            this.ribbonPanel10.Items.Add(this.rBPasswordManager);
            this.ribbonPanel10.Text = "Account";
            // 
            // rtbUsername
            // 
            this.rtbUsername.LabelWidth = 65;
            this.rtbUsername.Text = "Username:";
            this.rtbUsername.TextBoxText = "";
            this.rtbUsername.TextBoxWidth = 150;
            this.rtbUsername.Visible = false;
            this.rtbUsername.TextBoxTextChanged += new System.EventHandler(this.rtbUsername_TextBoxTextChanged);
            // 
            // rtbPassword
            // 
            this.rtbPassword.LabelWidth = 65;
            this.rtbPassword.Text = "Password:";
            this.rtbPassword.TextBoxText = "";
            this.rtbPassword.TextBoxWidth = 150;
            this.rtbPassword.Visible = false;
            // 
            // rBPasswordManager
            // 
            this.rBPasswordManager.Image = ((System.Drawing.Image)(resources.GetObject("rBPasswordManager.Image")));
            this.rBPasswordManager.SmallImage = ((System.Drawing.Image)(resources.GetObject("rBPasswordManager.SmallImage")));
            this.rBPasswordManager.Text = "Manage Passwords";
            this.rBPasswordManager.Click += new System.EventHandler(this.rBPasswordManager_Click);
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Panels.Add(this.ribbonPanel5);
            this.ribbonTab4.Panels.Add(this.ribbonPanel9);
            this.ribbonTab4.Text = "About";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.ribbonButton4);
            this.ribbonPanel5.Items.Add(this.ribbonSeparator5);
            this.ribbonPanel5.Items.Add(this.ribbonLabel1);
            this.ribbonPanel5.Text = "Project";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.DrawIconsBar = false;
            this.ribbonButton4.Image = global::CMHealthMon.Properties.Resources.opensource_logo_small2;
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Project Page: https://cmcollctr.codeplex.com/";
            this.ribbonButton4.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            this.ribbonButton4.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Text = "Collection Commander for Configuration Manager (c) 2016  by Roger Zander";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.Items.Add(this.ribbonLabel2);
            this.ribbonPanel9.Items.Add(this.rblVersion);
            this.ribbonPanel9.Items.Add(this.ribbonLabel3);
            this.ribbonPanel9.Items.Add(this.rlbFileVersion);
            this.ribbonPanel9.Text = "Version";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Text = "Assembly Version:";
            // 
            // rblVersion
            // 
            this.rblVersion.Text = "0.0.0.0";
            // 
            // ribbonLabel3
            // 
            this.ribbonLabel3.Text = "File Version:";
            // 
            // rlbFileVersion
            // 
            this.rlbFileVersion.Text = "0.0.0.0";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Text = null;
            // 
            // ribbonTextBox1
            // 
            this.ribbonTextBox1.TextBoxText = "";
            // 
            // ribbonTextBox2
            // 
            this.ribbonTextBox2.TextBoxText = "";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.DataPropertyName = "Icon";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "System.Drawing.Bitmap";
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewImageColumn1.FillWeight = 1000F;
            this.dataGridViewImageColumn1.HeaderText = "Icon";
            this.dataGridViewImageColumn1.MinimumWidth = 32;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.ToolTipText = "Status";
            this.dataGridViewImageColumn1.Width = 32;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Icon";
            this.dataGridViewImageColumn2.HeaderText = "Icon";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 32;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "HealthInstallationRunningIcon";
            this.dataGridViewImageColumn3.HeaderText = "HealthInstallationRunningIcon";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 32;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "Icon";
            this.dataGridViewImageColumn4.HeaderText = "Icon";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Width = 32;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 535);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Collection Commander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        public System.Windows.Forms.Timer tPing;
        private System.Windows.Forms.DataGridViewTextBoxColumn iconsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Timer tHealthCheck;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslPingThreadsLabel;
        private System.Windows.Forms.ToolStripStatusLabel tslPingThreads;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslHealthCheckThreadsLabel;
        private System.Windows.Forms.ToolStripStatusLabel tslHealthCheckThreads;
        private System.Windows.Forms.Timer tThreadCheck;
        private System.Windows.Forms.ToolStripStatusLabel tslCopyRight;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.BindingSource computerBindingSource;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonHost ribbonHost1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton rbPingAll;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton rbCheckAll;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonButton rbRemoveOffline;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonCheckBox cbHealthCheck;
        private System.Windows.Forms.RibbonCheckBox cbPing;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonButton rbStop;
        private System.Windows.Forms.RibbonButton rbPingOffline;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rbAddConsoleExtension;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonButton rbRemoveConsoleExtension;
        private System.Windows.Forms.RibbonButton rbRemoveWarnings;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator5;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonTextBox rtb_MaxPingThreads;
        private System.Windows.Forms.RibbonTextBox rtb_MaxCheckThreads;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox1;
        private System.Windows.Forms.RibbonTextBox rtb_PingTimeout;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonTextBox rtb_DNSSuffix;
        private System.Windows.Forms.RibbonTextBox rtb_WinRMPort;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox2;
        private System.Windows.Forms.RibbonCheckBox rcb_WinRMSSL;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.RibbonLabel rblVersion;
        private System.Windows.Forms.RibbonLabel ribbonLabel3;
        private System.Windows.Forms.RibbonLabel rlbFileVersion;
        private System.Windows.Forms.RibbonPanel ribbonPanel10;
        private System.Windows.Forms.RibbonTextBox rtbUsername;
        private System.Windows.Forms.RibbonTextBox rtbPassword;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton rBPasswordManager;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tslCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel tslCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn computerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteCode;
        private System.Windows.Forms.DataGridViewImageColumn UserLoggedOnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastRebootDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnlineStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnlineTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn healthTimeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorTimeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRebootDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn HealthRebootIcon;
        private System.Windows.Forms.DataGridViewImageColumn HealthUpdateMissingIcon;
        private System.Windows.Forms.DataGridViewImageColumn HealthInstallationRunningIcon;
        private System.Windows.Forms.DataGridViewImageColumn HealthIcon;
    }
}
