using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace WheelsForHire.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private string _testLabel;

        public string TestLabel
        {
            get { return _testLabel; }
            set 
            { 
                _testLabel = value;
                RaisePropertyChanged();
            }
        }

        public HomeViewModel()
        {
            TestLabel = "Hello world!";

            var mytimer = new Timer();
            mytimer.Interval = 3000;
            mytimer.Elapsed += OnTimer;
            mytimer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            ((Timer)sender).Stop();
            TestLabel = "The timer finished :)";
        }
    }
}
