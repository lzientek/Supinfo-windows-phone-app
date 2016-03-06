using System;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;

namespace SupinfoNote.Uni10.ViewModel
{
    public class ConnectionViewModel : ViewModelBase
    {
        private string _campusId;
        private string _password;

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public ConnectionViewModel()
        {
            CampusId = "";
            Password = "";

            ConnectCommand = new RelayCommand(Connect);
        }

        private async void Connect()
        {
            var usr = await HttpHelper.Helper.LoginRequest(CampusId, Password);
            if (usr != null)
            {
                App.Current.Locator.MainPage.User = usr;
                //go to next page
            }
            else
            {
                await new MessageDialog("Wrong password or campus id").ShowAsync();
            }
        }

        public string CampusId
        {
            get { return _campusId; }
            set { _campusId = value;RaisePropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value;RaisePropertyChanged(); }
        }

        public RelayCommand ConnectCommand { get; set; }
    }
}