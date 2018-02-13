using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

namespace CMHealthMon
{
    public partial class PasswordManager : Form
    {
        public PasswordManager()
        {
            InitializeComponent();

            try
            {

                //BindingSource bs = dataGridView1.DataSource as BindingSource;
                BindingSource bs = new BindingSource();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<PWList>));
                StringReader textReader = new StringReader(Properties.Settings.Default.PasswordManager);
                bs.DataSource = (BindingList<PWList>)(xmlSerializer.Deserialize(textReader));

                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = bs;

                dataGridView1.Columns["Password"].Visible = false;
                dataGridView1.Columns["PWD"].HeaderText = "Password";
                dataGridView1.Columns["Username"].HeaderText = "Domain\\Username";
                dataGridView1.Columns["Domain"].HeaderText = "Computername and/or suffix";
            }
            catch 
            {
            }
        }

        [Serializable()]
        public class PWList
        {
            public string Domain { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            [XmlIgnore]
            public string PWD
            {
                get { return "********"; }
                set 
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (!value.StartsWith("********"))
                            Password = sccmclictr.automation.common.Encrypt(value, Domain);
                    }
                    else
                    {
                        Password = null;
                    }
                }
            }
        }

        public string XML;

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bs = dataGridView1.DataSource as BindingSource;

            IList<PWList> oSource = bs.List as IList<PWList>;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<PWList>));
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, bs.List);

            XML = textWriter.ToString();

            this.Close();
        }


    }
}
