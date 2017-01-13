using ArLib.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = quicksearch_tb.Text;
                var query = db.Readers.Where(reader => (reader.ID.ToString().Contains(tmp) || reader.imię.Contains(tmp) || reader.nazwisko.Contains(tmp) || reader.adres.Contains(tmp) || reader.nrTelefonu.Contains(tmp)));
                results_readers.ItemsSource = query.ToList();
            }
        }
        private void deleteReader_button_Click(object sender, RoutedEventArgs e)
        {
            if (results_readers.SelectedItem != null)
                if (MessageBox.Show("Czy na pewno usunąć?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new ArLibCon())
                    {
                        Reader tmp = (Reader)results_readers.SelectedItem;
                        var query = db.Readers.Where(reader => reader.ID == tmp.ID);

                        db.Readers.RemoveRange(query);
                        db.SaveChanges();
                        NavigationService.Refresh();
                    }
        }
        private void editReader_button_Click(object sender, RoutedEventArgs e)
        {
            if (results_readers.SelectedItem != null)
            {
                StaticTemp.selectedReader = (Reader)results_readers.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/EditReaderPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
