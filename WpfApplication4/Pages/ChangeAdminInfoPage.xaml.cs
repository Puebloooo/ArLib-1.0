using ArLib.Classes;
using System;
using System.Linq;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for ChangeAdminInfoPage.xaml
    /// </summary>
    public partial class ChangeAdminInfoPage : Page
    {
        public ChangeAdminInfoPage()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                var adm = db.Administration.First();
                name_box.Text = adm.imię;
                surname_box.Text = adm.nazwisko;
                login_box.Text = adm.login;
            }
        }
        private void change_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                var adm = db.Administration.First();

                if (name_box.Text != "" && surname_box.Text != "" && login_box.Text != "" && password_box.Password != "")
                {
                    if (password_box.Password == adm.hasło)
                    {
                        adm.imię = name_box.Text;
                        adm.nazwisko = surname_box.Text;
                        adm.login = login_box.Text;

                        label.Content = "Dane zmieniono poprawnie.";

                        db.SaveChanges();
                    }
                }
                else
                    label.Content = "Uzupełnij wszystkie dane poprawnie!";
            }
        }
        private void back_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
