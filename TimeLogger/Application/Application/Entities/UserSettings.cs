using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public sealed class UserSettings
    {
        public UserSettings()
        {
            SaveStartWorkAuto = String.Empty;
            SaveFinishLunchAuto = String.Empty;
        }

        #region Properties
        public string SaveStartWorkAuto { get; set; }
        public string SaveFinishLunchAuto { get; set; }

        private static UserSettings current;
        public static UserSettings Current
        {
            get
            {
                if (UserSettings.current == null)
                    UserSettings.current = new UserSettings();
                return UserSettings.current;
            }
        }
        #endregion
    }
}
