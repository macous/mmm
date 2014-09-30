using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WindowsProxy.Model.ValueObjects;

namespace WindowsProxy.Model.Contracts
{
    public interface IEventLogRepository
    {
        IList<Event> GetEvenLogEntries(Source source);
    }
}
