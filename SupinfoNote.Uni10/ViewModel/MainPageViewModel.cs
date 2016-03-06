using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Core.JsonModels;
using SupinfoNote.Uni10.Core.JsonModels.Grade;
using SupinfoNote.Uni10.Views.InnerViews;

namespace SupinfoNote.Uni10.ViewModel
{

    public class MainPageViewModel : ViewModelBase
    {
        private User _user;
        private ObservableCollection<News> _news;
        private ObservableCollection<GradePromo> _grades;


        private ObservableCollection<Planning> _plannings;
        private bool _isPaneOpen;
        private Frame _contentFrame;

        public ObservableCollection<Planning> Plannings
        {
            get { return _plannings; }
            set { _plannings = value; RaisePropertyChanged(); }
        }


        public ObservableCollection<GradePromo> Grades
        {
            get { return _grades; }
            set { _grades = value; RaisePropertyChanged(); }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<News> News
        {
            get { return _news; }
            set { _news = value; RaisePropertyChanged(); }
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
            if (IsInDesignMode)
            {
                User = new User() {Firstname = "lucas", Lastname = "zien",BoosterId = 152565, SuccessPoints = 700.00,};
            }
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

        private void NavigateTo(NavType type)
        {
            IsPaneOpen = false;
            ContentFrame.Navigate(type.Type);
            RaisePropertyChanged(nameof(ActualPageType));
        }

        #endregion



    }
}