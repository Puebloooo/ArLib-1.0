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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class TakeBookPage : Page
    {
        public TakeBookPage()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                results_readers.ItemsSource = db.Readers.ToList();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = search_textBox.Text;

                var query = from reader in db.Readers
                            where (reader.ID.ToString().Contains(tmp)|| reader.imię.Contains(tmp) || reader.nazwisko.Contains(tmp) ||  reader.adres.Contains(tmp) || reader.nrTelefonu.Contains(tmp))
                            select reader;

                results_readers.ItemsSource = query.ToList();
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void transaction_button_Click(object sender, RoutedEventArgs e)
        {
            StaticTransaction.selectedReader = (Reader)results_readers.SelectedItem;
            Transaction tmp = new Transaction(StaticTransaction.selectedBook, StaticTransaction.selectedReader);

            using (var db = new ArLibCon())
            {
                var result = db.Books.SingleOrDefault(b => b.ID == StaticTransaction.selectedBook.ID);
                var result2 = db.Readers.SingleOrDefault(b => b.ID == StaticTransaction.selectedReader.ID);

                if (result != null && result2 != null && StaticTransaction.selectedReader.limitWypożyczeń > 0 && StaticTransaction.selectedBook.czyWypożyczona == false)
                {
                    result.czyWypożyczona = true;
                    result2.limitWypożyczeń -= 1;
                    db.Transactions.Add(tmp);

                    db.SaveChanges();

                    tmp_label.Content = "Pomyślnie dodano! Wciśnij powrót!";
                }
                else if (StaticTransaction.selectedReader.limitWypożyczeń <= 0)
                    tmp_label.Content = "Użytkownik nie może wypożyczyć \nwięcej książek!";
                else if (StaticTransaction.selectedBook.czyWypożyczona == true)
                    tmp_label.Content = "Książka już została wypożyczona!";
                else
                    tmp_label.Content = "Nastąpił problem przy wypożyczeniu. \nWciśnij powrót i spróbuj ponownie.";
            }
        }
    }
}
