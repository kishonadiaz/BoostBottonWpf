using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Application = System.Windows.Application;
using ButtonBase = System.Windows.Controls.Primitives.ButtonBase;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;


namespace BoostBottonWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [System.Runtime.InteropServices.Guid("F12D9531-00BD-4F7B-9D5A-6D3B8E55C28A")]
    public partial class MainWindow : Window
    {
        public CloseConfirm d;
        public SettingsConfigs settingsConfigs;
        public Help help;
        bool closepressed = false;
        private String roming;
        private String filepath;
        private FileStream configfile;
        private JsonParser jsonParser;
        private StreamReader streamReader;
        private String line;
        PowerShellHelper powerShellHelper;
        NotifyIcon nIcon = new NotifyIcon();
        System.Diagnostics.ProcessStartInfo startInfo;
        System.Diagnostics.Process process;
        ButtonAutomationPeer boostBtnAutomate;


        List<dynamic> powerplanlist = new List<dynamic>();

        private List<String> guidList = new List<string>();
        private List<String> powerplannames = new List<string>();
        private String lastactiveguid = "";
        private String lastactivepowername = "";

        private String newActivePowerPlan = "";
        private String newLastPowerPlanname = "";

        private Thread idleThread;

        private Alarm alarm;

        private static bool ishelpinit = false;
        string curdir = System.Reflection.Assembly.GetEntryAssembly().Location;


        public Action<System.Activities.WorkflowApplicationIdleEventArgs> Idle { get; set; }

        public static System.Windows.Controls.Button MBoostBtn
        {
            get; set;
        }

        public static System.Windows.Controls.Button SButton
        {
            get; set;
        }
        public static MainWindow Main { get; set; }

        public static bool Startintray
        {
            get => startintray; set => startintray = value;
        }

        public static String Headers
        {
            get; set;
        }

        public static bool TrayMode
        {
            get; set;
        }

        public static bool IsActive
        {
            get; set;
        }

        public static bool isDialogOpen
        {
            get; set;
        }

        public static bool IsOn
        {
            get => isOn; set => isOn = value;
        }

        public static bool Notifcations
        {
            get => notifcations; set => notifcations = value;
        }

        public static bool Init
        {
            get => init; set => init = value;
        }
        public static bool Ishelpinit { get => ishelpinit; set => ishelpinit = value; }

        public ToastContent Toasting(String val, String powerMode)
        {

            ToastContent content = new ToastContent()
            {
                Launch = "BoostmodeToast",

                Visual = new ToastVisual()
                {

                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {

                            new AdaptiveText()
                            {
                                Text = "Boost Mode",
                                HintMaxLines = 1
                            },

                            new AdaptiveText()
                            {
                                Text = val
                            },

                            new AdaptiveText()
                            {
                                Text = powerMode
                            }
                        }
                    }

                },




            };



            var doc = new XmlDocument();


            doc.LoadXml(content.GetContent());




            var toast = new ToastNotification(doc);
            if (Notifcations)
                DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);



            return content;

        }

        public void ClickAction()
        {
            BoostBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        public ToastContent Toastbutons()
        {


            ToastContent content = new ToastContent()
            {
                Launch = "BoostmodeToast",

                Visual = new ToastVisual()
                {

                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {

                            new AdaptiveText()
                            {
                                Text = "Boost Mode",
                                HintMaxLines = 1
                            },

                            new AdaptiveText()
                            {
                                Text = "Change BoostMode"
                            }


                        }
                    }

                },

                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("BoostMode On", "On")
                        {
                            ActivationType = ToastActivationType.Background,
                            ImageUri = new Uri("pack://application:,,,/assets/powerbtnon.png").LocalPath.ToString()
                        },
                        new ToastButton("BoostMode Off", "Off")
                        {
                            ActivationType = ToastActivationType.Background,
                            ImageUri = new Uri("pack://application:,,,/assets/powerbtnoff.png").LocalPath.ToString()
                        },
                        new ToastButton("BoostMode Close", "Close")
                        {
                            ActivationType = ToastActivationType.Background,
                            ImageUri = new Uri("pack://application:,,,/assets/powerbtnoff.png").LocalPath.ToString()
                        }
                    }
                }




            };



            var doc = new XmlDocument();


            doc.LoadXml(content.GetContent());




            var toast = new ToastNotification(doc);

            if (Notifcations)
                DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);




            return content;

        }






        public MainWindow()
        {


            InitializeComponent();

            MBoostBtn = BoostBtn;
            SButton = settingbtn;
            Main = this;

            boostBtnAutomate = new ButtonAutomationPeer(BoostBtn);
   
            jsonParser = new JsonParser();

            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++){ 

                    if (i <= 6){
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);


            var local = String.Join("/", toLocalHost) + "/config.json";

            jsonParser.Load();



            Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/assets/black_hole_icon_149792.ico")).Stream;
           

            nIcon.Icon = new System.Drawing.Icon(iconStream);

            nIcon.MouseDoubleClick += NIcon_MouseDoubleClick;

            nIcon.MouseClick += NIcon_MouseClick;


            powerShellHelper = new PowerShellHelper();
            powerShellHelper.Add(
                new System.Management.Automation.Runspaces.SessionStateVariableEntry(
                    "test1",
                    "Myvar1",
                    "Initial session state Myvar1 test"));
            powerShellHelper.Add(
                new System.Management.Automation.Runspaces.SessionStateVariableEntry(
                    "test2",
                    "Myvar2",
                    "Initial session state Myvar2 test"));
            powerShellHelper.RsOpen();


            powerShellHelper.CreatePowerShell();

            

            Theadeaaction theadeaaction = new Theadeaaction(new List<object>() { this, boostbtnWIndow });

            idleThread = new Thread(theadeaaction.idle);


                       
            Init = jsonParser.Get[jsonParser.Count["\"init\""] - 1];
            TrayMode = jsonParser.Get[jsonParser.Count["\"traymode\""] - 1];
            Startintray = jsonParser.Get[jsonParser.Count["\"startintray\""] - 1];


            if (!Init)
            {
                if (Startintray)
                {
                    this.WindowState = WindowState.Minimized;
                    Hide();
                    nIcon.Visible = true;
                }
            }
            idleThread.Start();





        }

        private void NIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (((MouseButtons)e.Button) == System.Windows.Forms.MouseButtons.Right)
            {
                Toastbutons();
            }
        }

        class Theadeaaction
        {

            bool isfocus = false;

            List<object> args;
            JsonParser jsonParser;
            public Theadeaaction(List<Object> s)
            {
                args = s;
                jsonParser = new JsonParser();

                jsonParser.Load();
            }

            DispatcherTimer dispatcherTime = new DispatcherTimer();
            int MinuteMicroseconds = 20000;



            //https://stackoverflow.com/questions/23286766/idle-detection-in-wpf

            public void idle()
            {




                dispatcherTime.Interval = System.TimeSpan.FromMilliseconds(MinuteMicroseconds);    // One minute; change as needed
                dispatcherTime.Tick += TimeDone;
                dispatcherTime.Start();
                dispatcherTime.IsEnabled = IsActive;


                var Timer = new DispatcherTimer(TimeSpan.FromMilliseconds(30000),
                    DispatcherPriority.ApplicationIdle,
                    (s, e) => { running(); },
                    Application.Current.Dispatcher);




            }

            private void running()
            {

                //jsonParser.Update();
                dispatcherTime.IsEnabled = IsActive;

                if (!dispatcherTime.IsEnabled)
                    dispatcherTime.Start();
            }

            private void TimeDone(object sender, EventArgs e)
            {
                DispatcherPriority priority = DispatcherPriority.ApplicationIdle;
                dispatcherTime.Stop();

                jsonParser.Update();
                Ishelpinit = jsonParser.Get[jsonParser.Count["\"helpinit\""] - 1];
                TrayMode = jsonParser.Get[jsonParser.Count["\"traymode\""] - 1];
                Startintray = jsonParser.Get[jsonParser.Count["\"startintray\""] - 1];

                //MessageBox.Show(jsonParser.Get[jsonParser.Count["\"traymode\""] - 1]);

                System.Action action = new System.Action(delegate ()
                {

                    ////Console.WriteLine("Idle");
                    if ((args[0] as MainWindow).d != null)
                    {
                        if ((args[0] as MainWindow).d.IsOpen)
                            IsActive = (args[0] as MainWindow).d.IsOpen;
                        else
                            IsActive = false;
                    }

                    if ((args[0] as MainWindow).settingsConfigs != null)
                    {
                        if ((args[0] as MainWindow).settingsConfigs.IsOpen)
                            IsActive = (args[0] as MainWindow).settingsConfigs.IsOpen;
                        else
                            IsActive = false;
                    }




                    if (!IsActive)
                    {


                        if (Startintray)
                        {
                            TrayMode = Startintray;
                            //jsonParser.changeIndex("traymode", true);
                            jsonParser.Save("traymode",true);
                        }

                        if (!TrayMode)
                        {
                            (args[1] as MainWindow).WindowState = WindowState.Minimized;

                        }
                        else
                        {
                            (args[0] as MainWindow).Hide();
                            (args[0] as MainWindow).nIcon.Visible = true;
                            /*nIcon.ShowBalloonTip(10, "Boost Mode", "App in tray", ToolTipIcon.Info);*/
                        }

                    }


                });





                if (!Ishelpinit)
                {

                    Application.Current.Dispatcher.BeginInvoke(priority, action);

                }


            }



        }

        private void NIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            this.WindowState = WindowState.Normal;
            nIcon.Visible = false;
        }

        /*                                 Title Stuff                                            */
        private Point lastloc;
        private Point startPoint;

        int magx = 0;
        int magy = 0;
        Point newloc;
        double lastx = 0;
        double currentx = 0;
        double lastedmoveX = 0;
        double lastedmoveY = 0;
        private static bool isOn;
        private static bool notifcations;
        private static bool init;
        private static bool startintray;

        private void TitleBar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastx = Left;

                if ((lastloc.X - Mouse.GetPosition(TitleBar).X > -1))
                {
                    magx = -1;

                }
                else
                if ((lastloc.X - Mouse.GetPosition(TitleBar).X < -1))
                {
                    magx = 1;

                }

                if ((lastloc.Y - Mouse.GetPosition(TitleBar).Y > -1))
                {
                    magy = -1;

                }
                else
                if ((lastloc.Y - Mouse.GetPosition(TitleBar).Y < -1))
                {
                    magy = 1;

                }


                Point diff = (Point)Point.Subtract(Mouse.GetPosition(this), new Point(lastloc.X, lastloc.Y));
                Left += (magx + diff.X + 1.5);
                Top += (magy + diff.Y + 1.5);

                lastedmoveX = Left;
                lastedmoveY = Top;



                currentx = Left;


                if (e.GetPosition(TitleBar).X != e.GetPosition(TitleBar).X)
                {

                }



                Point position = e.GetPosition(this);


            }

        }

        private void TitleBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (moving.IsChecked == true)
            {
                moving.IsChecked = false;
            }


        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lastloc = Mouse.GetPosition(this);
            startPoint = e.GetPosition(null);
            if (moving.IsChecked == false)
            {
                moving.IsChecked = true;
            }

        }
        private void TitleBar_MouseLeave(object sender, MouseEventArgs e)
        {
            TitleBar.Effect = (this.Resources["TitleblurEffect"] as BlurEffect);
            TitleBar.Opacity = .4;

        }
        private void TitleBar_MouseEnter(object sender, MouseEventArgs e)
        {
            TitleBar.Effect = (this.Resources["TitleblurReset"] as BlurEffect);
            TitleBar.Opacity = 1;
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            jsonParser = new JsonParser();


            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            
            var local = String.Join("/", toLocalHost) + "/config.json";
            jsonParser.Load();
       


            if (!jsonParser.Get[jsonParser.Count["\"allwayclose\""] - 1])
            {
                d = new CloseConfirm();
                d.Left = lastedmoveX;
                d.Top = lastedmoveY;
                d.Main = this;
                d.ShowDialog();
                IsActive = d.IsOpen;

                if (d.DialogResult == true)
                {
                    d.Close();
                    this.Close();
                    nIcon.Dispose();
                    Application.Current.Shutdown();
                    closepressed = true;
                }
            }
            else
            {
                this.Close();
                nIcon.Dispose();
                Application.Current.Shutdown();
                closepressed = true;
            }

        }



        private void minamize_Click(object sender, RoutedEventArgs e)
        {
            jsonParser.Load();
            TrayMode = jsonParser.Get[jsonParser.Count["\"traymode\""] - 1];


            this.WindowState = WindowState.Minimized;
            if (TrayMode)
            {
                Hide();
                nIcon.Visible = true;
                //nIcon.ShowBalloonTip(10, "Boost Mode", "App in tray", ToolTipIcon.Info);
            }
        }

        /*                          End Titlebar Stuff                                          */

        /*                          BoostBtn Stuff                                              */


        private void BoostBtn_MouseEnter(object sender, MouseEventArgs e)
        {

            if (Button_pressedCheck.IsChecked == true)
            {
                IsOn = true;
                BoostBtn.Background = (this.Resources["Boostbtnon"] as ImageBrush);
            }
            else
            {
                IsOn = false;
                BoostBtn.Background = (this.Resources["Boostbtnhover"] as ImageBrush);
            }

            TitleBar.Effect = (this.Resources["TitleblurReset"] as BlurEffect);
            TitleBar.Opacity = 1;
        }




        private void BoostBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Button_pressedCheck.IsChecked == false)
            {
                DesktopNotificationManagerCompat.History.Clear();
                BoostBtn.Background = (this.Resources["Boostbtnon"] as ImageBrush);


                Button_pressedCheck.IsChecked = true;


                if (lastactivepowername != "Ultimate Performance" || newActivePowerPlan != "Ultimate Performance")
                {
                    for (int i = 0; i < powerplannames.Count; i++)
                    {
                        //Console.WriteLine(powerplannames[i]);
                        if (powerplannames[i] == "Ultimate Performance")
                        {
                            newActivePowerPlan = guidList[i];
                            newLastPowerPlanname = powerplannames[i];

                        }
                    }


                    powerShellHelper.Clear();





                    startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"cmd.exe";
                    startInfo.Arguments = @"/C powercfg -s " + newActivePowerPlan;
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process = new System.Diagnostics.Process();
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();



                    Toasting("You have changed your power plan", newLastPowerPlanname);

                }



            }
            else
            if (Button_pressedCheck.IsChecked == true)
            {
                DesktopNotificationManagerCompat.History.Clear();
                BoostBtn.Background = (this.Resources["Boostbtnoff"] as ImageBrush);

                Button_pressedCheck.IsChecked = false;


                if (newLastPowerPlanname == "Ultimate Performance")
                {
                    if (lastactivepowername == "Ultimate Performance")
                    {

                        powerShellHelper.AysncAddCommand("powercfg", "List");

                        powerShellHelper.AysncSynchronousPipline();


                        foreach (dynamic d in powerShellHelper.Output)
                        {

                            if (ConvertToPowerPlanName(d.ToString()) == "Balanced")
                            {
                                lastactiveguid = ConvertToGUID(d.ToString());
                                lastactivepowername = ConvertToPowerPlanName(d.ToString());
                            }


                        }

                        powerShellHelper.Clear();
                    }


                    startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"cmd.exe";
                    startInfo.Arguments = @"/C powercfg -s " + lastactiveguid;
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process = new System.Diagnostics.Process();
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();



                    Toasting("You have changed your power plan", lastactivepowername);

                    newLastPowerPlanname = lastactivepowername;
                }



            }
        }



        private void BoostBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Button_pressedCheck.IsChecked == true)
            {

                BoostBtn.Background = (this.Resources["Boostbtnon"] as ImageBrush);
            }
            else
            {
                BoostBtn.Background = (this.Resources["Boostbtnoff"] as ImageBrush);
            }
            TitleBar.Effect = (this.Resources["TitleblurEffect"] as BlurEffect);
            TitleBar.Opacity = .4;
        }

        private void BoostBtnWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {


            //this.Close();

        }
        private void BoostBtnWin_Closed(object sender, EventArgs e)
        {
            idleThread.Abort();
            this.Close();
            Application.Current.Shutdown();



        }

        private void Button_pressedCheck_Checked(object sender, RoutedEventArgs e)
        {

            if (closepressed)
            {
                this.Close();

            }

        }


        /*                                 End of BoostBtn stuff                             */

        /*                                  Window Stuff                                     */

        private void BoostBtnWin_MouseMove(object sender, MouseEventArgs e)
        {
            IsActive = true;
        }



        private void BoostBtnWin_MouseLeave(object sender, MouseEventArgs e)
        {
            IsActive = false;
        }
        private void BoostBtnWin_MouseEnter(object sender, MouseEventArgs e)
        {
            IsActive = true;
        }

        /*                              Other Stuff                                          */

        protected override void OnIsMouseDirectlyOverChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsMouseDirectlyOverChanged(e);

        }


        public static void openConfig()
        {
            SettingsConfigs settingsConfigs = new SettingsConfigs();
            settingsConfigs.ShowDialog();
        }

        private void Settingbtn_Click(object sender, RoutedEventArgs e)
        {
            settingsConfigs = new SettingsConfigs();
            settingsConfigs.Left = lastedmoveX + 10;
            settingsConfigs.Top = lastedmoveY - 10;
            settingsConfigs.Main = this;
            settingsConfigs.ShowDialog();
            TrayMode = settingsConfigs.TrayMode;
            IsActive = settingsConfigs.IsOpen;

            IsActive = true;
        }

        private void Settingbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            settingbtn.Effect = (this.Resources["TitleblurReset"] as BlurEffect);
            settingbtn.Opacity = 1;
            Setting_BtnPanel.Opacity = 1;

            IsActive = true;
        }

        private void Settingbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            settingbtn.Effect = (this.Resources["TitleblurEffect"] as BlurEffect);
            settingbtn.Opacity = .1;
            Setting_BtnPanel.Opacity = .2;
        }

        private void BoostbtnWin_SizeChange(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {


            }

        }

        private String ConvertToPowerPlanName(String s)
        {

            if (s.Contains(":"))
                return s.Split(':')[1].Split('(')[1].Split(')')[0].ToString();
            return null;
        }

        private String ConvertToGUID(String s)
        {

            if (s.Contains(":"))
                return s.Split(':')[1].Split('(')[0].ToString();
            return null;
        }
        private String GUIDbyName(String guid)
        {

            if (guid.Contains(":"))
            {
                string s = ConvertToPowerPlanName(guid);
                if (guid.Contains(s))
                    return guid.Split(':')[1].Split('(')[0].ToString();
            }
            return null;
        }

        private void BoostbtnWin_Load(object sender, RoutedEventArgs e)
        {



            if (Init)
            {

                jsonParser.changeIndex("init", false);
                Thread.Sleep(1);
                jsonParser.Save();
                
                Help h = new Help();
                h.Left = lastedmoveX;
                h.Top = lastedmoveY;
                h.ShowDialog();



            }

            powerShellHelper.AysncAddCommand("powercfg", "list");

            powerShellHelper.AysncSynchronousPipline();

            powerplanlist = powerShellHelper.Output;
            powerplanlist.ForEach(delegate (dynamic item)
            {

                if (item.ToString() != "" || item.ToString() != " ")
                {
                    guidList.Add(GUIDbyName(item.ToString()));

                    powerplannames.Add(ConvertToPowerPlanName(item.ToString()));


                }


            });

            powerShellHelper.Clear();


            List<string> hasUlt = new List<string>();

            foreach (var i in powerplannames)
            {
                if (i == "Ultimate Performance")
                {

                    hasUlt.Add(i);
                }

            }




            if (hasUlt.Count <= 0)
            {
                startInfo = new ProcessStartInfo();
                startInfo.FileName = @"cmd.exe";
                startInfo.Arguments = @"/C powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process = new System.Diagnostics.Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }

            hasUlt.Remove("Ultimate Performance");

            powerShellHelper.AysncAddCommand("powercfg", "list");

            powerShellHelper.AysncSynchronousPipline();

            powerplanlist = powerShellHelper.Output;
            powerplanlist.ForEach(delegate (dynamic item)
            {
                if (item.ToString() != "" || item.ToString() != " ")
                {

                    if (ConvertToPowerPlanName(item.ToString()) == "Ultimate Performance")
                    {
                        hasUlt.Add(ConvertToPowerPlanName(item.ToString()));

                    }

                }
            });

            if (hasUlt.Count <= 0)
            {
                MessageBox.Show("There was an error please contact Me!");
            }


            powerShellHelper.Clear();


            powerShellHelper.AysncSynchronousPipline();
            List<string> pname = new List<string>();
            pname = powerplannames.Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();

            List<string> pguid = new List<string>();
            pguid = guidList.Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();

         
            powerplannames = pname;
            guidList = pguid;

            powerShellHelper.Clear();

            powerShellHelper.AysncAddCommand("powercfg", "GETACTIVEScheme");

            powerShellHelper.AysncSynchronousPipline();

            foreach (dynamic d in powerShellHelper.Output)
            {
                lastactiveguid = ConvertToGUID(d.ToString());
                lastactivepowername = ConvertToPowerPlanName(d.ToString());

            }

            alarm = new Alarm(this);

            Notifcations = jsonParser.Get[jsonParser.Count["\"notifications\""] - 1];

        }

        private void BoostbtnWin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (settingsConfigs != null || d != null)
            {

                IsActive = false;
            }
        }

        private void Helpbtn_Click(object sender, RoutedEventArgs e)
        {
            help = new Help();
            help.Left = lastedmoveX;
            help.Top = lastedmoveY;
            help.ShowDialog();

        }
    }



}
