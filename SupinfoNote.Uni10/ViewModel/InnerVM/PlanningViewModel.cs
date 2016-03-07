using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Core.JsonModels;

namespace SupinfoNote.Uni10.ViewModel.InnerVM
{

    public class PlanningViewModel : ViewModelBase
    {
        private ObservableCollection<Planning> _plannings;
        private bool _isLoading;


        public ObservableCollection<Planning> Plannings
        {
            get { return _plannings; }
            set { _plannings = value; RaisePropertyChanged(); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public PlanningViewModel()
        {
            OnLoading();
        }




        private async void OnLoading()
        {
            IsLoading = true;

            var plannings = await HttpHelper.Helper.GetPlanning(App.Current.Locator.MainPage.User.ClassId);
            if (plannings != null)
            {
                Plannings = new ObservableCollection<Planning>(plannings);
            }
            else
            {
                await new MessageDialog("Error loading planning").ShowAsync();
            }
            IsLoading = false;
        }

    }
}