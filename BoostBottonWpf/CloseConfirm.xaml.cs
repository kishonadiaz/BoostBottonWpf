using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;

namespace BoostBottonWpf
{
    /// <summary>
    /// Interaction logic for CloseConfirm.xaml
    /// </summary>
    public partial class CloseConfirm : Window
    {
        Boolean isOpen = false;
        private String roming;
        private String filepath;
        private FileStream configfile;
        private StreamReader streamReader;
        private String line;
        private List<String> json;
        private List<String> jsonout;
        private JsonParser jsonParser;
        string curdir = System.Reflection.Assembly.GetEntryAssembly().Location;

        public Boolean IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
            }
        }

        public MainWindow Main { get; set; }

        public CloseConfirm()
        {
            InitializeComponent();

            jsonParser = new JsonParser();
            json = new List<string>();

            isOpen = true;


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

            if (jsonParser.Get[jsonParser.Count["\"allwayclose\""] - 1])
            {
                NeverShowcheck.IsChecked = jsonParser.Get[jsonParser.Count["\"allwayclose\""] - 1];
            }
            else
            {
                NeverShowcheck.IsChecked = jsonParser.Get[jsonParser.Count["\"allwayclose\""] - 1];
            }
        }


        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void NeverShow_Checked(object sender, RoutedEventArgs e)
        {
            if (NeverShowcheck.IsChecked == false)
            {


            }
            jsonParser.changeIndex("\"allwayclose\"", true);
            Thread.Sleep(1);
            jsonParser.Save();

            //jsonParser.jsonbuilder();

        }

        private void CloseConfirm_Activated(object sender, EventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;
        }

        private void CloseConfirm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
            MainWindow.IsActive = false;
        }

        private void CloseConfirm_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;

        }

        private void CloseConfirm_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow.IsActive = false;

        }

        private void CloseConfirm_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsOpen = true;
            MainWindow.IsActive = true;
            Main.Show();
            Main.WindowState = WindowState.Normal;

        }
    }
}
