using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;
using TimeLogger.Common;
using System.Windows.Input;

namespace TimeLogger
{
    public class ApplicationController
    {
        #region Constructors
        public ApplicationController(Window mainWindow)
        {
            // main window
            MainWindow = mainWindow;
            MainWindow.ShowInTaskbar = false;
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            MainWindow.Left = desktopWorkingArea.Right - MainWindow.Width - 10;
            MainWindow.Top = desktopWorkingArea.Bottom - MainWindow.Height - 10;
            
            // current view
            var timeLoggerViewModel = new ViewModels.TimeLoggerViewModel();
            CurrentView = new Views.TimeLoggerView();
            CurrentView.DataContext = timeLoggerViewModel;

            // current application state
            State = new ApplicationState();
        }
        #endregion

        #region Properties
        public UserControl CurrentView { get; set; }
        public Window MainWindow { get; set; }
        public ApplicationState State { get; set; }
        
        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => MainWindow.Close() };
            }
        }

        /// <summary>
        /// Shows a window, if none is already open.
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => MainWindow == null || MainWindow.IsActive == false,
                    CommandAction = () =>
                    {
                        if (MainWindow == null)
                            MainWindow = new ApplicationWindow();

                        MainWindow.Show();
                    }
                };
            }
        }

        /// <summary>
        /// Hides the main window. This command is only enabled if a window is open.
        /// </summary>
        public ICommand HideWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () => MainWindow.Hide(),
                    CanExecuteFunc = () => MainWindow != null && MainWindow.IsActive == true
                };
            }
        }
        #endregion
    }
}
