using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProxy.Services.Contract
{
    public interface IWindowsProxyService
    {
        DateTime FirstLogonDateToday(string sLogName);
    }
}
