using ArLib.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchBillPage : Page
    {
        public SearchBillPage()
        {
            InitializeComponent();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = search_textBox.Text;
                
                //TODO: Bills searching
                var query = db.Readers.Where(reader => (reader.ID.ToString().Contains(tmp) || reader.imię.Contains(tmp) || reader.nazwisko.Contains(tmp) || reader.adres.Contains(tmp) || reader.nrTelefonu.Contains(tmp)));
                results_readers.ItemsSource = query.ToList();
            }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
