using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using WindowsProxy.Model.ValueObjects;

namespace WindowsProxy.Infrastructure
{
    public class EventLogRepository
    {
        private EventLog log;

        public EventHandler GetEventLogEvent(Source source)
        {
            if (log == null)
                log = new EventLog();
            log.Source = source.ToString();
            log.EntryWritten += log_EntryWritten;
        }

        void log_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            
        }

        public IList<Event> GetEvenLogEntries(Source source)
        {
            IList<Event> eventList = new List<Event>();
            
            log = new EventLog();
            log.Source = source.ToString();
            
            foreach (EventLogEntry ent in log.Entries)
                eventList.Add(new Event(ent.Source, ent.Category, ent.TimeGenerated, ent.UserName));
            
            return eventList;
        }
    }
}
