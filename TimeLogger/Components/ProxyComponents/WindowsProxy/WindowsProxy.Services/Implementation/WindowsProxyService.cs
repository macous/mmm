using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using WindowsProxy.Model.ValueObjects;
using WindowsProxy.Model.Contracts;
using WindowsProxy.Infrastructure;
using WindowsProxy.Services.Contract;
using UtilityComponent.Unity;

namespace WindowsProxy.Services.Implementation
{
    public class WindowsProxyService : IWindowsProxyService
    {
        public WindowsProxyService()
        { 
            EventLogRepository = Container.Resolve<IEventLogRepository>();
        }
        
        public IEventLogRepository EventLogRepository { get; set; }
        public DateTime GetLastLoggonTime { get { return EventLogRepository. } }

        public DateTime FirstLogonDateToday(string sLogName)
        {
            IList<Event> entries = EventLogRepository.GetEvenLogEntries(Source.Security);

            var query = from Event entry in entries
                        where entry.Category == Category.Logon.ToString() && 
                              entry.TimeGenerated >= DateTime.Today
                        orderby entry.TimeGenerated ascending
                        select entry;

            if (query != null)
                return query.First().TimeGenerated;
            else
                return DateTime.MinValue;
        }   
    }
}
