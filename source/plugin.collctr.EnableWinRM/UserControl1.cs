using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace plugin.collctr.EnableWinRM
{
    public partial class psscripts : UserControl
    {
        public psscripts()
        {
            InitializeComponent();
            toolStripMenuItem1.QueryContinueDrag += toolStripMenuItem1_QueryContinueDrag;
            /*if(!System.IO.File.Exists(Environment.ExpandEnvironmentVariables(Properties.Settings.Default.ClientCenterCMD)))
            {
                toolStripMenuItem1.Enabled = false;
            }*/
        }

        void toolStripMenuItem1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = ((DataGridViewSelectedRowCollection)toolStripMenuItem1.Tag);
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
                                ManagementClass MC = new ManagementClass(@"\\" + sHost + @"\root\cimv2:win32_process");
                                ManagementBaseObject mboParam = MC.GetMethodParameters("Create");
                                mboParam.Properties["CommandLine"].Value = "powershell.exe -ExecutionPolicy Bypass -command enable-psremoting -force";
                                InvokeMethodOptions imo = new InvokeMethodOptions();
                                imo.Timeout = new TimeSpan(0, 0, 30);

                                ManagementBaseObject mboResult = MC.InvokeMethod("Create", mboParam, imo);
                                mboResult.Properties["ReturnValue"].Value.ToString();

                                dRow.Cells[6].Value = "ReturnValue=" + mboResult.Properties["ReturnValue"].Value.ToString();
                            }
                        }
                        catch(Exception ex)
                        {
                            dRow.Cells[9].Value = "";
                            dRow.Cells[9].Value = ex.Message.ToString(); ;
                        }
                    }
                }
                catch { }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Tag = "";
            if(MessageBox.Show("Do you really want to enable WinRM on the selected machines ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                toolStripMenuItem1.Tag = null;
            }
        }
    }

    //Pass ToolStripMenuItem to Class MainMenu to make in available in CollCtr
    public class MainMenu : ContextMenuStrip
    {
        public MainMenu()
        {
            this.Items.Add(new psscripts().contextMenuStrip1.Items["toolStripMenuItem1"]);
        }
    }
}
