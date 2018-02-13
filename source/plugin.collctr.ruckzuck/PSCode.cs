using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RuckZuck_WCF;

namespace plugin.collctr.ruckzuck
{
    public partial class PSCode : Form
    {
        public string sAuthToken;
        public string sPSInstall;
        public List<GetSoftware> lAllSoftware;

        public PSCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dRow in dataGridView1.SelectedRows)
            {
                string sProductName = dRow.Cells[2].Value as string;
                string sProductVersion = dRow.Cells[3].Value as string;

                sPSInstall = Properties.Resources.PSInstall.Replace("xxx", sProductName).Replace("yyy", sProductVersion);
            }
            
            this.Close();
        }

        private void PSCode_Load(object sender, EventArgs e)
        {
            string sCurrentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            try
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem();
                if (string.IsNullOrEmpty(sAuthToken))
                    sAuthToken = RZRestAPI.GetAuthToken("FreeRZ", GetTimeToken());

                RZRestAPI.Token = sAuthToken;


                lAllSoftware = RZRestAPI.SWResults("");

                dataGridView1.DataSource = lAllSoftware.ToList().OrderBy(t=>t.Shortname).ToList();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private string GetTimeToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }


        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].ToolTipText = dataGridView1.Rows[e.RowIndex].Cells[5].Value as string;
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.Handled = true;
            e.SortResult = Compare(e.CellValue1, e.CellValue2);
        }

        private int Compare(object o1, object o2)
        {
            try
            {
                return -o1.ToString().CompareTo(o2.ToString());
            }
            catch { }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dRow in dataGridView1.SelectedRows)
            {
                string sProductName = dRow.Cells[2].Value as string;
                string sProductVersion = dRow.Cells[3].Value as string;

                //sPSInstall = oRZ.GetSWCheckPS(sProductName, sProductVersion, "");
            }

            this.Close();
        }

        private void btCheckUpdates_Click(object sender, EventArgs e)
        {
            sPSInstall = Properties.Resources.PSUpdateCheck.Replace("$token = '<token>'", "$token = '" + sAuthToken + "'");
            this.Close();
        }
    }
}
