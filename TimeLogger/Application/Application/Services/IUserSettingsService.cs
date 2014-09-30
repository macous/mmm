﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Entities;

namespace Application.Services
{
    public interface IUserSettingsService
    {
        void Save(UserSettings userSettings);
        void Load(UserSettings userSettings);
    }
}
