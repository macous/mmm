using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TimeLogger.Controls
{
    public class NotifyIconControl 
    {
        #region Private Fields
        private NotifyIcon NotifyCtrl;
        private readonly string IconPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Resources\Images\App.ico";
        #endregion
        
        public NotifyIconControl()
        {
            NotifyCtrl = new System.Windows.Forms.NotifyIcon();
            NotifyCtrl.Icon = new Icon(IconPath);
            NotifyCtrl.Visible = true;
        }

        #region Events
        public event EventHandler OnExit;
        public event EventHandler OnHide;
        public event EventHandler OnShowOptions;
        public event EventHandler OnShowTimeLogger;
        public event EventHandler OnDoubleClick;
        #endregion

        #region Public Methods
        public void Configure()
        {
            NotifyCtrl.ContextMenu = new System.Windows.Forms.ContextMenu();
            NotifyCtrl.ContextMenu.MenuItems.Add("Show Time Logger", OnShowTimeLogger);
            NotifyCtrl.ContextMenu.MenuItems.Add("Show Options", OnShowOptions);
            NotifyCtrl.ContextMenu.MenuItems.Add("-");
            NotifyCtrl.ContextMenu.MenuItems.Add("Hide", OnHide);
            NotifyCtrl.ContextMenu.MenuItems.Add("Exit", OnExit);
            NotifyCtrl.DoubleClick += delegate(object sender, EventArgs args)
                {
                    OnDoubleClick.Invoke(sender, args);
                };
        }
        #endregion
    }
}
