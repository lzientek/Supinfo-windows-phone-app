using System;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Views;

namespace SupinfoNote.Uni10.ViewModel
{
    public class ConnectionViewModel : ViewModelBase
    {
        private string _campusId;
        private string _password;
        private bool _isConnecting;

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
            IsConnecting = true;
            var usr = await HttpHelper.Helper.LoginRequest(CampusId, Password);
            if (usr != null)
            {

                App.Current.Locator.MainPage.User = usr;
                usr.ConvertStringToImage();
                //go to next page
                App.Current.RootFrame.Navigate(typeof(MainPage));
            }
            else
            {
                await new MessageDialog("Wrong password or campus id").ShowAsync();
            }
            IsConnecting = false;

        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            set { _isConnecting = value;RaisePropertyChanged(); }
        }

        public string CampusId
        {
            get { return _campusId; }
            set { _campusId = value; RaisePropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }

        public RelayCommand ConnectCommand { get; set; }
    }
}