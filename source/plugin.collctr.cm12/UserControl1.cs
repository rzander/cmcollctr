using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin.collctr.sccmclictr
{
    public partial class cm12 : UserControl
    {
        public cm12()
        {
            InitializeComponent();
        }

        private void machinePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            machinePolicyToolStripMenuItem.Tag = @"([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000021}') | out-null; 'Machine Policy requested'";
        }

        private void sendHeartbeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendHeartbeatToolStripMenuItem.Tag = @" ([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000003}') | out-null; 'Heartbeat requested'";
        }

        private void hardwareInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardwareInvToolStripMenuItem.Tag = @" ([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000001}') | out-null; 'HW Inventory'";
        }

        private void updateScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateScanToolStripMenuItem.Tag = @" ([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000113}') | out-null; 'Upd. Scan'";
        }

        private void updateEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEvaluationToolStripMenuItem.Tag = @" ([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000108}') | out-null; 'Upd. Evaluation'";
        }


    }

    //Pass ToolStripMenuItem to Class MainMenu to make in available in CollCtr
    public class MainMenu : ContextMenuStrip
    {
        public MainMenu()
        {
            this.Items.Add(new cm12().contextMenuStrip1.Items["machinePolicyToolStripMenuItem"]);
            this.Items.Add(new cm12().contextMenuStrip1.Items["sendHeartbeatToolStripMenuItem"]);
            this.Items.Add(new cm12().contextMenuStrip1.Items["hardwareInvToolStripMenuItem"]);
            this.Items.Add(new cm12().contextMenuStrip1.Items["updateScanToolStripMenuItem"]);
            this.Items.Add(new cm12().contextMenuStrip1.Items["updateEvaluationToolStripMenuItem"]);
        }
    }

    public class GridView
    {
        public GridView() 
        {
            this.ToString();
        }
        public void EnableCMRows()
        {
            this.ToString();
        }

        public void EnableCMRows(object Args)
        {
            DataGridView dgv = (DataGridView)Args;
            foreach(DataGridViewColumn dc in dgv.Columns)
            {
                if(dc.DataPropertyName == "SiteCode")
                {
                    dc.Visible = true;
                }
                if (dc.DataPropertyName == "AgentVersion")
                {
                    dc.Visible = true;
                }
                if (dc.DataPropertyName == "HealthUpdateMissingIcon")
                {
                    dc.Visible = true;
                }
                if (dc.DataPropertyName == "HealthInstallationRunningIcon")
                {
                    dc.Visible = true;
                }
                
            }
        }
    }
}
