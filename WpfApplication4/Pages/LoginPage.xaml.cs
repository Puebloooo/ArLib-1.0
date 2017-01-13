using System;
using System.Windows;
using System.Windows.Controls;
using ArLib.Classes;
using System.Linq;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                var adm = db.Administration.First();
                if (login_tb.Text == adm.login && password_tb.Password == adm.hasło)
                    NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
                else
                    tmp_label.Content = "Podano błędny login i/lub hasło!";
            }
        }
        private void restorePassword_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/RestorePasswordPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
