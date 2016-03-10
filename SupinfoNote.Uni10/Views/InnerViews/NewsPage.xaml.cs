using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SupinfoNote.Uni10.Core.JsonModels;
using SupinfoNote.Uni10.ViewModel.InnerVM;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace SupinfoNote.Uni10.Views.InnerViews
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        public NewsPage()
        {
            this.InitializeComponent();
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var vm = (DataContext as NewsViewModel);
            vm.NavigateToDetails(e.ClickedItem as News);
        }
    }
}
