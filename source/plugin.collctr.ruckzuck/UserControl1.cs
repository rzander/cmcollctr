using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin.collctr.ruckzuck
{
    public partial class psscripts : UserControl
    {
        public psscripts()
        {
            InitializeComponent();
        }
        string sToken;
        DateTime sTokenDate = new DateTime();

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            PSCode psCodeForm = new PSCode();
            if(!string.IsNullOrEmpty(sToken))
                psCodeForm.sAuthToken = sToken;
            if (DateTime.Now - sTokenDate > new TimeSpan(1, 0, 0))
                psCodeForm.sAuthToken = "";

            psCodeForm.StartPosition = FormStartPosition.CenterParent;
            if (psCodeForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                toolStripMenuItem1.Tag = psCodeForm.sPSInstall;
                sToken = psCodeForm.sAuthToken;
            }
            else
                toolStripMenuItem1.Tag = "";
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
