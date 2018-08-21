using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.IO;
using sccmclictr.automation;
using System.Threading;
using System.Linq.Expressions;
using CMHealthMon;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Xml.Serialization;

namespace CMHealthMon
{
    public partial class MainForm : Form
    {
        delegate void AnonymousDelegate();
        public static CancellationTokenSource ctPing = new CancellationTokenSource();
        public static CancellationTokenSource ctHealth = new CancellationTokenSource();
        public static int iMaxPingThreads = 20;
        public static int iMaxHealthThreads = 3;
        public static int iPingTimeout = 0;
        public System.Windows.Forms.Timer oDelay = new System.Windows.Forms.Timer();
        public static int PingTimeout = 10;
        public static int HealthTimeout = 10;
        public string FQDN = "";
        public static int WinRMPort = 5985;
        public static bool WinRMSSL = false;
        private static List<PasswordManager.PWList> PWManagerList = new List<PasswordManager.PWList>();
        //private static List<Computer> lHealthComp = new List<Computer>();
        private static List<Computer> lPingComp = new List<Computer>();

        protected static string sPassword(string Computername)
        {
            string sResult = "";

            //Search for exact match...
            try
            {
                if (PWManagerList.Count > 0)
                {
                    PasswordManager.PWList oRes = PWManagerList.Where(p => p.Domain.ToLower() == Computername.ToLower()).First();
                    sResult = sccmclictr.automation.common.Decrypt(oRes.Password, oRes.Domain);
                }
            }
            catch { }

            //Search for domain match...
            if (string.IsNullOrEmpty(sResult) & PWManagerList.Count > 0)
            {
                try
                {
                    if (Computername.Contains('.'))
                    {
                        string domain = Computername.Substring(Computername.IndexOf('.') + 1);
                        string Host = Computername.Split('.')[0];

                        PasswordManager.PWList oRes = PWManagerList.Where(p => p.Domain.ToLower() == domain.ToLower()).First();
                        sResult = sccmclictr.automation.common.Decrypt(oRes.Password, oRes.Domain);
                    }
                }
                catch { }
            }

            return sResult;
        }
        protected static string sUsername(string Computername)
        {
            string sResult = "";

            //Search for exact match...
            try
            {
                sResult = PWManagerList.Where(p => p.Domain.ToLower() == Computername.ToLower()).First().Username;
            }
            catch { }

            //Search for domain match...
            if (string.IsNullOrEmpty(sResult))
            {
                try
                {
                    if (Computername.Contains('.'))
                    {
                        string domain = Computername.Substring(Computername.IndexOf('.') + 1);
                        string Host = Computername.Split('.')[0];

                        sResult = PWManagerList.Where(p => p.Domain.ToLower() == domain.ToLower()).First().Username;
                    }
                }
                catch { }
            }

            return sResult;
        }

        public bool firstStart = true;

        public MainForm()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            InitializeComponent();


            oDelay.Interval = 500;
            oDelay.Tick += oDelay_Tick;
            oDelay.Start();

            iMaxPingThreads = Properties.Settings.Default.MaxPingThreads;
            iMaxHealthThreads = Properties.Settings.Default.MaxHealthThreads;
            iPingTimeout = Properties.Settings.Default.PingTimeout;

            rtb_MaxPingThreads.TextBoxText = iMaxPingThreads.ToString();
            rtb_MaxCheckThreads.TextBoxText = iMaxHealthThreads.ToString();
            rtb_PingTimeout.TextBoxText = iPingTimeout.ToString();
            rtb_DNSSuffix.TextBoxText = Properties.Settings.Default.FQDN;
            rtb_WinRMPort.TextBoxText = Properties.Settings.Default.WinRMPort;
            rcb_WinRMSSL.Checked = Properties.Settings.Default.WinRMSSL;
            rblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            rlbFileVersion.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            FQDN = rtb_DNSSuffix.TextBoxText;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Username))
            {
                try
                {
                    rtbUsername.TextBoxText = Properties.Settings.Default.Username;
                    Assembly asm = Assembly.GetExecutingAssembly();
                    var attribs = (asm.GetCustomAttributes(typeof(GuidAttribute), true));
                    var id = (attribs[0] as GuidAttribute).Value;

                    //sPassword = sccmclictr.automation.common.Decrypt(Properties.Settings.Default.Password, id.ToString());
                    //rtbPassword.TextBoxText = "**********";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

            }



            HealthIcon.DisplayIndex = 0;
            HealthIcon.CellTemplate = new DataGridViewImageCellBlank(true);
            HealthIcon.DefaultCellStyle.NullValue = Properties.Resources.New;
            HealthIcon.Width = 38;
            HealthIcon.HeaderText = "Online";
            HealthIcon.ReadOnly = true;
            HealthIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            LastRebootDiff.DisplayIndex = 5;
            LastRebootDiff.HeaderText = "Reboot";
            LastRebootDiff.Width = 50;
            LastRebootDiff.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            try
            {
                HealthRebootIcon.DisplayIndex = 7;
            }
            catch { }
            HealthRebootIcon.CellTemplate = new DataGridViewImageCellBlank(true);
            HealthRebootIcon.DefaultCellStyle.NullValue = Properties.Resources.Option;
            HealthRebootIcon.Width = 48;
            HealthRebootIcon.HeaderText = "Reboot pending";
            HealthRebootIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            try
            {
                HealthUpdateMissingIcon.DisplayIndex = 8;
            }
            catch { }
            HealthUpdateMissingIcon.CellTemplate = new DataGridViewImageCellBlank(true);
            HealthUpdateMissingIcon.DefaultCellStyle.NullValue = Properties.Resources.Option;
            HealthUpdateMissingIcon.Width = 48;
            HealthUpdateMissingIcon.HeaderText = "Updates missing";
            HealthUpdateMissingIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            try
            {
                HealthInstallationRunningIcon.DisplayIndex = 9;
            }
            catch { }
            HealthInstallationRunningIcon.CellTemplate = new DataGridViewImageCellBlank(true);
            HealthInstallationRunningIcon.DefaultCellStyle.NullValue = Properties.Resources.Option;
            HealthInstallationRunningIcon.Width = 48;
            HealthInstallationRunningIcon.HeaderText = "Install running";
            HealthInstallationRunningIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            try
            {
                UserLoggedOnIcon.DisplayIndex = 10;
            }
            catch { }
            UserLoggedOnIcon.CellTemplate = new DataGridViewImageCellBlank(true);
            UserLoggedOnIcon.DefaultCellStyle.NullValue = Properties.Resources.Option;
            UserLoggedOnIcon.Width = 48;
            UserLoggedOnIcon.HeaderText = "Users online";
            UserLoggedOnIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            //Load external Main-Menu Plugins...
            try
            {
                string sCurrentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                foreach (string sFile in Directory.GetFiles(sCurrentDir, "plugin.collctr.*.dll", SearchOption.TopDirectoryOnly))
                {
                    bool tsep1 = true;
                    Assembly asm = Assembly.LoadFile(sFile);
                    Type[] tlist = asm.GetTypes();
                    foreach (Type t in tlist)
                    {
                        try
                        {
                            if (t.Name.StartsWith("MainMenu"))
                            {
                                var obj = Activator.CreateInstance(t);

                                ContextMenuStrip cms = (ContextMenuStrip)obj;
                                ToolStripItemCollection tsic = cms.Items;

                                while (tsic.Count > 0)
                                {
                                    ToolStripItem tsi = cms.Items[0];
                                    tsi.Click += tsi_Click;

                                    if (tsep1)
                                    {
                                        contextMenuStrip1.Items.Add(new ToolStripSeparator());
                                    }
                                    tsep1 = false;
                                    contextMenuStrip1.Items.Add(tsi);
                                }
                            }

                            //Changes on the DataGrid
                            if (t.Name.StartsWith("GridView"))
                            {
                                try
                                {
                                    var obj = Activator.CreateInstance(t);
                                    object[] oParams = new object[] { dataGridView1 };
                                    var res = t.InvokeMember("EnableCMRows", BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, obj, oParams);
                                    res.ToString();
                                }
                                catch { }
                            }

                        }
                        catch { }
                    }
                }

            }
            catch { }

            dataGridView1.AutoSize = false;

            try
            {
                errorDataGridViewTextBoxColumn.Visible = false;
                lastRebootDataGridViewTextBoxColumn.Visible = false;
                StatusMessage.DisplayIndex = 10;
                OnlineStatus.Visible = false;
            }
            catch { }

            cbHealthCheck.Checked = Properties.Settings.Default.AutoHealthCheck;
            cbPing.Checked = Properties.Settings.Default.AutoPing;

            //Load Password List
            try
            {

                BindingSource bs = new BindingSource();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<PasswordManager.PWList>));
                StringReader textReader = new StringReader(Properties.Settings.Default.PasswordManager);
                bs.DataSource = (BindingList<PasswordManager.PWList>)(xmlSerializer.Deserialize(textReader));

                PWManagerList = bs.List.OfType<PasswordManager.PWList>().ToList();
            }
            catch { }





        }

        void tsi_Click(object sender, EventArgs e)
        {
            string sCode = "";

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please mark the full Row(s) to trigger an Action !", "No Rows selected...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                sCode = ((ToolStripMenuItem)sender).Tag as string;
            }

            if (!string.IsNullOrEmpty(sCode))
            {
                List<Computer> lComp = new List<Computer>();
                foreach (DataGridViewRow dRow in dataGridView1.SelectedRows)
                {
                    try
                    {
                        Computer oComp = computerBindingSource.Cast<Computer>().FirstOrDefault(T => T.ComputerName == (string)dRow.Cells["computerNameDataGridViewTextBoxColumn"].Value);
                        if (oComp.OnlineStatus == 2)
                            lComp.Add(oComp);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }

                ctPing = new CancellationTokenSource();
                ctHealth = new CancellationTokenSource();

                oHealthTask = oHealthTask.ContinueWith((t) => Parallel.ForEach(lComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxHealthThreads, CancellationToken = ctHealth.Token }, oComp =>
                {
                    RunPS_CollectionThread(oComp, sCode);
                }));
            }
            else
            {
                //Pass selected Rows and call DoDragDrop
                if (sCode == "")
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    ((ToolStripMenuItem)sender).Tag = dataGridView1.SelectedRows;
                    ((ToolStripMenuItem)sender).DoDragDrop("", DragDropEffects.All);
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            e.ToString();
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.ToString();
        }

        void oDelay_Tick(object sender, EventArgs e)
        {
            oDelay.Stop();

            if (firstStart)
            {
                if (computerBindingSource.List.Count <= 1)
                {
                    AnonymousDelegate update = delegate()
                    {
                        try
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                        }
                        catch { }
                    };
                    Invoke(update);
                }
                firstStart = false;
            }
        }

        Task oPingTask = Task.Factory.StartNew(() => TasksComplete(null, null));
        Task oHealthTask = Task.Factory.StartNew(() => TasksComplete(null, null));

        void tPing_Tick(object sender, EventArgs e)
        {
            try
            {
                if (oPingTask.Status != TaskStatus.Running & oHealthTask.Status != TaskStatus.Running & !dataGridView1.IsCurrentCellInEditMode & !ctPing.IsCancellationRequested)
                {
                    tPing.Stop();

                    //Wait max 1Min...
                    if (oPingTask.Status != TaskStatus.Canceled)
                        try
                        {
                            oPingTask.Wait(60000, ctPing.Token);
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }

                    AnonymousDelegate updatecounts = delegate()
                    {
                        try
                        {
                            lPingComp = computerBindingSource.Cast<Computer>().Where(t => !string.IsNullOrEmpty(t.ComputerName) &
        (t.OnlineStatus == 0 | (!t.Error & (DateTime.Now - t.OnlineTimeStamp).TotalSeconds >= PingTimeout) | (t.Error & (DateTime.Now - t.ErrorTimeStamp).TotalSeconds > PingTimeout & (DateTime.Now - t.OnlineTimeStamp).TotalSeconds > PingTimeout))).OrderByDescending(t => t.OnlineTimeStamp).ToList();
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    };
                    Invoke(updatecounts);

                    try
                    {
                        if (lPingComp.Count > 0)
                        {
                            //tHealthCheck.Stop();

                            AnonymousDelegate updateresults = delegate()
                            {
                                try
                                {
                                    oPingTask = Task.Factory.StartNew(() => Parallel.ForEach(lPingComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxPingThreads, CancellationToken = ctPing.Token }, dItem =>
                                    {
                                        try
                                        {
                                            if (dItem != null)
                                            {
                                                if (dItem.ComputerName != null)
                                                {
                                                    if (!ctPing.IsCancellationRequested)
                                                    {
                                                        if (string.IsNullOrEmpty(FQDN))
                                                            Ping_CollectionThread(dItem);
                                                        else
                                                        {
                                                            if (!dItem.ComputerName.EndsWith(FQDN, StringComparison.CurrentCultureIgnoreCase) & !dItem.ComputerName.Contains("."))
                                                                dItem.ComputerName = dItem.ComputerName + "." + FQDN;
                                                            Ping_CollectionThread(dItem);
                                                        }

                                                    }
                                                }

                                                dItem = null;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            ex.Message.ToString();
                                        }
                                    }), ctPing.Token);
                                }
                                catch { }
                            };
                            Invoke(updateresults);

                            try
                            {
                                AnonymousDelegate update = delegate()
                                {
                                    try
                                    {
                                        oPingTask.ContinueWith((t) => TasksComplete(dataGridView1, computerBindingSource));
                                    }
                                    catch { }
                                };
                                Invoke(update);
                            }
                            catch { }

                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                try
                {
                    if (cbHealthCheck.Checked)
                        tHealthCheck.Start();
                    if (cbPing.Checked)
                        tPing.Start();
                }
                catch { }
            }
        }

        private void tHealthCheck_Tick(object sender, EventArgs e)
        {
            List<Computer> lHealthComp = new List<Computer>();
            try
            {

                if (oPingTask.Status != TaskStatus.Running & oHealthTask.Status != TaskStatus.Running & oHealthTask.Status != TaskStatus.WaitingForActivation & !dataGridView1.IsCurrentCellInEditMode & !ctHealth.IsCancellationRequested)
                {
                    //List<Computer> lComp = new List<Computer>();
                    tPing.Stop();
                    tHealthCheck.Stop();

                    //Wait max. 1Min
                    oHealthTask.Wait(60000, ctHealth.Token);

                    try
                    {
                        lHealthComp = computerBindingSource.Cast<Computer>().Where(t => t.OnlineStatus == 2 &
                            ((!t.Error & (DateTime.Now - t.HealthTimeStamp).TotalSeconds >= HealthTimeout) |
                            (t.Error & (DateTime.Now - t.ErrorTimeStamp).TotalSeconds > HealthTimeout * 2))).OrderByDescending(t => t.HealthTimeStamp).ToList();
                    }
                    catch { }
                    /*AnonymousDelegate updatecounts = delegate()
                    {

                    };
                    Invoke(updatecounts);*/

                    //if (lComp.Count == 0)
                    if (true)
                    {

                        tPing.Stop();
                        try
                        {
                            oHealthTask = Task.Factory.StartNew(() => Parallel.ForEach(lHealthComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxHealthThreads, CancellationToken = ctHealth.Token }, dItem =>
                            {
                                try
                                {

                                    if (dItem != null)
                                    {
                                        if (dItem.ComputerName != null)
                                        {
                                            if (!ctHealth.IsCancellationRequested)
                                            {
                                                try
                                                {
                                                    Ping_CollectionThread(dItem);
                                                    Application.DoEvents();

                                                    if (dItem.OnlineStatus == 2)
                                                    {
                                                        GetHealth_CollectionThread(dItem);
                                                        Application.DoEvents();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    ex.Message.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ex.Message.ToString();
                                }
                            }), ctHealth.Token);
                        }
                        catch { }

                        //oHealthTask.ContinueWith((t) => TasksComplete(dataGridView1, computerBindingSource));
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (cbHealthCheck.Checked)
                    tHealthCheck.Start();
                if (cbPing.Checked)
                    tPing.Start();
            }
        }

        public static byte[] IconToBytes(Icon icon)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] bResult;
                    icon.Save(ms);
                    bResult = ms.ToArray();
                    ms.Dispose();
                    return bResult;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return new byte[0];

        }

        public static void TasksComplete(DataGridView GridView, BindingSource computerBindingSource)
        {
            try
            {
                GridView.Invalidate();
                Application.DoEvents();
            }
            catch { }
        }

        public static void Ping_CollectionThread(Computer oComp)
        {
            try
            {
                string ClientName = "";

                ClientName = oComp.ComputerName;

                //Ping Client
                if (!string.IsNullOrEmpty(ClientName))
                {

                    try
                    {
                        Ping NewPing = new Ping();
                        try
                        {
                            if (ctPing.IsCancellationRequested)
                                return;
                            PingReply reply = NewPing.Send(ClientName, iPingTimeout);
                            if (ctPing.IsCancellationRequested)
                                return;
                            //Console.WriteLine(ClientName);
                            if (reply.Status == IPStatus.Success)
                            {

                                try
                                {
                                    oComp.IPAddress = reply.Address.ToString();
                                    if (oComp.OnlineStatus == 0 | oComp.OnlineStatus == 1)
                                        oComp.HealthIcon = IconToBytes(Properties.Resources.Online);
                                    oComp.OnlineStatus = 2;
                                    oComp.OnlineTimeStamp = DateTime.Now;
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    oComp.IPAddress = "";
                                    oComp.OnlineStatus = 1;
                                    oComp.HealthIcon = IconToBytes(Properties.Resources.Offline);
                                    oComp.OnlineTimeStamp = DateTime.Now;

                                    oComp.ErrorMessage = "";
                                }
                                catch { }

                                if ((DateTime.Now - oComp.HealthTimeStamp) > new TimeSpan(0, 5, 0))
                                {

                                    try
                                    {
                                        oComp.ErrorMessage = "";
                                        oComp.StatusMessage = "";
                                        oComp.HealthInstallationRunningIcon = IconToBytes(Properties.Resources.Option);
                                        oComp.HealthRebootIcon = IconToBytes(Properties.Resources.Option);
                                        oComp.HealthUpdateMissingIcon = IconToBytes(Properties.Resources.Option);
                                        oComp.UsersLoggedOnIcon = IconToBytes(Properties.Resources.Option);
                                    }
                                    catch { }
                                }
                            }
                            NewPing = null;
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                oComp.IPAddress = "";
                                oComp.OnlineStatus = 1;
                                oComp.HealthIcon = IconToBytes(Properties.Resources.Offline);
                                oComp.OnlineTimeStamp = DateTime.Now;
                            }
                            catch { }

                            if ((DateTime.Now - oComp.HealthTimeStamp) > new TimeSpan(0, 5, 0))
                            {
                                try
                                {
                                    oComp.ErrorMessage = "";
                                    oComp.StatusMessage = "";
                                    oComp.HealthInstallationRunningIcon = IconToBytes(Properties.Resources.Option);
                                    oComp.HealthRebootIcon = IconToBytes(Properties.Resources.Option);
                                    oComp.HealthUpdateMissingIcon = IconToBytes(Properties.Resources.Option);
                                    oComp.UsersLoggedOnIcon = IconToBytes(Properties.Resources.Option);
                                    oComp.ErrorTimeStamp = new DateTime(1, 1, 1);
                                    oComp.HealthTimeStamp = new DateTime(1, 1, 1);
                                }
                                catch { }

                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                bChanges = true;
            }
        }

        public static void GetHealth_CollectionThread(Computer oComp)
        {
            try
            {
                string ClientName = oComp.ComputerName;

                bool bError = false;
                SCCMAgent oAgent = new SCCMAgent(ClientName, sUsername(ClientName), sPassword(ClientName), WinRMPort, WinRMSSL);

                try
                {
                    //Ping Client
                    if (!string.IsNullOrEmpty(ClientName))
                    {
                        if (ctHealth.IsCancellationRequested)
                            return;
                        oAgent.connect();

                        if (ctHealth.IsCancellationRequested)
                            return;

                        if (!oAgent.isConnected)
                            return;

                        string sSiteCode = oAgent.Client.AgentProperties.AssignedSite;
                        string sAgentVersion = oAgent.Client.AgentProperties.ClientVersion;
                        //DateTime dLastReboot = oAgent.Client.AgentProperties.LastReboot;
                        TimeSpan tLastReboot = oAgent.Client.AgentProperties.LastRebootTimeSpan;

                        if (ctHealth.IsCancellationRequested)
                            return;

                        bool bReboot = false;
                        bool bUpdatesMissing = false;
                        bool bUpdatesRunning = false;
                        bool bUserLoggedOn = false;

                        //oComp.ErrorMessage = "?";
                        string sHealth = oAgent.Client.Health.RunHealthCheck();

                        if (!string.IsNullOrEmpty(sHealth))
                        {
                            try
                            {
                                string[] aHealth = sHealth.Split(';');
                                bReboot = bool.Parse(aHealth[0]);
                                bUpdatesMissing = bool.Parse(aHealth[1]);
                                bUpdatesRunning = bool.Parse(aHealth[2]);
                                bUserLoggedOn = bool.Parse(aHealth[3]);

                                try
                                {
                                    oComp.SiteCode = sSiteCode;
                                    oComp.AgentVersion = sAgentVersion;

                                    oComp.LastReboot = DateTime.Now - tLastReboot;
                                    oComp.HealthInstallationRunningStatus = bUpdatesRunning;
                                    oComp.HealthUpdateMissingStatus = bUpdatesMissing;
                                    oComp.UsersLoggedOnStatus = bUserLoggedOn;

                                    if (tLastReboot != null)
                                    {
                                        //TimeSpan ts = DateTime.Now - (DateTime)oComp.LastReboot;
                                        if (tLastReboot.Days >= 1)
                                        {
                                            oComp.LastRebootDiff = String.Format("{0:0}", tLastReboot.Days) + "d";
                                        }
                                        else
                                        {
                                            if (tLastReboot.Hours >= 1)
                                            {
                                                oComp.LastRebootDiff = String.Format("{0:0}", tLastReboot.Hours) + "h";
                                            }
                                            else
                                            {
                                                oComp.LastRebootDiff = String.Format("{0:0}", tLastReboot.Minutes) + "min";
                                            }
                                        }
                                    }

                                    if (bReboot)
                                    {
                                        oComp.HealthRebootIcon = IconToBytes(Properties.Resources.FlagRed);
                                        oComp.HealthRebootStatus = 1;
                                    }
                                    else
                                    {
                                        oComp.HealthRebootIcon = IconToBytes(Properties.Resources.FlagGreen);
                                        oComp.HealthRebootStatus = 0;
                                    }

                                    if (bUpdatesRunning)
                                    {
                                        oComp.HealthInstallationRunningIcon = IconToBytes(Properties.Resources.FlagRed);
                                    }
                                    else
                                    {
                                        oComp.HealthInstallationRunningIcon = IconToBytes(Properties.Resources.FlagGreen);
                                    }

                                    if (bUpdatesMissing)
                                    {
                                        oComp.HealthUpdateMissingIcon = IconToBytes(Properties.Resources.FlagRed);
                                    }
                                    else
                                    {
                                        oComp.HealthUpdateMissingIcon = IconToBytes(Properties.Resources.FlagGreen);
                                    }

                                    if (bUserLoggedOn)
                                    {
                                        oComp.UsersLoggedOnIcon = IconToBytes(Properties.Resources.FlagRed);
                                    }
                                    else
                                    {
                                        oComp.UsersLoggedOnIcon = IconToBytes(Properties.Resources.FlagGreen);
                                    }

                                    oComp.HealthTimeStamp = DateTime.Now;

                                    if (!bError)
                                    {
                                        oComp.Error = false;
                                        oComp.ErrorTimeStamp = new DateTime(1, 1, 1);
                                        oComp.HealthIcon = IconToBytes(Properties.Resources.Online);
                                        oComp.ErrorMessage = "";
                                    }
                                }
                                catch { }
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    oComp.HealthRebootIcon = IconToBytes(Properties.Resources.Option);
                                    oComp.Error = true;
                                    oComp.ErrorTimeStamp = DateTime.Now;
                                    oComp.ErrorMessage = ex.Message;
                                    bError = true;
                                }
                                catch { }
                            }
                        }

                        oAgent.disconnect();
                        oAgent.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    bError = true;
                    try
                    {
                        oComp.HealthIcon = IconToBytes(Properties.Resources.Warning);
                        oComp.ErrorTimeStamp = DateTime.Now;
                        oComp.Error = true;
                        oComp.ErrorMessage = ex.Message;
                    }
                    catch { }
                }
                finally
                {
                    try
                    {
                        if (oAgent != null)
                        {
                            if (oAgent.isConnected)
                            {
                                oAgent.disconnect();
                            }

                            oAgent.Dispose();
                            oAgent = null;
                        }
                    }
                    catch { }
                }

                bChanges = true;
            }
            catch (Exception ex)
            {

                try
                {
                    oComp.ErrorMessage = ex.Message.ToString();                  
                }
                catch { }
            }
            finally
            {

            }
        }

        public static void RunPS_CollectionThread(Computer oComp, string sCode)
        {
            try
            {
                if (oComp != null)
                {
                    if (oComp.ComputerName != null)
                    {
                        SCCMAgent oAgent = new SCCMAgent(oComp.ComputerName, sUsername(oComp.ComputerName), sPassword(oComp.ComputerName), WinRMPort, WinRMSSL);
                        try
                        {
                            string sError = "";
                            string sResult = "";
                            if (ctHealth.IsCancellationRequested)
                                return;
                            oAgent.connect();
                            if (ctHealth.IsCancellationRequested)
                                return;
                            foreach (System.Management.Automation.PSObject oRes in oAgent.Client.GetObjectsFromPS(sCode))
                            {
                                if (oRes.BaseObject.GetType() == typeof(System.Management.Automation.ErrorRecord))
                                {
                                    sError = oRes.ToString();
                                }
                                else
                                {
                                    sResult = oRes.ToString();
                                }
                            }
                            //string sResult = oAgent.Client.GetStringFromPS(sCode);
                            oAgent.disconnect();
                            if (string.IsNullOrEmpty(sError))
                            {
                                oComp.Error = false;
                                oComp.ErrorTimeStamp = new DateTime(1, 1, 1);
                                oComp.ErrorMessage = "";
                                oComp.StatusMessage = sResult;
                                bChanges = true;
                            }
                            else
                            {
                                oComp.StatusMessage = "";
                                oComp.ErrorTimeStamp = DateTime.Now;
                                oComp.ErrorMessage = sError;
                            }

                        }
                        catch (Exception ex)
                        {

                            oComp.HealthIcon = IconToBytes(Properties.Resources.Warning);
                            oComp.ErrorTimeStamp = DateTime.Now;
                            oComp.Error = true;
                            oComp.ErrorMessage = ex.Message;

                        }
                        finally
                        {
                            if (oAgent != null)
                            {
                                if (oAgent.isConnected)
                                {
                                    oAgent.disconnect();
                                }
                            }

                            oAgent.Dispose();
                            oAgent = null;
                        }
                    }
                }
            }
            catch { }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Seems that CancelEdit does fix the Index 0 exception from below
                dataGridView1.CancelEdit();
                //This causes Index0 Exception, but seems to be an Issue with datagridview ?
                dataGridView1.NotifyCurrentCellDirty(true);

                if ((e.KeyCode == Keys.V) & (e.Control))
                {
                    pasteToolStripMenuItem_Click(sender, null);
                    e.Handled = true;
                }

                dataGridView1.CancelEdit();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                char[] lineDelim = { '\r', '\n' };
                char[] colDelim = { '\t', ' ' };
                IDataObject d = Clipboard.GetDataObject();
                string s = (string)d.GetData(DataFormats.Text);
                string[] lines = s.Split(lineDelim, StringSplitOptions.RemoveEmptyEntries);
                dataGridView1.CancelEdit();
                //dataGridView1.ReadOnly = true;

                lastSourceUpdate = DateTime.Now;
                dataGridView1.CancelEdit();
                dataGridView1.NotifyCurrentCellDirty(true);

                AnonymousDelegate updatecounts = delegate()
                {
                    try
                    {
                        computerBindingSource.SuspendBinding();

                        foreach (string sLine in lines)
                        {
                            if (!string.IsNullOrEmpty(sLine))
                            {
                                Computer oComp = new Computer();
                                oComp.ComputerName = sLine.Split(colDelim, StringSplitOptions.RemoveEmptyEntries)[0];

                                computerBindingSource.Add(oComp);
                            }

                        }


                        computerBindingSource = new BindingSource(computerBindingSource.Cast<Computer>().OrderBy(t => t.ComputerName).GroupBy(x => x.ComputerName).Select(y => y.First()).ToList(), "");
                        dataGridView1.DataSource = computerBindingSource;

                        bChanges = true;
                    }
                    catch { }
                };
                Invoke(updatecounts);


            }
            catch { }
            finally
            {
                //dataGridView1.ReadOnly = false;
            }

        }

        private DateTime lastSourceUpdate = new DateTime();

        private static bool bChanges = false;

        private void computerBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                bChanges = true;
                if (e.ListChangedType == ListChangedType.ItemAdded | e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    int iOnline = 1;
                    int iObjects = 1;
                    AnonymousDelegate updatecounts = delegate()
                    {
                        try
                        {
                            iOnline = computerBindingSource.Cast<Computer>().Where(t => t.OnlineStatus == 2).Count();
                            iObjects = computerBindingSource.List.Count;
                        }
                        catch { }
                    };
                    Invoke(updatecounts);

                    if (iOnline == 0)
                        iOnline = 1;

                    PingTimeout = Properties.Settings.Default.PingDelay * iObjects / iMaxPingThreads;
                    HealthTimeout = Properties.Settings.Default.HealthCheckDelay * iOnline / iMaxHealthThreads;

                    //Set HealthTimout to 5min max.
                    if (HealthTimeout > 300)
                        HealthTimeout = 300;

                    if (PingTimeout > 280)
                        PingTimeout = 280;

                    if (HealthTimeout < Properties.Settings.Default.HealthCheckDelay)
                        HealthTimeout = Properties.Settings.Default.HealthCheckDelay;

                    if (PingTimeout < Properties.Settings.Default.PingDelay)
                        PingTimeout = Properties.Settings.Default.PingDelay;

                    lastSourceUpdate = DateTime.Now;

                }
                else
                {
                    if (DateTime.Now - lastSourceUpdate > new TimeSpan(0, 0, 5))
                    {
                        int iOnline = 1;
                        int iObjects = 1;
                        try
                        {
                            AnonymousDelegate updatecounts = delegate()
                            {
                                try
                                {
                                    iOnline = computerBindingSource.Cast<Computer>().Where(t => t.OnlineStatus == 2).Count();
                                    iObjects = computerBindingSource.List.Count;
                                }
                                catch { }
                            };
                            Invoke(updatecounts);
                        }
                        catch { }

                        if (iOnline == 0)
                            iOnline = 1;
                        PingTimeout = Properties.Settings.Default.PingDelay * iObjects / iMaxPingThreads;
                        HealthTimeout = Properties.Settings.Default.HealthCheckDelay * iOnline / iMaxHealthThreads;

                        //Set HealthTimout to 5min max.
                        if (HealthTimeout > 300)
                            HealthTimeout = 300;

                        if (PingTimeout > 280)
                            PingTimeout = 280;

                        if (HealthTimeout < Properties.Settings.Default.HealthCheckDelay)
                            HealthTimeout = Properties.Settings.Default.HealthCheckDelay;

                        if (PingTimeout < Properties.Settings.Default.PingDelay)
                            PingTimeout = Properties.Settings.Default.PingDelay;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Computer> lHealthComp = new List<Computer>();
            try
            {
                if (ctHealth.IsCancellationRequested)
                {
                    ctHealth = new CancellationTokenSource();
                }
                if (ctPing.IsCancellationRequested)
                {
                    ctPing = new CancellationTokenSource();
                }

                try
                {
                    if (oHealthTask.Status == TaskStatus.Running)
                    {
                        //task is already running; queue work
                        foreach (DataGridViewRow dRow in dataGridView1.SelectedRows)
                        {
                            try
                            {
                                AnonymousDelegate updatecounts = delegate()
                                    {
                                        try
                                        {
                                            Computer oComp = (Computer)dRow.DataBoundItem;
                                            oPingTask.ContinueWith((t) => Ping_CollectionThread(oComp), ctPing.Token);

                                            if (oComp.OnlineStatus == 2)
                                            {
                                                oHealthTask = oHealthTask.ContinueWith((t) => GetHealth_CollectionThread(oComp), ctHealth.Token);
                                            }
                                        }
                                        catch { }
                                    };
                                Invoke(updatecounts);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        lHealthComp.Clear();
                        foreach (DataGridViewRow dRow in dataGridView1.SelectedRows)
                        {
                            try
                            {
                                lHealthComp.Add((Computer)dRow.DataBoundItem);

                                /*
                                AnonymousDelegate updatecounts = delegate()
                                {
                                    Computer oComp = computerBindingSource.Cast<Computer>().First(T => T.ComputerName == (string)(dRow.Cells["computerNameDataGridViewTextBoxColumn"].Value));

                                    oPingTask.ContinueWith((t) => Ping_CollectionThread(oComp), ctPing.Token);

                                    if (oComp.OnlineStatus == 2)
                                    {
                                        oHealthTask = oHealthTask.ContinueWith((t) => GetHealth_CollectionThread(oComp), ctHealth.Token);
                                    }

                                };
                                Invoke(updatecounts); */
                            }
                            catch (Exception ex)
                            {
                                ex.Message.ToString();
                            }

                        }
                        oHealthTask = Task.Factory.StartNew(() => Parallel.ForEach(lHealthComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxHealthThreads, CancellationToken = ctHealth.Token }, dItem =>
                        {
                            try
                            {
                                if (dItem != null)
                                {
                                    if (dItem.ComputerName != null)
                                    {
                                        if (!ctHealth.IsCancellationRequested)
                                        {
                                            try
                                            {
                                                //Ping first
                                                AnonymousDelegate ping1 = delegate()
                                                {
                                                    Ping_CollectionThread(dItem);
                                                };
                                                Invoke(ping1);


                                                //If online, check status
                                                if (dItem.OnlineStatus == 2)
                                                {

                                                    AnonymousDelegate hcheck1 = delegate()
                                                    {
                                                        GetHealth_CollectionThread(dItem);
                                                    };
                                                    Invoke(hcheck1);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                ex.Message.ToString();
                                            }
                                        }
                                    }

                                    dItem = null;
                                }
                            }
                            catch (Exception ex)
                            {
                                ex.Message.ToString();
                            }
                        }), ctHealth.Token);
                    }
                }
                catch { }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void tThreadCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                AnonymousDelegate updateLabels = delegate()
                {
                    try
                    {
                        try
                        {
                            tslPingThreads.Text = oPingTask.Status.ToString();
                            tslHealthCheckThreads.Text = oHealthTask.Status.ToString();
                            int iOnline = computerBindingSource.Cast<Computer>().Count(p => p.OnlineStatus == 2);
                            int iAll = computerBindingSource.Cast<Computer>().Count(p => p.OnlineStatus > 0);
                            tslCount.Text = "( " + iOnline + " / " + iAll + " )";
                        }
                        catch { }

                        if (bChanges)
                        {
                            bChanges = false;
                            dataGridView1.Invalidate();
                            Application.DoEvents();
                        }
                    }
                    catch { }
                };
                Invoke(updateLabels);

                if (!tHealthCheck.Enabled & !tPing.Enabled)
                {
                    if (cbHealthCheck.Checked)
                        tHealthCheck.Start();

                    if (cbPing.Checked)
                        tPing.Start();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ctPing = new CancellationTokenSource();
                ctHealth = new CancellationTokenSource();
                bChanges = true;
            }
            catch { }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                ctPing.Cancel();
                ctHealth.Cancel();

                //Stop all running activities
                oHealthTask.Wait(new TimeSpan(0, 0, 0, 10));
                if (oHealthTask.Status != TaskStatus.RanToCompletion)
                {
                    tHealthCheck.Stop();
                    //oHealthTask = null;
                    oHealthTask = Task.Factory.StartNew(() => TasksComplete(null, null));
                }
            }
            catch { }
        }

        private void cbPing_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPing.Checked)
            {
                //ctPing.Cancel();
                tPing.Enabled = false;
            }
            else
            {
                if (ctPing.IsCancellationRequested)
                {
                    ctPing = new CancellationTokenSource();
                }
                tPing.Enabled = true;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string sProp = dataGridView1.Columns[e.ColumnIndex].DataPropertyName.ToString();

                switch (sProp)
                {
                    case "HealthIcon":
                        sProp = "OnlineStatus";
                        break;
                    case "HealthRebootIcon":
                        sProp = "HealthRebootStatus";
                        break;
                    case "HealthUpdateMissingIcon":
                        sProp = "HealthUpdateMissingStatus";
                        break;
                    case "LastRebootDiff":
                        sProp = "LastReboot";
                        break;
                    case "UsersLoggedOnIcon":
                        sProp = "UsersLoggedOnStatus";
                        break;
                    case "HealthInstallationRunningIcon":
                        sProp = "HealthInstallationRunningStatus";
                        break;
                }

                //Computer oc = new Computer().user
                AnonymousDelegate updatecounts = delegate()
                {
                    try
                    {
                        computerBindingSource = new BindingSource(computerBindingSource.Cast<Computer>().OrderByField(sProp).ToList(), "");
                        //computerBindingSource = new BindingSource(computerBindingSource.Cast<Computer>().OrderBy(t => sProp).ToList(), "");
                        dataGridView1.DataSource = computerBindingSource;
                        dataGridView1.Invalidate();
                    }
                    catch { }
                };
                Invoke(updatecounts);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    AnonymousDelegate SelUpdate = delegate()
                    {
                        try
                        {
                            //Unselect the newRow if selected
                            if (dataGridView1.Rows[dataGridView1.NewRowIndex].Selected)
                            {
                                dataGridView1.Rows[dataGridView1.NewRowIndex].Selected = false;
                            }
                        }
                        catch { }
                    };

                    Invoke(SelUpdate);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void rbRemoveOffline_Click(object sender, EventArgs e)
        {
            AnonymousDelegate updatecounts = delegate()
            {
                try
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Invalidate();

                    List<Computer> oList = computerBindingSource.Cast<Computer>().Where(t => t.OnlineStatus == 2).OrderBy(t => t.ComputerName).GroupBy(x => x.ComputerName).Select(y => y.First()).ToList();
                    computerBindingSource.Dispose();

                    computerBindingSource = new BindingSource();
                    computerBindingSource = new BindingSource(oList, "");

                    dataGridView1.DataSource = computerBindingSource;
                    dataGridView1.Invalidate();
                }
                catch { }

            };
            Invoke(updatecounts);


            System.Threading.Thread.Sleep(200);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void rbCheckAll_Click(object sender, EventArgs e)
        {
            GC.Collect();
            List<Computer> lHealthComp = new List<Computer>();
            try
            {
                //Check if healthcheck is already running...
                if (oHealthTask.Status == TaskStatus.Running)
                {
                    return;
                }

                if (oHealthTask.Status == TaskStatus.Canceled)
                {
                    ctHealth = new CancellationTokenSource();
                    ctPing = new CancellationTokenSource();
                    bChanges = true;
                }

                if (oPingTask.Status == TaskStatus.RanToCompletion & oHealthTask.Status == TaskStatus.RanToCompletion & !dataGridView1.IsCurrentCellInEditMode & !ctHealth.IsCancellationRequested)
                {
                    tHealthCheck.Stop();

                                            try
                        {
                            lHealthComp = computerBindingSource.Cast<Computer>().Where(t => t.OnlineStatus == 2).OrderByDescending(t => t.HealthTimeStamp).ToList();
                        }
                        catch { }
                    /*AnonymousDelegate updatecounts = delegate()
                    {

                    };
                    Invoke(updatecounts);*/

                    tPing.Stop();

                    oHealthTask = Task.Factory.StartNew(() => Parallel.ForEach(lHealthComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxHealthThreads, CancellationToken = ctHealth.Token }, dItem =>
                    {
                        try
                        {
                            if (dItem != null)
                            {
                                if (dItem.ComputerName != null)
                                {
                                    if (!ctHealth.IsCancellationRequested)
                                    {
                                        Ping_CollectionThread(dItem);
                                        /*AnonymousDelegate ping1 = delegate()
                                        {
                                            
                                        };
                                        Invoke(ping1);
                                        Application.DoEvents();*/

                                        GetHealth_CollectionThread(dItem);
                                        /*AnonymousDelegate hcheck1 = delegate()
                                        {
                                            if (dItem.OnlineStatus == 2)
                                            {
                                            }
                                        };
                                        Invoke(hcheck1);
                                        Application.DoEvents();*/
                                    }
                                }
                            }
                        }
                        catch { }
                    }), ctHealth.Token);

                    //oHealthTask.ContinueWith((t) => TasksComplete(dataGridView1, computerBindingSource));

                }
                else
                {
                    oHealthTask.Status.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (cbHealthCheck.Checked)
                    tHealthCheck.Start();
                if (cbPing.Checked)
                    tPing.Start();
            }



        }

        private void rbPingAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Ping Task is already running...
                if (oPingTask.Status == TaskStatus.Running)
                {
                    return;
                }

                if (oPingTask.Status == TaskStatus.Canceled)
                {
                    ctHealth = new CancellationTokenSource();
                    ctPing = new CancellationTokenSource();
                    bChanges = true;
                }

                AnonymousDelegate updatecounts = delegate()
                {
                    try
                    {
                        lPingComp = computerBindingSource.Cast<Computer>().OrderByDescending(t => t.OnlineTimeStamp).ToList();

                        oPingTask = Task.Factory.StartNew(() => Parallel.ForEach(lPingComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxPingThreads }, dItem =>
                        {
                            try
                            {
                                if (dItem != null)
                                {
                                    if (dItem.ComputerName != null)
                                    {
                                        if (string.IsNullOrEmpty(FQDN))
                                            Ping_CollectionThread(dItem);
                                        else
                                        {
                                            if (!dItem.ComputerName.EndsWith(FQDN, StringComparison.CurrentCultureIgnoreCase) & !dItem.ComputerName.Contains("."))
                                                dItem.ComputerName = dItem.ComputerName + "." + FQDN;
                                            Ping_CollectionThread(dItem);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }), ctPing.Token);

                        //oPingTask.ContinueWith((t) => TasksComplete(dataGridView1, computerBindingSource));
                    }
                    catch { }
                };
                Invoke(updatecounts);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void rbPingOffline_Click(object sender, EventArgs e)
        {
            try
            {
                //Ping Task is already running...
                if (oPingTask.Status == TaskStatus.Running)
                {
                    return;
                }

                if (oPingTask.Status == TaskStatus.Canceled)
                {
                    ctHealth = new CancellationTokenSource();
                    ctPing = new CancellationTokenSource();
                    bChanges = true;
                }

                AnonymousDelegate updatecounts = delegate()
                {
                    try
                    {
                        lPingComp = computerBindingSource.Cast<Computer>().Where(x => x.OnlineStatus == 0).OrderByDescending(t => t.OnlineTimeStamp).ToList();

                        oPingTask = Task.Factory.StartNew(() => Parallel.ForEach(lPingComp, new ParallelOptions { MaxDegreeOfParallelism = iMaxPingThreads }, dItem =>
                        {
                            try
                            {
                                if (dItem != null)
                                {
                                    if (dItem.ComputerName != null)
                                    {
                                        if (string.IsNullOrEmpty(FQDN))
                                            Ping_CollectionThread(dItem);
                                        else
                                        {
                                            if (!dItem.ComputerName.EndsWith(FQDN, StringComparison.CurrentCultureIgnoreCase) & !dItem.ComputerName.Contains("."))
                                                dItem.ComputerName = dItem.ComputerName + "." + FQDN;
                                            Ping_CollectionThread(dItem);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }), ctPing.Token);

                        //oPingTask.ContinueWith((t) => TasksComplete(dataGridView1, computerBindingSource));
                    }
                    catch { }
                };
                Invoke(updatecounts);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void cbHealthCheck_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (!cbHealthCheck.Checked)
            {
                //ctHealth.Cancel();
                tHealthCheck.Enabled = false;
            }
            else
            {
                if (ctHealth.IsCancellationRequested)
                {
                    ctHealth = new CancellationTokenSource();
                }
                tHealthCheck.Enabled = true;
            }
        }

        private void rbStop_Click(object sender, EventArgs e)
        {
            try
            {
                cbPing.Checked = false;
                cbHealthCheck.Checked = false;
                cbHealthCheck_CheckBoxCheckChanged(sender, e);
                cbPing_CheckedChanged(sender, e);

                ctPing.Cancel();
                ctHealth.Cancel();

                //Stop all running activities
                oHealthTask.Wait(new TimeSpan(0, 0, 0, 10));

                if (oHealthTask.Status != TaskStatus.RanToCompletion)
                {
                    tHealthCheck.Stop();
                    oHealthTask = Task.Factory.StartNew(() => TasksComplete(null, null));
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void rbAddConsoleExtension_Click(object sender, EventArgs e)
        {
            CMHealthMon.Program.registerConsoleExtension();
        }

        private void rbRemoveConsoleExtension_Click(object sender, EventArgs e)
        {
            CMHealthMon.Program.unregisterConsoleExtension();
        }

        private void rbRemoveWarnings_Click(object sender, EventArgs e)
        {
            AnonymousDelegate updatecounts = delegate()
            {
                try
                {
                    computerBindingSource = new BindingSource(computerBindingSource.Cast<Computer>().Where(t => !t.Error).OrderBy(t => t.ComputerName).GroupBy(x => x.ComputerName).Select(y => y.First()).ToList(), "");
                    dataGridView1.DataSource = computerBindingSource;
                    dataGridView1.Invalidate();
                }
                catch { }
            };
            Invoke(updatecounts);
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rzander/cmcollctr");
        }

        private void rtb_MaxPingThreads_TextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                iMaxPingThreads = int.Parse(rtb_MaxPingThreads.TextBoxText);
            }
            catch { }
        }

        private void rtb_MaxCheckThreads_TextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                iMaxHealthThreads = int.Parse(rtb_MaxCheckThreads.TextBoxText);
            }
            catch { }
        }

        private void rtb_PingTimeout_TextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                iPingTimeout = int.Parse(rtb_PingTimeout.TextBoxText);
            }
            catch { }
        }

        private void rtb_DNSSuffix_TextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.FQDN = rtb_DNSSuffix.TextBoxText;
                FQDN = rtb_DNSSuffix.TextBoxText;
            }
            catch { }
        }

        private void rtb_WinRMPort_TextBoxTextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WinRMPort = rtb_WinRMPort.TextBoxText;
            try
            {
                WinRMPort = int.Parse(rtb_WinRMPort.TextBoxText);
            }
            catch { rtb_WinRMPort.TextBoxText = "5985"; }
        }

        private void rcb_WinRMSSL_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WinRMSSL = rcb_WinRMSSL.Checked;
            try
            {
                WinRMSSL = rcb_WinRMSSL.Checked;
            }
            catch { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void rtbUsername_TextBoxTextChanged(object sender, EventArgs e)
        {
            //sUsername = rtbUsername.TextBoxText;
        }

        private void rBPasswordManager_Click(object sender, EventArgs e)
        {
            PasswordManager PMForm = new PasswordManager();
            if (PMForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.PasswordManager = PMForm.XML;
                Properties.Settings.Default.Save();

                try
                {
                    PWManagerList = (PMForm.dataGridView1.DataSource as BindingSource).List.OfType<PasswordManager.PWList>().ToList();
                }
                catch { }

            }
        }
    }

    public static class extensionmethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static IEnumerable<T> OrderByField<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            string property = "";

            if (parts.Length > 0 && parts[0] != "")
            {
                property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }

                PropertyInfo prop = typeof(T).GetProperty(property);

                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                if (descending)
                    return list.OrderByDescending(x => prop.GetValue(x, null));
                else
                    return list.OrderBy(x => prop.GetValue(x, null));
            }

            return list;
        }
    }


    class DataGridViewImageCellBlank : DataGridViewImageCell
    {
        public DataGridViewImageCellBlank()
            : base()
        {
        } // constructor


        public DataGridViewImageCellBlank(bool valueIsIcon)
            : base(valueIsIcon)
        {
        } // constructor


        public override object DefaultNewRowValue
        {
            get
            {
                return null; // RETURNS NULL, INSTEAD OF THE 'RED X'
            }
        }
    }

    public class Computer : IDisposable
    {
        public Computer()
        { }

        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    HealthIcon = null;
                    HealthRebootIcon = null;
                    HealthUpdateMissingIcon = null;
                    HealthInstallationRunningIcon = null;
                    UsersLoggedOnIcon = null;

                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public byte[] HealthIcon { get; set; }
        public string SiteCode { get; set; }
        public string AgentVersion { get; set; }
        public int OnlineStatus { get; set; }
        public DateTime OnlineTimeStamp { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorTimeStamp { get; set; }
        public DateTime HealthTimeStamp { get; set; }
        public DateTime LastReboot { get; set; }
        public byte[] HealthRebootIcon { get; set; }
        public int HealthRebootStatus { get; set; }
        public string LastRebootDiff { get; set; }
        public byte[] HealthUpdateMissingIcon { get; set; }
        public byte[] HealthInstallationRunningIcon { get; set; }
        public string StatusMessage { get; set; }
        public bool UsersLoggedOnStatus { get; set; }
        public byte[] UsersLoggedOnIcon { get; set; }
        public bool HealthUpdateMissingStatus { get; set; }
        public bool HealthInstallationRunningStatus { get; set; }
    }
}
