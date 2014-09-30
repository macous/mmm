using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLogger
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationController(this);
            CreateNotification();
        }

        private void CreateNotification()
        {
            Controls.NotifyIconControl taskbarControl = new Controls.NotifyIconControl();
            taskbarControl.OnExit += notification_OnExit;
            taskbarControl.OnHide += taskbarControl_OnHide;
            taskbarControl.OnShowOptions += taskbarControl_OnShowOptions;
            taskbarControl.OnShowTimeLogger += taskbarControl_OnShowTimeLogger;
            taskbarControl.OnDoubleClick += taskbarControl_OnShowTimeLogger;
            taskbarControl.Configure();
        }
         
        void taskbarControl_OnShowTimeLogger(object sender, EventArgs e)
        {
            (this.DataContext as ApplicationController).ShowWindowCommand.Execute(null);
        }

        void taskbarControl_OnShowOptions(object sender, EventArgs e)
        {
            (this.DataContext as ApplicationController).ShowWindowCommand.Execute(null);
        }

        void taskbarControl_OnHide(object sender, EventArgs e)
        {
            (this.DataContext as ApplicationController).HideWindowCommand.Execute(null);
        }

        void notification_OnExit(object sender, EventArgs e)
        {
            (this.DataContext as ApplicationController).ExitApplicationCommand.Execute(null);
        }
    }
}
