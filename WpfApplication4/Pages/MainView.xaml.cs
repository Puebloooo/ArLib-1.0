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
            //TODO: Look through transactions
        }
        private void SearchBill_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Look through bills
        }
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/AddBookPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/AddReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            string tmp = quicksearch_tb.Text;
            using (var db = new ArLibCon())
            {
                var query = from book in db.Books
                            where (book.ID.ToString().Contains(tmp) || book.tytuł.Contains(tmp) || book.autor.Contains(tmp) || book.ISBN.Contains(tmp) || book.wydawnictwo.Contains(tmp) || book.seria.Contains(tmp))
                            select book;
                dataGrid.ItemsSource = query.ToList();
            }
        }
        private void TakeBook_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                StaticTransaction.selectedBook = (Book)dataGrid.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/TakeBookPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
        private void deleteBook_button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
                if (MessageBox.Show("Czy na pewno usunąć?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new ArLibCon())
                    {
                        Book tmp = (Book)dataGrid.SelectedItem;

                        var query = from book in db.Books
                                    where book.ID == tmp.ID
                                    select book;

                        db.Books.RemoveRange(query);
                        db.SaveChanges();
                        NavigationService.Refresh();
                    }
            
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Change admin info
            this.NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void edit_password_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Change admin password
            this.NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Show "About" page
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}

