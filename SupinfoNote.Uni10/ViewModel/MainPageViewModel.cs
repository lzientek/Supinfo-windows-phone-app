using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core.JsonModels;
using SupinfoNote.Uni10.Core.JsonModels.Grade;
using SupinfoNote.Uni10.Views.InnerViews;

namespace SupinfoNote.Uni10.ViewModel
{

    public class MainPageViewModel : ViewModelBase
    {
        private User _user;

        private bool _isPaneOpen;
        private Frame _contentFrame;

        public User User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(); }
        }

        public Frame ContentFrame
        {
            get { return _contentFrame ?? (_contentFrame = new Frame()); }
            set { _contentFrame = value; RaisePropertyChanged(); RaisePropertyChanged(nameof(ActualPageType)); }
        }

        public Type ActualPageType => ContentFrame.SourcePageType;

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public MainPageViewModel()
        {
            MenuCommand = new RelayCommand(OpenCloseMenu);
            NavigateCommand = new RelayCommand<NavType>(NavigateTo);
            ContentFrame.Navigate(typeof (NewsPage));
        }


        #region Commands

        public RelayCommand MenuCommand { get; set; }
        public RelayCommand<NavType> NavigateCommand { get; set; }


        private void OpenCloseMenu()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { _isPaneOpen = value; RaisePropertyChanged(); }
        }

        public void NavigateTo(NavType type)
        {
            IsPaneOpen = false;
            ContentFrame.Navigate(type.Type);
            RaisePropertyChanged(nameof(ActualPageType));
        }

        #endregion



    }
}