using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Core.JsonModels.Grade;

namespace SupinfoNote.Uni10.ViewModel.InnerVM
{

    public class GradesViewModel : ViewModelBase
    {
        private ObservableCollection<GradePromo> _grades;
        private bool _isLoading;


        public ObservableCollection<GradePromo> Grades
        {
            get { return _grades; }
            set { _grades = value; RaisePropertyChanged(); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public GradesViewModel()
        {
            OnLoading();
        }


        private async void OnLoading()
        {
            IsLoading = true;
            var gradePromos = await HttpHelper.Helper.GetGrades();
            if (gradePromos != null)
            {
                Grades = new ObservableCollection<GradePromo>(gradePromos);
            }
            else
            {
                await new MessageDialog("Error loading grades").ShowAsync();
            }
            IsLoading = false;

        }

    }
}