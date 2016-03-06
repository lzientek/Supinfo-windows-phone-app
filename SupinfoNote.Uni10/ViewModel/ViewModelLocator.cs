/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SupinfoNote"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SupinfoNote.Uni10.ViewModel.InnerVM;

namespace SupinfoNote.Uni10.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ConnectionViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<GradesViewModel>();
            SimpleIoc.Default.Register<NewsViewModel>();
            SimpleIoc.Default.Register<PlanningViewModel>();
        }

        public ConnectionViewModel Connection => ServiceLocator.Current.GetInstance<ConnectionViewModel>();
        public MainPageViewModel MainPage => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public GradesViewModel Grades => ServiceLocator.Current.GetInstance<GradesViewModel>();
        public PlanningViewModel Planning => ServiceLocator.Current.GetInstance<PlanningViewModel>();
        public NewsViewModel News => ServiceLocator.Current.GetInstance<NewsViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}