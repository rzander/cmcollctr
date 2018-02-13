using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Management;
using System.IO;
//using Microsoft.ConfigurationManagement.AdminConsole;
//using Microsoft.ConfigurationManagement.ManagementProvider;
//using Microsoft.ConfigurationManagement.AdminConsole.Schema;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime;

namespace CMHealthMon
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            string sTitle = "Collection Commander";
            bool bName = false;

            foreach (string sArg in args)
            {
                if (sArg.StartsWith("/name:", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    sTitle = sArg.Substring(sArg.IndexOf(":") + 1);
                    bName = true;
                }

                if (string.Compare("/install", sArg, true) == 0)
                {
                    Console.Write("Register Console Extensions...");
                    registerConsoleExtension();
                    Console.WriteLine("..Done.");
                    return;
                }

                if (string.Compare("/uninstall", sArg, true) == 0)
                {
                    Console.Write("Unregister Etensions....");
                    unregisterConsoleExtension();
                    Console.WriteLine("...Done.");
                    return;
                }

                //From https://cmcollctr.codeplex.com/discussions/612941 by Mikesch
                // Usage: CMCollCtr /List:[COMPUTERNAME1],[COMPUTERNAME2],[COMPUTERNAME3]
                if (sArg.StartsWith("/List:", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    var computerList = sArg.Remove(0, 6).Split(',');

                    MainForm pForm = new MainForm();
                    pForm.Text = sTitle;
                    pForm.Show();
                    System.Threading.Thread.Sleep(200);

                    try
                    {
                        AnonymousDelegate clearbinding = delegate()
                        {
                            pForm.computerBindingSource.Clear();
                        };
                        pForm.Invoke(clearbinding);

                        foreach (var computerName in computerList)
                        {
                            AnonymousDelegate updatecounts = delegate()
                            {
                                pForm.computerBindingSource.AllowNew = true;
                                Computer oComp = new Computer()
                                {
                                    ComputerName = computerName
                                };
                                pForm.computerBindingSource.Add(oComp);
                            };
                            pForm.Invoke(updatecounts);
                        }

                        AnonymousDelegate updateBinding = delegate()
                        {
                            pForm.dataGridView1.DataSource = pForm.computerBindingSource;
                        };
                        pForm.Invoke(updateBinding);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                    Application.Run(pForm);
                }

                //From https://cmcollctr.codeplex.com/discussions/612941 by Mikesch
                // Usage: CMCollCtr /File:[Filename]
                if (sArg.StartsWith("/File:", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    var fileName = sArg.Remove(0, 6);

                    MainForm pForm = new MainForm();
                    pForm.Text = sTitle;
                    pForm.Show();
                    System.Threading.Thread.Sleep(200);

                    try
                    {
                        AnonymousDelegate clearbinding = delegate()
                        {
                            pForm.computerBindingSource.Clear();
                        };
                        pForm.Invoke(clearbinding);

                        var sr = new System.IO.StreamReader(fileName);
                        string computerName;
                        while ((computerName = sr.ReadLine()) != null)
                        {
                            AnonymousDelegate updatecounts = delegate()
                            {
                                pForm.computerBindingSource.AllowNew = true;
                                Computer oComp = new Computer()
                                {
                                    ComputerName = computerName
                                };
                                pForm.computerBindingSource.Add(oComp);
                            };
                            pForm.Invoke(updatecounts);
                        }
                        sr.Close();

                        AnonymousDelegate updateBinding = delegate()
                        {
                            pForm.dataGridView1.DataSource = pForm.computerBindingSource;
                        };
                        pForm.Invoke(updateBinding);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                    Application.Run(pForm);
                }

                //Obsolete
                /*
                if (sArg.StartsWith("/PW:", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    string sPW = sArg.Remove(0, 4);

                    Assembly asm = Assembly.GetExecutingAssembly();
                    var attribs = (asm.GetCustomAttributes(typeof(GuidAttribute), true));
                    var id = (attribs[0] as GuidAttribute).Value;
                    string sCode = sccmclictr.automation.common.Encrypt(sPW, id.ToString());
                    MessageBox.Show(sCode, "Password");
                    Console.WriteLine(sCode);

                    return;
                }*/

                if (sArg.StartsWith("/Path:", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    string sPath = sArg.Remove(0, 6);
                    string sQuery = "SELECT * FROM SMS_R_SYSTEM WHERE ResourceID in (SELECT ResourceID FROM SMS_CM_RES_COLL_" + sPath.Split('=')[1] + ")";
                    string sScope = sPath.Split(':')[0];

                    //MessageBox.Show(sArg);

                    MainForm pForm = new MainForm();
                    pForm.Text = sTitle;
                    pForm.Show();
                    System.Threading.Thread.Sleep(200);
                    
                    try
                    {
                        AnonymousDelegate clearbinding = delegate()
                        {
                            pForm.computerBindingSource.Clear();
                        };
                        pForm.Invoke(clearbinding);

                        foreach (ManagementObject MO in new ManagementObjectSearcher(sScope, sQuery).Get())
                        {
                            AnonymousDelegate updatecounts = delegate()
                            {
                                pForm.computerBindingSource.AllowNew = true;

                                Computer oComp = new Computer();
                                oComp.ComputerName = MO["Name"].ToString();
                                try
                                {
                                    oComp.ComputerName = ((string[])MO.Properties["ResourceNames"].Value)[0].ToString();
                                }
                                catch { }

                                pForm.computerBindingSource.Add(oComp);
                            };
                            pForm.Invoke(updatecounts);
                        }

                        AnonymousDelegate updateBinding = delegate()
                        {
                            pForm.dataGridView1.DataSource = pForm.computerBindingSource;
                        };
                        pForm.Invoke(updateBinding);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                    Application.Run(pForm);
                }
            }

            if (args.Length == 0 || (bName & args.Length == 1))
            {
                try
                {
                    MainForm pForm = new MainForm();
                    pForm.Text = sTitle;

                    Application.Run(pForm);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            e.ToString();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.ToString();
        }

        delegate void AnonymousDelegate();

        /// <summary>
        /// Create MMC Extension for SCCM
        /// </summary>
        public static void registerConsoleExtension()
        {
            //SCCM Console Installed ?
            string sArchitecture = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToLower();
            RegistryKey rAdminUI = null;
            switch (sArchitecture)
            {
                case "x86":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\ConfigMgr10\Setup");
                    break;
                case "amd64":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\Setup");
                    break;
                case "ia64":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\ConfigMgr10\Setup");
                    break;
            }

            if (rAdminUI != null)
            {
                string sUIPath = rAdminUI.GetValue("UI Installation Directory", "").ToString();
                if (Directory.Exists(sUIPath))
                {
                    Directory.CreateDirectory(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97");
                    TextWriter tw1 = new StreamWriter(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97\CMCollCtr.xml");
                    tw1.WriteLine(string.Format(Properties.Settings.Default.ConsoleExtension, System.Reflection.Assembly.GetExecutingAssembly().Location));
                    tw1.Close();

                    Directory.CreateDirectory(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b");
                    tw1 = new StreamWriter(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\CMCollCtr.xml");
                    tw1.WriteLine(string.Format(Properties.Settings.Default.ConsoleExtension, System.Reflection.Assembly.GetExecutingAssembly().Location));
                    tw1.Close();
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// Remove MMC Extension for SCCM
        /// </summary>
        public static void unregisterConsoleExtension()
        {
            string sArchitecture = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToLower();
            RegistryKey rAdminUI = null;
            switch (sArchitecture)
            {
                case "x86":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\ConfigMgr10\Setup");
                    break;
                case "amd64":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\Setup");
                    break;
                case "ia64":
                    rAdminUI = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\ConfigMgr10\Setup");
                    break;
            }

            //SCCM Console Installed ?
            if (rAdminUI != null)
            {
                string sUIPath = rAdminUI.GetValue("UI Installation Directory", "").ToString();
                
                if (File.Exists(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97\HealthMon.xml"))
                {
                    try
                    {
                        File.Delete(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97\HealthMon.xml");
                    }
                    catch { }
                }

                if (File.Exists(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97\CMCollCtr.xml"))
                {
                    try
                    {
                        File.Delete(sUIPath + @"\XmlStorage\Extensions\Actions\3785759b-db2c-414e-a540-e879497c6f97\CMCollCtr.xml");
                    }
                    catch { }
                }

                if (File.Exists(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\HealthMon.xml"))
                {
                    try
                    {
                        File.Delete(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\HealthMon.xml");
                    }
                    catch { }
                }

                if (File.Exists(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\CMCollCtr.xml"))
                {
                    try
                    {
                        File.Delete(sUIPath + @"\XmlStorage\Extensions\Actions\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\CMCollCtr.xml");
                    }
                    catch { }
                }
            }
            else
            {
                //SMS2003 Console ?
            }
        }

    }
}
