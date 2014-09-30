using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogger.ViewModels
{
    public class TimeLoggerViewModel : BaseViewModel
    {
        public TimeLoggerViewModel()
        {
            StartWork = new TimeSpan(8, 0, 0);
            StartLunch = new TimeSpan(12, 0, 0);
            FinishLunch = new TimeSpan(12, 40, 0);
            FinishWork = new TimeSpan(16, 40, 0);
        }

        public TimeSpan StartWork { get; set; }
        public TimeSpan StartLunch { get; set; }
        public TimeSpan FinishLunch { get; set; }
        public TimeSpan FinishWork { get; set; }
        public TimeSpan TotalWork { get { return (StartLunch - StartWork) + (FinishWork - FinishLunch); } }

        public string StartWorkString 
        { 
            set 
            { 
                TimeSpan ts = new TimeSpan();
                if (TimeSpan.TryParse(value, out ts))
                    StartWork = ts;
            } 
            get { return StartWork.ToString(@"hh\:mm"); } 
        }

        public string StartLunchString
        {
            set
            {
                TimeSpan ts = new TimeSpan();
                if (TimeSpan.TryParse(value, out ts))
                    StartLunch = ts;
            }
            get { return StartLunch.ToString(@"hh\:mm"); }
        }

        public string FinishLunchString
        {
            set
            {
                TimeSpan ts = new TimeSpan();
                if (TimeSpan.TryParse(value, out ts))
                    FinishLunch = ts;
            }
            get { return FinishLunch.ToString(@"hh\:mm"); }
        }

        public string FinishWorkString
        {
            set
            {
                TimeSpan ts = new TimeSpan();
                if (TimeSpan.TryParse(value, out ts))
                    FinishWork = ts;
            }
            get { return FinishWork.ToString(@"hh\:mm"); }
        }

        public string TotalWorkString
        {
            set
            {
                
            }
            get { return TotalWork.ToString(@"hh\:mm"); }
        }
    }
}
