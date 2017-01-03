using System;
using System.Windows;
using System.Windows.Controls;
using ArLib.Classes;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Page
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (title_box.Text  != "" && author_box.Text != "" && isbn_box.Text != "" && pages_box.Text != "" && publisher_box.Text != "")
            {
                Book tmp = new Book(title_box.Text, author_box.Text, isbn_box.Text, pages_box.Text, publisher_box.Text, series_box.Text);
                using (var db = new ArLibCon())
                {
                    db.Books.Add(tmp);
                    db.SaveChanges();
                }
                tmp_label.Content = "Pomyślnie dodano! Wciśnij Powrót.";
            }
            else
                tmp_label.Content = "Uzupełnij wszystkie wymagane pola!";

        }
    }
}
