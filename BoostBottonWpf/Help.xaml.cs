using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace BoostBottonWpf
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        string curdir = System.Reflection.Assembly.GetEntryAssembly().Location;
        string styledir = System.Reflection.Assembly.GetEntryAssembly().Location;

        JsonParser jsonPars = new JsonParser();
        private static Help helpthis;

        Thread eventThread;

        public static Help Helpthis { get => helpthis; set => helpthis = value; }
        private String roming;
        private String filepath;
        private FileStream configfile;
        private JsonParser jsonParser;
        private StreamReader streamReader;
        private String line;
        public Help()
        {
            InitializeComponent();

            jsonParser = new JsonParser();

            Helpthis = this;
        }

        private void HelpWIn_Loaded(object sender, RoutedEventArgs e)
        {
            jsonPars.Load();
            jsonPars.changeIndex("helpinit", false);



            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();
            eventThread = new Thread(new ThreadStart(new HelpThreadAction().events));
            eventThread.Start();


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

            outs.Add("index.html");


            var s = String.Join("/", outs);





            browser.Source = new Uri(String.Format("file:///{0}", s));
            BoundObj.Dir = String.Join("/", ttos) + "/";
            BoundObj.Rootloc = String.Join("/", toLocalHost) + "/";


            if (browser.IsLoaded)
            {
                try
                {
                    browser.ObjectForScripting = new BoundObj();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




        }

        private void HelpWIn_Activated(object sender, EventArgs e)
        {

        }

        private void HelpWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            browser.Source = null;
            jsonPars.Save();
        }
    }


     /* 
        This thread is used to run the commuication between the browser
        this  
     */
    //href="https://www.maketecheasier.com/ultimate-performance-feature-windows10/"
    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/01cf9667-b420-4c82-a2ba-18b996eac7e2/pass-arrays-from-javascript-to-c-via-webbrowser-object?forum=wpf

    class HelpThreadAction
    {
        DispatcherTimer dispatcher = new DispatcherTimer();

        public HelpThreadAction()
        {


        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            if (BoundObj.Settingspressed)
            {


                MainWindow.SButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                BoundObj.Settingspressed = false;
            }

            if (BoundObj.Closedpressed)
            {
                Help.Helpthis.Close();
                BoundObj.Closedpressed = false;
            }
            if (BoundObj.Linkpressed)
            {


                System.Diagnostics.Process.Start("https://www.maketecheasier.com/ultimate-performance-feature-windows10/");
                BoundObj.Linkpressed = false;
            }

        }

        public void events()
        {
            dispatcher.Interval = TimeSpan.FromSeconds(1);
            dispatcher.Tick += Dispatcher_Tick;
            dispatcher.Start();
        }
    }

    /*This is the commuication class between the browser and c# interface*/

    [ComVisible(true)]
    public class BoundObj
    {
        private static string dir;
        private static string rootloc;
        private static bool settingspressed = false;
        private static bool closedpressed = false;
        private static bool linkpressed = false;

        public static String Dir
        {
            get => dir; set => dir = value;
        }
        
        public static string Rootloc { get => rootloc; set => rootloc = value; }
        public static bool Settingspressed { get => settingspressed; set => settingspressed = value; }
        public static bool Closedpressed { get => closedpressed; set => closedpressed = value; }
        public static bool Linkpressed { get => linkpressed; set => linkpressed = value; }

        public void setSettingsPressed(bool v)
        {
            Settingspressed = v;
        }
        public void setClosedpressed(bool v)
        {
            Closedpressed = v;
        }
        public bool getSettingsPressed()
        {

            return Settingspressed;
        }

        public bool getClosedpressed()
        {
            return Closedpressed;
        }

        public void setLinkPressed(bool v)
        {

            Linkpressed = v;
        }
        public bool getLinkPressed()
        {

            return Linkpressed;
        }
        public String getDir()
        {
            return Dir;
        }

        public String getRoot()
        {
            return Rootloc;
        }
       
      
    }
}
