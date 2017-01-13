using ArLib.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for EditBookPage.xaml
    /// </summary>
    public partial class EditBookPage : Page
    {
        public EditBookPage()
        {
            InitializeComponent();
            title_box.Text = StaticTemp.selectedBook.tytuł;
            author_box.Text = StaticTemp.selectedBook.autor;
            isbn_box.Text = StaticTemp.selectedBook.ISBN;
            pages_box.Text = StaticTemp.selectedBook.liczbaStron;
            publisher_box.Text = StaticTemp.selectedBook.wydawnictwo;
            series_box.Text = StaticTemp.selectedBook.seria;
        }
        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (title_box.Text != "" && author_box.Text != "" && isbn_box.Text != "" && pages_box.Text != "" && publisher_box.Text != "")
            {
                using (var db = new ArLibCon())
                {
                    var editedBook = db.Books.SingleOrDefault(b => b.ID == StaticTemp.selectedBook.ID);
                    editedBook.tytuł = title_box.Text;
                    editedBook.autor = author_box.Text;
                    editedBook.ISBN = isbn_box.Text;
                    editedBook.liczbaStron = pages_box.Text;
                    editedBook.wydawnictwo = publisher_box.Text;
                    editedBook.seria = series_box.Text;
                    db.SaveChanges();
                }
                tmp_label.Content = "Pomyślnie zmieniono! Wciśnij Powrót.";
            }
            else
                tmp_label.Content = "Uzupełnij wszystkie wymagane pola!";
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
