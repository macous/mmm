using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Win = System.Windows;

namespace TimeLogger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Win.Application
    {
        //private TaskbarIcon notifyIcon;

        protected override void OnStartup(Win.StartupEventArgs e)
        {
            try
            {
                var mainWindow = new ApplicationWindow();
                this.MainWindow = mainWindow;
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                Win.MessageBox.Show(ex.Message);
                Win.Application.Current.Shutdown();
            };

            base.OnStartup(e);
        }
    }
}
