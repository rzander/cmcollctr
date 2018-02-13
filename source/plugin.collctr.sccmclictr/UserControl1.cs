using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace plugin.collctr.sccmclictr
{
    public partial class psscripts : UserControl
    {
        public psscripts()
        {
            InitializeComponent();
            toolStripMenuItem1.QueryContinueDrag += toolStripMenuItem1_QueryContinueDrag;

            string scpath = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.ClientCenterCMD);

            try
            {
                string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fullPath + ".config");
                XmlNode xNode = xDoc.SelectSingleNode("//configuration/applicationSettings/plugin.collctr.sccmclictr.Properties.Settings/setting/value");
                scpath = xNode.InnerText;
            }
            catch { }

            if (!File.Exists(Environment.ExpandEnvironmentVariables(scpath)))
            {
                toolStripMenuItem1.Enabled = false;
            }
        }

        void toolStripMenuItem1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = ((DataGridViewSelectedRowCollection)toolStripMenuItem1.Tag);
            string sHost = ((DataGridViewSelectedRowCollection)toolStripMenuItem1.Tag)[0].Cells[0].Value.ToString();

            try
            {

                if (sHost != null)
                {
                    string scpath = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.ClientCenterCMD);

                    try
                    {
                        string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(fullPath + ".config");
                        XmlNode xNode = xDoc.SelectSingleNode("//configuration/applicationSettings/plugin.collctr.sccmclictr.Properties.Settings/setting/value");
                        scpath = xNode.InnerText;
                    }
                    catch { }

                    System.Diagnostics.Process pCMD = new System.Diagnostics.Process();
                    pCMD.StartInfo.FileName = string.Format(Environment.ExpandEnvironmentVariables(scpath), sHost);
                    if (!Properties.Settings.Default.ClientCenterCMD.Contains("{0}"))
                    {
                        pCMD.StartInfo.Arguments = sHost;
                    }
                    pCMD.Start();
                } 
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Tag = "";
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
