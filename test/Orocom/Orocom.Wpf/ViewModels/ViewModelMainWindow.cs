using Orocom.DbLib.Class;
using Orocom.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orocom.Wpf.ViewModels
{
    class ViewModelMainWindow : ObservableObject
    {
        private User? _LoggedUser;

        public User? LoggedUser
        {
            get { return _LoggedUser; }
            set { SetProperty(nameof(LoggedUser), ref _LoggedUser, value); }
        }

        public ViewModelMainWindow()
        {

            LoggedUser = ((App)App.Current).LoggedUser;
        }

        public void Logout() => ((App)App.Current).Logout();
    }
}
