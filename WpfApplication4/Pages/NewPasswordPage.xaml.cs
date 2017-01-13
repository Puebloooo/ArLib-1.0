using ArLib.Classes;
using System;
using System.Linq;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for NewPasswordPage.xaml
    /// </summary>
    public partial class NewPasswordPage : Page
    {
        public NewPasswordPage()
        {
            InitializeComponent();
        }
        private void change_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                var adm = db.Administration.First();

                if (login_box.Text != "" && old_password_box.Password != "" && new_password_box.Password != "")
                {
                    if (login_box.Text == adm.login && old_password_box.Password == adm.hasło)
                    {
                        adm.hasło = new_password_box.Password;
                        db.SaveChanges();
                        label.Content = "Poprawnie zmieniono hasło.";
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
