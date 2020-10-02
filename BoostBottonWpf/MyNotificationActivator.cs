using Microsoft.QueryStringDotNET;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace BoostBottonWpf
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("282232AB-EE7E-451D-BC81-FE1F6A4F8590"), ComVisible(true)]
    class MyNotificationActivator : NotificationActivator
    {
        public override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    // Tapping on the top-level header launches with empty args
                    if (arguments.Length == 0)
                    {
                        // Perform a normal launch
                        OpenWindowIfNeeded();
                        return;
                    }

                    // Parse the query string (using NuGet package QueryString.NET)
                    QueryString args = QueryString.Parse(arguments);


                    foreach (var i in args)
                    {

                        if (i.Name == "On")
                        {
                            MainWindow.MBoostBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

                        }
                        else
                        if (i.Name == "Off")
                        {

                            MainWindow.MBoostBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

                        }
                        else
                        if (i.Name == "Close")
                        {
                            Application.Current.MainWindow.Close();
                            Application.Current.Shutdown();
                        }
                    }
                    // See what action is being requested 

                    switch (args["action"])
                    {
                        // Open the image
                        /*case "viewImage":

                            // The URL retrieved from the toast args
                            string imageUrl = args["imageUrl"];

                            // Make sure we have a window open and in foreground
                            OpenWindowIfNeeded();

                            // And then show the image
                            (App.Current.Windows[0] as MainWindow).ShowImage(imageUrl);

                           break;

                        // Background: Quick reply to the conversation
                        case "reply":

                            // Get the response the user typed
                            string msg = userInput["tbReply"];

                            // And send this message
                            //SendMessage(msg);

                            // If there's no windows open, exit the app
                            if (App.Current.Windows.Count == 0)
                           {
                               Application.Current.Shutdown();
                           }

                           break;*/


                        case "On":
                            //MessageBox.Show("On");
                            break;
                        case "Off":
                            //MessageBox.Show("Off");
                            break;
                    }
                });

            }
            catch (Exception)
            {

            }



        }
        private void OpenWindowIfNeeded()
        {
            // Make sure we have a window open (in case user clicked toast while app closed)
            if (App.Current.Windows.Count == 0)
            {
                new MainWindow().Show();
            }

            // Activate the window, bringing it to focus
            App.Current.Windows[0].Activate();

            // And make sure to maximize the window too, in case it was currently minimized
            App.Current.Windows[0].WindowState = WindowState.Normal;
        }
    }
}
