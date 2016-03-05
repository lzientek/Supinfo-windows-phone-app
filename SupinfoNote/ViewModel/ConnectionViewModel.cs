using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SupinfoNote.Helper;
using SupinfoNote.Views;

namespace SupinfoNote.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
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
                App.Current.RootFrame.Navigate(typeof(MainPage));
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