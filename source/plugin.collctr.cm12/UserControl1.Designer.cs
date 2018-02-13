namespace plugin.collctr.sccmclictr
{
    partial class cm12
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.machinePolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendHeartbeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateEvaluationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.machinePolicyToolStripMenuItem,
            this.sendHeartbeatToolStripMenuItem,
            this.hardwareInvToolStripMenuItem,
            this.updateScanToolStripMenuItem,
            this.updateEvaluationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 136);
            // 
            // machinePolicyToolStripMenuItem
            // 
            this.machinePolicyToolStripMenuItem.Image = global::plugin.collctr.cm12.Properties.Resources.ComputerPolicy;
            this.machinePolicyToolStripMenuItem.Name = "machinePolicyToolStripMenuItem";
            this.machinePolicyToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.machinePolicyToolStripMenuItem.Text = "Request Machine-Policy";
            this.machinePolicyToolStripMenuItem.ToolTipText = "Request and download Machine policies. ";
            this.machinePolicyToolStripMenuItem.Click += new System.EventHandler(this.machinePolicyToolStripMenuItem_Click);
            // 
            // sendHeartbeatToolStripMenuItem
            // 
            this.sendHeartbeatToolStripMenuItem.Image = global::plugin.collctr.cm12.Properties.Resources.Send_Receive;
            this.sendHeartbeatToolStripMenuItem.Name = "sendHeartbeatToolStripMenuItem";
            this.sendHeartbeatToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.sendHeartbeatToolStripMenuItem.Text = "Discovery Data Collection Cycle";
            this.sendHeartbeatToolStripMenuItem.ToolTipText = "Send a Heartbeat ( Discovery Data Collection Cycle ).";
            this.sendHeartbeatToolStripMenuItem.Click += new System.EventHandler(this.sendHeartbeatToolStripMenuItem_Click);
            // 
            // hardwareInvToolStripMenuItem
            // 
            this.hardwareInvToolStripMenuItem.Image = global::plugin.collctr.cm12.Properties.Resources.Memory;
            this.hardwareInvToolStripMenuItem.Name = "hardwareInvToolStripMenuItem";
            this.hardwareInvToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.hardwareInvToolStripMenuItem.Text = "Hardware Inventory";
            this.hardwareInvToolStripMenuItem.ToolTipText = "send Hardware Inventory";
            this.hardwareInvToolStripMenuItem.Click += new System.EventHandler(this.hardwareInvToolStripMenuItem_Click);
            // 
            // updateScanToolStripMenuItem
            // 
            this.updateScanToolStripMenuItem.Image = global::plugin.collctr.cm12.Properties.Resources.SWUpdate;
            this.updateScanToolStripMenuItem.Name = "updateScanToolStripMenuItem";
            this.updateScanToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.updateScanToolStripMenuItem.Text = "Update Scan (CM12)";
            this.updateScanToolStripMenuItem.ToolTipText = "Scan for Software Update";
            this.updateScanToolStripMenuItem.Click += new System.EventHandler(this.updateScanToolStripMenuItem_Click);
            // 
            // updateEvaluationToolStripMenuItem
            // 
            this.updateEvaluationToolStripMenuItem.Image = global::plugin.collctr.cm12.Properties.Resources.SWUpdate;
            this.updateEvaluationToolStripMenuItem.Name = "updateEvaluationToolStripMenuItem";
            this.updateEvaluationToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.updateEvaluationToolStripMenuItem.Text = "Update Evaluation (CM12)";
            this.updateEvaluationToolStripMenuItem.ToolTipText = "Apply pending Updates";
            this.updateEvaluationToolStripMenuItem.Click += new System.EventHandler(this.updateEvaluationToolStripMenuItem_Click);
            // 
            // cm12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "cm12";
            this.Size = new System.Drawing.Size(515, 150);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem machinePolicyToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendHeartbeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareInvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateEvaluationToolStripMenuItem;

    }
}
