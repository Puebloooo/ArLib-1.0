using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ArLib.Classes;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                dataGrid.ItemsSource = db.Books.ToList();
            }
        }
        private void SearchReader_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SearchReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void SearchTransaction_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SearchTransactionPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void SearchBill_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Look through bills
        }
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddBookPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            string tmp = quicksearch_tb.Text;
            using (var db = new ArLibCon())
            {
                var query = db.Books.Where(book => (book.ID.ToString().Contains(tmp) || book.tytuł.Contains(tmp) || book.autor.Contains(tmp) || book.ISBN.Contains(tmp) || book.wydawnictwo.Contains(tmp) || book.seria.Contains(tmp)));
                dataGrid.ItemsSource = query.ToList();
            }
        }
        private void editBook_button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                StaticTemp.selectedBook = (Book)dataGrid.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/EditBookPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
        private void TakeBook_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                StaticTemp.selectedBook = (Book)dataGrid.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/TakeBookPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
        private void returnBook_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
                using (var db = new ArLibCon())
                {
                    Book selected = (Book)dataGrid.SelectedItem;
                    if (selected.czyWypożyczona == true)
                    {
                        var transaction = db.Transactions.SingleOrDefault(b => (b.idKsiążki == selected.ID && b.czyZwrócona == false));
                        var reader = db.Readers.SingleOrDefault(b => b.ID == transaction.idCzytelnika);
                        var book = db.Books.SingleOrDefault(b => b.ID == selected.ID);

                        transaction.dataZwrotu = DateTime.Today;
                        transaction.czyZwrócona = true;
                        reader.limitWypożyczeń += 1;
                        book.czyWypożyczona = false;

                        db.SaveChanges();
                        MessageBox.Show("Pomyślnie zwrócono książkę!");
                        NavigationService.Refresh();
                    }
                }
        }
        private void deleteBook_button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
                if (MessageBox.Show("Czy na pewno usunąć?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new ArLibCon())
                    {
                        Book tmp = (Book)dataGrid.SelectedItem;

                        var query = db.Books.Where(b => b.ID == tmp.ID);

                        db.Books.RemoveRange(query);
                        db.SaveChanges();
                        NavigationService.Refresh();
                    }
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ChangeAdminInfoPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void edit_password_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/NewPasswordPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}

