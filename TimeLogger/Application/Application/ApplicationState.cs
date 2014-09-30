using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using Application.Entities;
using Application.Services;

namespace Application
{
    public class ApplicationState
    {
        #region Constructors
        public ApplicationState()
        {
            RegisterSupportedBusinessServices();
            LoadUserSettings();
        }
        #endregion

        #region Properties
        public IUnityContainer UnityContainer { get; set; }
        public IUserSettingsService UserSettingsService { get; set; }
        #endregion

        #region Private Methods
        private void LoadUserSettings()
        {
            try
            {
                UserSettingsService = UnityContainer.Resolve<IUserSettingsService>();
                UserSettingsService.Load(UserSettings.Current);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot load user settings on startup.", ex);
            }
        }

        private void RegisterSupportedBusinessServices()
        {
            UnityContainer = UtilityComponent.Unity.Container.UnityContainer;
            UnityContainer.RegisterType<Services.IUserSettingsService, UserSettingsService>(new ContainerControlledLifetimeManager());
            //UnityContainer.RegisterType<Services.IBrowserServices, BrowserServices>();
            //UnityContainer.RegisterType<Services.IWindowsServices, WindowsServices>();
        }
        #endregion
    }
}
