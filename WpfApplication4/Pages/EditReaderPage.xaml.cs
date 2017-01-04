using ArLib.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for EditReaderPage.xaml
    /// </summary>
    public partial class EditReaderPage : Page
    {
        public EditReaderPage()
        {
            InitializeComponent();
            name_box.Text = StaticTemp.selectedReader.imię;
            surname_box.Text = StaticTemp.selectedReader.nazwisko;
            address_box.Text = StaticTemp.selectedReader.adres;
            number_box.Text = StaticTemp.selectedReader.nrTelefonu;
        }
        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (name_box.Text != "" && surname_box.Text != "" && address_box.Text != "" && number_box.Text != "")
            {
                using (var db = new ArLibCon())
                {
                    var editedReader = db.Readers.SingleOrDefault(b => b.ID == StaticTemp.selectedReader.ID);
                    editedReader.imię = name_box.Text;
                    editedReader.nazwisko = surname_box.Text;
                    editedReader.adres = address_box.Text;
                    editedReader.nrTelefonu = number_box.Text;
                    db.SaveChanges();
                }
                tmp_label.Content = "Pomyślnie zmieniono! Wciśnij Powrót.";
            }
            else
                tmp_label.Content = "Uzupełnij wszystkie wymagane pola!";
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SearchReaderPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
