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
                //Removal of data base entries

                //var all = from c in db.Books select c;
                //db.Books.RemoveRange(all);
                //db.SaveChanges(); 

                dataGrid.ItemsSource = db.Books.ToList();
            }

        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/AddBookPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}

