using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace BoostBottonWpf
{
    class Alarm : DispatcherTimer
    {
        private DispatcherTimer dispalarm;
        private String startime = "7:30 AM";
        private String endtime = "6:00 PM";
        private const string TIMERON = "timeron";
        private const string HASSTARTTIME = "hasstarttimer";
        private const string HASENDTIMER = "hasendtimer";
        private const string STARTTIMECONST = "starttime";
        private const string ENDTIMECONST = "endtime";
        private string currentTime;
        private bool starttimerset = false;
        private bool endtimerset = false;

        private bool hasalarm = false;

        private bool hasstarttimer = false;
        private bool hasendtimer = false;
        private MainWindow main;
        private Thread MyThread;

        private JsonParser jsonParser;





        private String CurrentTime
        {
            get => currentTime; set => currentTime = value;
        }
        public string Startime { get => startime; set => startime = value; }
        public string Endtime { get => endtime; set => endtime = value; }
        public bool Starttimerset { get => starttimerset; set => starttimerset = value; }
        public bool Endtimerset { get => endtimerset; set => endtimerset = value; }
        public bool Hasstarttimer { get => hasstarttimer; set => hasstarttimer = value; }
        public bool Hasalarm { get => hasalarm; set => hasalarm = value; }
        public bool Hasendtimer { get => hasendtimer; set => hasendtimer = value; }
        public MainWindow Main { get => main; set => main = value; }
        internal JsonParser JsonParser { get => jsonParser; set => jsonParser = value; }
        public DispatcherTimer Dispalarm { get => dispalarm; set => dispalarm = value; }

        public Alarm()
        {
            Dispalarm = new DispatcherTimer();
            this.JsonParser = new JsonParser();
            JsonParser.Load();
            AlarmThread alarmThread = new AlarmThread(this);
            MyThread = new Thread(new ThreadStart(alarmThread.initrunner));
            MyThread.Start();

        }

        public Alarm(MainWindow main)
        {
            Main = main;
            Dispalarm = new DispatcherTimer();
            this.JsonParser = new JsonParser();
            JsonParser.Load();
            AlarmThread alarmThread = new AlarmThread(this);
            MyThread = new Thread(new ThreadStart(alarmThread.initrunner));
            MyThread.Start();

        }

        public bool IsStartTime()
        {
            if (Startime == CurrentTime)
            {
                return true;
            }
            return false;
        }

        public bool IsEndTime()
        {
            if (Endtime == CurrentTime)
            {
                return true;
            }

            return false;
        }

        public bool actiontime(String what)
        {
            bool outs = false;
            if (what == "start" || what == "Start" || what == "S" || what == "s")
            {
                if (CurrentTime == Startime)
                {

                    outs = true;
                }

            }
            else
            if (what == "end" || what == "End" || what == "E" || what == "e")
            {
                if (CurrentTime == Endtime)
                {

                    outs = true;
                }
            }

            return outs;


        }


        public void ConfigUpdate()
        {

            jsonParser.Update();

            Startime = jsonParser.Get[jsonParser.Count["\"" + STARTTIMECONST + "\""] - 1];
            Endtime = jsonParser.Get[jsonParser.Count["\"" + ENDTIMECONST + "\""] - 1];

            if (JsonParser.Get[JsonParser.Count["\"" + HASSTARTTIME + "\""] - 1])
            {
                Hasstarttimer = JsonParser.Get[JsonParser.Count["\"" + HASSTARTTIME + "\""] - 1];
            }
            else
            {
                Hasstarttimer = JsonParser.Get[JsonParser.Count["\"" + HASSTARTTIME + "\""] - 1];
            }


            if (JsonParser.Get[JsonParser.Count["\"" + HASENDTIMER + "\""] - 1])
            {
                Hasendtimer = JsonParser.Get[JsonParser.Count["\"" + HASENDTIMER + "\""] - 1];

            }
            else
            {
                Hasendtimer = JsonParser.Get[JsonParser.Count["\"" + HASENDTIMER + "\""] - 1];
            }

            if (JsonParser.Get[JsonParser.Count["\"" + TIMERON + "\""] - 1])
            {
                Hasalarm = JsonParser.Get[JsonParser.Count["\"" + TIMERON + "\""] - 1];
            }
            else
            {
                Hasalarm = JsonParser.Get[JsonParser.Count["\"" + TIMERON + "\""] - 1];
            }


        }




        protected class AlarmThread
        {

            protected Alarm Alarm
            {
                get; set;
            }
            public AlarmThread(Alarm alarm)
            {
                Alarm = alarm;


            }

            private void Time_Updater(object sender, EventArgs e)
            {
                Alarm.CurrentTime = DateTime.Now.ToString("h:mm tt");
                Alarm.ConfigUpdate();
                bool starttimeing = Alarm.actiontime("start");
                bool endtime = Alarm.actiontime("end");


                if (Alarm.Hasalarm)
                {
                    if (Alarm.Hasstarttimer)
                    {
                        if (Alarm.IsStartTime())
                        {
                            if (starttimeing)
                            {

                                if (!MainWindow.IsOn)
                                {
                                    ////Console.WriteLine("Click action start");
                                    MainWindow.MBoostBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    MainWindow.IsOn = true;
                                }
                            }
                        }
                    }

                    if (Alarm.Hasendtimer)
                    {
                        if (Alarm.IsEndTime())
                        {
                            if (endtime)
                            {

                                if (MainWindow.IsOn)
                                {
                                    ////Console.WriteLine("Click action end");
                                    MainWindow.MBoostBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                    MainWindow.IsOn = false;
                                }
                            }
                        }
                    }

                }




            }


            public void initrunner()
            {
                Alarm.Dispalarm.Interval = TimeSpan.FromSeconds(1);
                Alarm.Dispalarm.Tick += Time_Updater;
                Alarm.Dispalarm.Start();
            }


        }
    }


}
