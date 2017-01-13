using ArLib.Classes;
using System;
using System.Linq;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for RestorePasswordPage.xaml
    /// </summary>
    public partial class RestorePasswordPage : Page
    {
        public RestorePasswordPage()
        {
            InitializeComponent();
        }
        private void restore_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                var adm = db.Administration.First();

                if (name_box.Text != "" && surname_box.Text != "" && login_box.Text != "")
                    if (name_box.Text == adm.imię && surname_box.Text == adm.nazwisko && login_box.Text == adm.login)
                    {
                        Random random = new Random();
                        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        string hasło = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
                        adm.hasło = hasło;
                        db.SaveChanges();

                        label.Content = "Nowe hasło użytkownika to: " + hasło;
                    }
                else
                    label.Content = "Podano nieprawidłowe dane!";
            }
        }
        private void back_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
