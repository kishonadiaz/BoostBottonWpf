using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;


namespace BoostBottonWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



        public App()
        {
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("BoostBottonWpf.App");
            DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();



        }



        protected override void OnStartup(StartupEventArgs e)
        {

            try
            {
                if (e.Args.Contains("-ToastActivated"))
                {
                    //MessageBox.Show("Activated by a toast notification");
                }
            }
            catch (Exception)
            {

            }



            base.OnStartup(e);

            String thisProcessname = Process.GetCurrentProcess().ProcessName;

            /* if (Process.GetProcesses().Count(p => p.ProcessName == thisProcessname) > 1) ;*/

        }




        protected override void OnExit(ExitEventArgs e)
        {
            Application.Current.Shutdown(2);
            base.OnExit(e);

        }
    }




}
