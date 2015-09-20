using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Configuration;
using System.IO;
using System.Timers;

namespace MyGalleryWindowsService
{
    public partial class WindowsService : ServiceBase
    {
        private Timer timer;

        public WindowsService()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(this.OnTimerTick);
            timer.Enabled = true;

            timer.AutoReset = true;
            timer.Interval = 500;
            timer.Start();
        }

        protected override void OnStart(string[] args)
        {
            timer.Enabled = true;

        }

        protected override void OnStop()
        {
            timer.Enabled = true;
        }

        private void OnTimerTick(Object myObject, EventArgs myEventArgs)
        {

            var thumbGen = new TestProject.Tasks.ThumbnailGenerator();
            thumbGen.Run();
            
        }
    }
}
