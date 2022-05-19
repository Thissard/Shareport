using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Shareport
{
    public partial class Service1 : ServiceBase
    {
        private int eventId = 1;
        public Service1()
        {
            InitializeComponent();
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("Shareport service"))
            {
                EventLog.CreateEventSource(
                    "Shareport service", "ShareportLog");
            }
            eventLog1.Source = "Shareport service";
            eventLog1.Log = "ShareportLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Service started");
            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Tick", EventLogEntryType.Information, eventId++);

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Service stopped");
        }
    }
}
