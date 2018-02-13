using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin.collctr.psscripts
{
    public partial class psscripts : UserControl
    {
        public psscripts()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            PSCode psCodeForm = new PSCode();
            psCodeForm.StartPosition = FormStartPosition.CenterParent;
            if (psCodeForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                toolStripMenuItem1.Tag = psCodeForm.tbPSCode.Text;
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
