using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Core.JsonModels;
using SupinfoNote.Uni10.Core.JsonModels.Grade;

namespace SupinfoNote.Uni10.ViewModel
{

    public class MainPageViewModel : ViewModelBase
    {
        private User _user;
        private ObservableCollection<News> _news;
        private ObservableCollection<GradePromo> _grades;


        private ObservableCollection<Planning> _plannings;

        public ObservableCollection<Planning> Plannings
        {
            get { return _plannings; }
            set { _plannings = value;RaisePropertyChanged(); }
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
            set { _news = value;RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public MainPageViewModel()
        {
            Loading = new RelayCommand( OnLoading);
        }


        private async void OnLoading()
        {
          var news =  await HttpHelper.Helper.GetNews();
            if (news != null)
            {
                News = new ObservableCollection<News>(news);
            }
            else
            {
                await new MessageDialog("Error loading news").ShowAsync();
            }

            var grades = await HttpHelper.Helper.GetGrades();
            if (grades != null)
            {
                Grades = new ObservableCollection<GradePromo>(grades);
            }
            else
            {
                await new MessageDialog("Error loading grades").ShowAsync();
            }

            var planning = await HttpHelper.Helper.GetPlanning(User.ClassId);
            if (planning != null)
            {
                Plannings = new ObservableCollection<Planning>(planning);
            }
            else
            {
                await new MessageDialog("Error loading planning").ShowAsync();
            }
        }

        public RelayCommand Loading { get; set; }

    }
}