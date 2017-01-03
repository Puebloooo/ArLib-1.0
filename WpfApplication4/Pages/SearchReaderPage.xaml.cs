using ArLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchReaderPage : Page
    {
        public SearchReaderPage()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                results_readers.ItemsSource = db.Readers.ToList();
            }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = quicksearch_tb.Text;

                var query = from reader in db.Readers
                            where (reader.ID.ToString().Contains(tmp) || reader.imię.Contains(tmp) || reader.nazwisko.Contains(tmp) || reader.adres.Contains(tmp) || reader.nrTelefonu.Contains(tmp))
                            select reader;

                results_readers.ItemsSource = query.ToList();
            }
        }
    }
}
