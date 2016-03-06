using Windows.UI.Xaml.Controls;
using SupinfoNote.Uni10.ViewModel;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SupinfoNote.Uni10.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SplitView.Content = (DataContext as MainPageViewModel)?.ContentFrame;
        }

        private void DontCheck(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // don't let the radiobutton check
            var radioButton = sender as RadioButton;
            if (radioButton != null) radioButton.IsChecked = false;
        }
    }
}
