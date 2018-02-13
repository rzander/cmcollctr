using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sccmclictr.automation;

namespace plugin.collctr.localpsscripts
{
    public partial class psscripts : UserControl
    {
        internal string sPSCode = "";
        public psscripts()
        {
            InitializeComponent();
            toolStripMenuItem1.QueryContinueDrag += toolStripMenuItem1_QueryContinueDrag;
        }

        static public string PSHost = "";
        static public string PSHostUser = "";
        static public string PSHostPW = "";

        void toolStripMenuItem1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = ((DataGridViewSelectedRowCollection)toolStripMenuItem1.Tag);
            List<string> lHosts = new List<string>();
            foreach (DataGridViewRow dRow in selectedRows)
            {
                try
                {
                    string sHost = dRow.Cells[0].Value.ToString();
                    int iOnline = (int)dRow.Cells[7].Value;

                    if (iOnline > 0)
                    {
                        try
                        {
                            if (sHost != null)
                            {
                                if(sHost.Contains('.'))
                                    lHosts.Add("'" + sHost.Split('.')[0] + "'");
                                else
                                    lHosts.Add("'" + sHost + "'");
                            }
                        }
                        catch (Exception ex)
                        {
                            dRow.Cells[9].Value = "";
                            dRow.Cells[9].Value = ex.Message.ToString(); ;
                        }
                    }
                }
                catch { }
            }

            try
            {
                SCCMAgent oAgent = new SCCMAgent(PSHost, PSHostUser, PSHostPW);
                string sResult = oAgent.Client.GetStringFromPS("$devices = @(" + string.Join(",", lHosts) + "); " + sPSCode);
                oAgent.disconnect();

                if (!string.IsNullOrEmpty(sResult))
                {
                    MessageBox.Show(sResult, "PowerShell Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PSCode psCodeForm = new PSCode();
            psCodeForm.StartPosition = FormStartPosition.CenterParent;
            if (psCodeForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //toolStripMenuItem1.Tag = psCodeForm.tbPSCode.Text;
                toolStripMenuItem1.Tag = "";
                sPSCode = psCodeForm.tbPSCode.Text;
                PSHost = psCodeForm.PSHost;
                PSHostPW = psCodeForm.PSHostPW;
                PSHostUser = psCodeForm.PSHostUser;
            }
            else
            {
                toolStripMenuItem1.Tag = "";
                sPSCode = "";
            }

        }
    }

    public class MainMenu : ContextMenuStrip
    {
        public MainMenu()
        {
            this.Items.Add(new psscripts().contextMenuStrip1.Items["toolStripMenuItem1"]);
        }
    }
}
