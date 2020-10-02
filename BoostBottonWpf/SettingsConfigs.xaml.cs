using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace BoostBottonWpf
{

    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public Dictionary<String, Object> da;

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }




        // Should also override == and != operators.
    }
    /// <summary>
    /// Interaction logic for SettingsConfigs.xaml
    /// </summary>
    public partial class SettingsConfigs : Window
    {
        private const int TIMEINPUTWIDTH = 131;
        private const int TIMEBOXHEIGHT = 56;
        String roming;
        String filepath;
        FileStream configfile;
        StreamReader streamReader;
        String line;
        List<String> json;
        List<String> jsonout;
        JsonParser jsonParser;
        TimerConverter startConverter = null;
        TimerConverter endConverter = null;
        string curdir = System.Reflection.Assembly.GetEntryAssembly().Location;



        bool isopen = false;
        bool istimeboxopen = false;
        bool istimeinptsopen = false;
        bool timeron = false;

        bool hasstarttimer = false;

        bool hasendttimer = false;

        bool isstartintray = false;

        bool isInit = true;

        public bool TrayMode
        {
            get; set;
        }

        public bool IsOpen
        {
            get { return isopen; }
            set { isopen = value; }
        }

        public MainWindow Main { get; set; }
        public bool Timeron { get => timeron; set => timeron = value; }
        public bool Hasendttimer { get => hasendttimer; set => hasendttimer = value; }
        public bool Hasstarttimer { get => hasstarttimer; set => hasstarttimer = value; }
        public bool Isstartintray { get => isstartintray; set => isstartintray = value; }
        public bool IsInit { get => isInit; set => isInit = value; }

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

            if (MainWindow.Notifcations)
                DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);



            return content;

        }

        public void setAlarmOnorOff(bool ison)
        {
            if (this.IsActive)
            {
                if (ison)
                    timebox.Visibility = Visibility.Visible;
                else
                    timebox.Visibility = Visibility.Collapsed;
            }
        }

        public void settimeinputOfforOn(String startorend, bool onoroff)
        {
            if (this.IsActive)
            {
                if (startorend == "start" || startorend == "Start")
                {
                    if (!onoroff)
                    {
                        startgridblureffect.Radius = 5;
                        starttimefaderec.IsEnabled = true;
                        starttimefaderec.Opacity = .5;
                        starttimefaderec.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        startgridblureffect.Radius = 0;
                        starttimefaderec.IsEnabled = false;
                        starttimefaderec.Opacity = 0;
                        starttimefaderec.Visibility = Visibility.Collapsed;

                    }


                }

                if (startorend == "end" || startorend == "End")
                {
                    if (!onoroff)
                    {
                        endgridblureffect.Radius = 5;
                        endfadeoffbec.IsEnabled = true;
                        endfadeoffbec.Opacity = .5;
                        endfadeoffbec.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        endgridblureffect.Radius = 0;
                        endfadeoffbec.IsEnabled = false;
                        endfadeoffbec.Opacity = 0;
                        endfadeoffbec.Visibility = Visibility.Collapsed;
                    }
                }
            }

        }


        public SettingsConfigs()
        {
            InitializeComponent();




            ItemsControl items = new ItemsControl();





            List<ComboBoxItem> starthourcomboBoxes = new List<ComboBoxItem>();
            List<ComboBoxItem> endhourcomboBoxes = new List<ComboBoxItem>();
            List<ComboBoxItem> startmincomboBoxes = new List<ComboBoxItem>();
            List<ComboBoxItem> endmincomboBoxes = new List<ComboBoxItem>();


            List<int> hourcount = new List<int>();
            List<int> mincount = new List<int>();





            for (int i = 12; i >= 1; --i)
            {
                hourcount.Add(i);

                starthourcomboBoxes.Add(new ComboBoxItem());
                endhourcomboBoxes.Add(new ComboBoxItem());


            }
            for (int i = 00; i <= 59; ++i)
            {
                mincount.Add(i);

                startmincomboBoxes.Add(new ComboBoxItem());
                endmincomboBoxes.Add(new ComboBoxItem());


            }
            //String.Format("{0:0.00}", obj);

            int herecount = 0;
            foreach (var i in hourcount)
            {
                starthourcomboBoxes[herecount].Content = i;
                endhourcomboBoxes[herecount].Content = i;
                starthour.Items.Add(starthourcomboBoxes[herecount]);
                endhour.Items.Add(endhourcomboBoxes[herecount]);

                ++herecount;
            }

            int thiscount = 0;
            foreach (var i in mincount)
            {
                startmincomboBoxes[thiscount].Content = String.Format("{0:00}", i);
                endmincomboBoxes[thiscount].Content = String.Format("{0:00}", i);

                startmin.Items.Add(startmincomboBoxes[thiscount]);
                endmin.Items.Add(endmincomboBoxes[thiscount]);

                ++thiscount;
            }


            starthour.SelectedIndex = 0;
            endhour.SelectedIndex = 0;
            startmin.SelectedIndex = 0;
            endmin.SelectedIndex = 0;



            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();

            jsonParser = new JsonParser();

            IsOpen = true;


            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
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
            //MessageBox.Show(s);
            var local = String.Join("/", toLocalHost) + "/config.json";
            jsonParser.Load();
  


            if (jsonParser.Get[jsonParser.Count[Traymode.Uid] - 1])
            {
                Traymode.IsChecked = jsonParser.Get[jsonParser.Count[Traymode.Uid] - 1];

                TrayMode = Traymode.IsEnabled;
            }
            else
            {
                Traymode.IsChecked = jsonParser.Get[jsonParser.Count[Traymode.Uid] - 1];
            }

            Console.WriteLine(jsonParser.Get[jsonParser.Count[DialogClosecheck.Uid] - 1]);

            if (jsonParser.Get[jsonParser.Count[DialogClosecheck.Uid] - 1])
            {
                DialogClosecheck.IsChecked = jsonParser.Get[jsonParser.Count[DialogClosecheck.Uid] - 1];
            }
            else
            {
                DialogClosecheck.IsChecked = jsonParser.Get[jsonParser.Count[DialogClosecheck.Uid] - 1];
            }



        }

        private void Startintray_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(jsonParser.Get[jsonParser.Count[Traymode.Uid] - 1]);
            if (Traymode.IsChecked == true)
            {
                jsonParser.changeIndex("traymode", true);

            }
            else
            {
                jsonParser.changeIndex("traymode", false);
            }
            //jsonParser.jsonbuilder();
        }

        private void DialogClosecheck_Checked(object sender, RoutedEventArgs e)
        {

            if (DialogClosecheck.IsChecked == true)
            {
                jsonParser.changeIndex("allwayclose", true);

            }
            else
            {
                jsonParser.changeIndex("allwayclose", false);
            }
            //jsonParser.jsonbuilder();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            DesktopNotificationManagerCompat.History.Clear();

            //MessageBox.Show(startConverter.Outstring);
            SaveTime("starttime", startConverter);
            SaveTime("endtime", endConverter);
            Thread.Sleep(1);
            jsonParser.Save();

            Toasting("You Just Changed your configurations", "Settings Saved");


            this.Close();




        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }

        private void SettingWin_Close(object sender, EventArgs e)
        {
            ThreadAction threadAction = new ThreadAction(new List<object>() { this });
            Thread thread = new Thread(new ThreadStart(threadAction.clearToast));


        }

        private void SettingWin_Activated(object sender, EventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;

        }

        private void SettingWin_MouseEntered(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;
        }

        private void SettingWin_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsOpen = false;
            MainWindow.IsActive = false;

        }
        private void SettingWin_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;
        }

        private void StartTimer_Checked(object sender, RoutedEventArgs e)
        {

            if ((sender as CheckBox).IsChecked == true)
            {
                setAlarmOnorOff(true);
                if (this.IsActive)
                    jsonParser.changeIndex("timeron", true);
            }
            else if ((sender as CheckBox).IsChecked == false)
            {
                setAlarmOnorOff(false);
                if (this.IsActive)
                    jsonParser.changeIndex("timeron", false);
            }
        }


        private void StartTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                settimeinputOfforOn("start", true);
                if (this.IsActive)
                    jsonParser.changeIndex("hasstarttimer", true);
            }
            else
            {
                settimeinputOfforOn("start", false);
                if (this.IsActive)
                    jsonParser.changeIndex("hasstarttimer", false);
            }
        }

        private void EndTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                settimeinputOfforOn("end", true);
                if (this.IsActive)
                    jsonParser.changeIndex("hasendtimer", true);
            }
            else
            {
                settimeinputOfforOn("end", false);
                if (this.IsActive)
                    jsonParser.changeIndex("hasendtimer", false);
            }

        }

        private void SaveTime(String key, TimerConverter timerconvert)
        {
            if (timerconvert != null)
            {
                if (timerconvert.Outstring != "")
                    jsonParser.changeIndex(key, timerconvert.Outstring);
            }
        }

        private int gettimerinputindex(ComboBox ob, String compare)
        {
            int index = 0;
            if (ob != null)
            {
                for (int i = 0; i < ob.Items.Count; i++)
                {
                    if ((ob.Items[i] as ComboBoxItem).Content.ToString() == compare)
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;

        }
        private void SettingWin_Load(object sender, RoutedEventArgs e)
        {
            IsInit = jsonParser.Get[jsonParser.Count["\"configinit\""] - 1];
            Timeron = jsonParser.Get[jsonParser.Count["\"timeron\""] - 1];
            Hasstarttimer = jsonParser.Get[jsonParser.Count["\"hasstarttimer\""] - 1];
            Hasendttimer = jsonParser.Get[jsonParser.Count["\"hasendtimer\""] - 1];

            Isstartintray = jsonParser.Get[jsonParser.Count["\"startintray\""] - 1];
            MainWindow.Notifcations = jsonParser.Get[jsonParser.Count["\"notifications\""] - 1];



            Notifications.IsChecked = MainWindow.Notifcations;

            startConverter = new TimerConverter(jsonParser.Get[jsonParser.Count["\"starttime\""] - 1]);
            endConverter = new TimerConverter(jsonParser.Get[jsonParser.Count["\"endtime\""] - 1]);




            if (Isstartintray)
            {
                startintray.IsChecked = true;
            }
            else
            {
                startintray.IsChecked = false;
            }

            if (IsInit)
            {
                StartTimer.IsChecked = true;
                StartTimeCheckBox.IsChecked = true;
                EndTimeCheckBox.IsChecked = true;
                jsonParser.changeIndex("configinit", false);
                jsonParser.changeIndex("starttime", "9:00 AM");
                jsonParser.changeIndex("endtime", "6:30 PM");
                starthour.SelectedIndex = gettimerinputindex(starthour, "9");
                startmin.SelectedIndex = gettimerinputindex(startmin, "00");
                StartAmPm.SelectedIndex = gettimerinputindex(StartAmPm, "AM");
                endhour.SelectedIndex = gettimerinputindex(endhour, "6");
                endmin.SelectedIndex = gettimerinputindex(endmin, "30");
                EndAmPm.SelectedIndex = gettimerinputindex(EndAmPm, "PM");
                Thread.Sleep(1);
                jsonParser.Save();

            }
            else
            {
                StartTimer.IsChecked = Timeron;
                if (StartTimer.IsChecked == true)
                {
                    setAlarmOnorOff(true);



                    StartTimeCheckBox.IsChecked = Hasstarttimer;
                    EndTimeCheckBox.IsChecked = Hasendttimer;

                    for (int i = 0; i < starthour.Items.Count; i++)
                    {

                        if ((starthour.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((starthour.Items[i] as ComboBoxItem).Content.ToString() == startConverter.Hour)
                            {
                                //Console.WriteLine((starthour.Items[i] as ComboBoxItem).Content+" "+ i);
                                starthour.SelectedIndex = i;

                            }
                        }
                    }

                    for (int i = 0; i < startmin.Items.Count; i++)
                    {

                        if ((startmin.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((startmin.Items[i] as ComboBoxItem).Content.ToString() == startConverter.Min)
                            {
                                //Console.WriteLine((startmin.Items[i] as ComboBoxItem).Content+" "+ i);
                                startmin.SelectedIndex = i;

                            }
                        }
                    }

                    for (int i = 0; i < StartAmPm.Items.Count; i++)
                    {

                        if ((StartAmPm.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((StartAmPm.Items[i] as ComboBoxItem).Content.ToString() == startConverter.Ampm)
                            {
                                //Console.WriteLine((startmin.Items[i] as ComboBoxItem).Content + " " + i);
                                StartAmPm.SelectedIndex = i;

                            }
                        }
                    }

                    for (int i = 0; i < endhour.Items.Count; i++)
                    {

                        if ((endhour.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((endhour.Items[i] as ComboBoxItem).Content.ToString() == endConverter.Hour)
                            {
                                //Console.WriteLine((endhour.Items[i] as ComboBoxItem).Content+" "+ i);
                                endhour.SelectedIndex = i;

                            }
                        }
                    }

                    for (int i = 0; i < endmin.Items.Count; i++)
                    {

                        if ((endmin.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((endmin.Items[i] as ComboBoxItem).Content.ToString() == endConverter.Min)
                            {
                                //Console.WriteLine((endmin.Items[i] as ComboBoxItem).Content + " " + i);
                                endmin.SelectedIndex = i;

                            }
                        }
                    }

                    for (int i = 0; i < EndAmPm.Items.Count; i++)
                    {

                        if ((EndAmPm.Items[i] as ComboBoxItem).Content != null)
                        {
                            //MessageBox.Show(((starthour.Items[i] as ComboBoxItem).Content is String)+" "+ (startConverter.Hour is String));
                            if ((EndAmPm.Items[i] as ComboBoxItem).Content.ToString() == endConverter.Ampm)
                            {
                                //Console.WriteLine((EndAmPm.Items[i] as ComboBoxItem).Content + " " + i);
                                EndAmPm.SelectedIndex = i;

                            }
                        }
                    }

                }
                else
                {
                    setAlarmOnorOff(false);
                }
            }



        }

        private void starthour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (startConverter != null)
            {
                startConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "h");
            }


        }

        private void startmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (startConverter != null)
            {
                startConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "m");
            }
        }



        private void endhour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (endConverter != null)
            {
                endConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "h");
            }
        }

        private void endmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (endConverter != null)
            {
                endConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "m");
            }
        }

        private void StartAmPm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (startConverter != null)
            {
                startConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "tt");
            }
        }

        private void EndAmPm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ComboBox).SelectedItem);
            if (endConverter != null)
            {
                endConverter.timeBuilder(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString(), "tt");
            }
        }

        private void startintray_Checked_1(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                jsonParser.changeIndex("startintray", true);
            }
            else
            {
                jsonParser.changeIndex("startintray", false);

            }

        }

        private void Notifications_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                jsonParser.changeIndex("notifications", true);
            }
            else
            {
                jsonParser.changeIndex("notifications", false);

            }

        }
    }

    class ThreadAction
    {
        List<object> args;
        public ThreadAction(List<object> s)
        {
            args = s;
        }
        public void clearToast()
        {
            DispatcherPriority priority = DispatcherPriority.ApplicationIdle;
            System.Action action = new System.Action(delegate ()
            {

                /* //Console.WriteLine("Idle");
                 (args[1] as MainWindow).WindowState = WindowState.Minimized;*/
                Thread.Sleep(3000);
                DesktopNotificationManagerCompat.History.Clear();


            });
            Application.Current.Dispatcher.BeginInvoke(priority, action);

        }

        internal void resetsave()
        {
            throw new NotImplementedException();
        }
    }

    class TimerConverter
    {
        private string hour = "";
        private string min = "";
        private string ampm = "";
        private string outstring = "";

        public string Hour { get => hour; set => hour = value; }
        public string Min { get => min; set => min = value; }
        public string Ampm { get => ampm; set => ampm = value; }
        public string Outstring { get => outstring; set => outstring = value; }

        public TimerConverter(string val)
        {
            List<String> convert = new List<string>();
            List<String> convertpm = new List<string>();

            Console.WriteLine(val);
            if (val.Contains(":"))
            {
                convert = val.Split(':').ToList<string>();

            }

            if (convert[1].Contains("AM") ||
               convert[1].Contains("Am") ||
               convert[1].Contains("am") ||
               convert[1].Contains("PM") ||
               convert[1].Contains("Pm") ||
               convert[1].Contains("pm"))
            {
                convertpm = convert[1].Split(' ').ToList<string>();


                convert[1] = convertpm[0];
                convert.Add(convertpm[1]);
            }

            Hour = convert[0];
            Min = convert[1];
            Ampm = convert[2];

        }

        public String timeBuilder(String val, String format)
        {
            if (format == "h" || format == "hour")
            {
                Hour = val;
            }
            else if (format == "m" || format == "miniute")
            {
                Min = val;
            }
            else if (format == "am" || format == "AM" || format == "Am" ||
                    format == "pm" || format == "PM" || format == "Pm" ||
                    format == "tt")
            {

                Ampm = val;
            }

            Outstring = String.Format("\"{0}:{1} {2}\"", Hour, Min, Ampm);

            return Outstring;
        }
    }
}
