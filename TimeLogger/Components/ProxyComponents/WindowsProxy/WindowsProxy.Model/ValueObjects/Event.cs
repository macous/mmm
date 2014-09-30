using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProxy.Model.ValueObjects
{
    public class Event
    {
        public Event(string source, string category, DateTime timeGenerated, string userName)
        {
            Category = category;
            Source = source;
            TimeGenerated = timeGenerated;
            UserName = userName;
        }

        public string Category { get; private set; }
        public string Source { get; private set; }
        public DateTime TimeGenerated { get; private set; }
        public string UserName { get; private set; }
    }
}
