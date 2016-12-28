using System;
using System.Windows;
using System.Windows.Controls;
using ArLib.Classes;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Administrator admin = new Administrator();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (login_tb.Text == admin.login && password_tb.Password == admin.hasło)
                this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
            else
                tmp_label.Content = "Podano błędny login i/lub hasło!";
        }
    }
}
