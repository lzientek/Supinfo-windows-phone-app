using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupinfoNote.Uni10.Core;
using SupinfoNote.Uni10.Core.JsonModels;

namespace SupinfoNote.Uni10.ViewModel.InnerVM
{

    public class NewsViewModel : ViewModelBase
    {
        private ObservableCollection<News> _news;

        
        public ObservableCollection<News> News
        {
            get { return _news; }
            set { _news = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the ConnectionViewModel class.
        /// </summary>
        public NewsViewModel()
        {
            OnLoading();
        }


        private async void OnLoading()
        {
            var news = await HttpHelper.Helper.GetNews();
            if (news != null)
            {
                News = new ObservableCollection<News>(news);
            }
            else
            {
                await new MessageDialog("Error loading news").ShowAsync();
            }
        }

    }
}