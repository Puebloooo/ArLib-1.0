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
    /// Interaction logic for AddReaderPage.xaml
    /// </summary>
    public partial class AddReaderPage : Page
    {
        public AddReaderPage()
        {
            InitializeComponent();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (name_box.Text != "" && surname_box.Text != "" && address_box.Text != "" && number_box.Text != "" )
            {
                Reader tmp = new Reader(name_box.Text, surname_box.Text, address_box.Text, number_box.Text);
                using (var db = new ArLibCon())
                {
                    db.Readers.Add(tmp);
                    db.SaveChanges();
                }
                tmp_label.Content = "Pomyślnie dodano! Wciśnij Powrót.";
            }
            else
                tmp_label.Content = "Uzupełnij wszystkie pola!";
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
