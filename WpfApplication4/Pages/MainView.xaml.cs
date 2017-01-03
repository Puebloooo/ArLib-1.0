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

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/AddBookPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/AddReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //to do
            //Edit personal info about Admin
            this.NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_password_Click(object sender, RoutedEventArgs e)
        {
            //to do
            //Edit Admins password
            this.NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            //to do
            //Show about page
            NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
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

        private void SearchReader_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SearchReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SearchTransaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TakeBook_Click(object sender, RoutedEventArgs e)
        {
            StaticTransaction.selectedBook = (Book)dataGrid.SelectedItem;
            NavigationService.Navigate(new Uri("/Pages/TakeBookPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}

