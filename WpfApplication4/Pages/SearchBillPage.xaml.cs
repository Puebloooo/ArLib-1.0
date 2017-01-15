using ArLib.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ArLib.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchBillPage : Page
    {
        public SearchBillPage()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                results_bills.ItemsSource = db.Bills.ToList();
            }
        }
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = quicksearch_tb.Text;

                var query = db.Bills.Where(Bill => (Bill.idKary.ToString().Contains(tmp) || Bill.wartość.ToString().Contains(tmp) || Bill.idCzytelnika.ToString().Contains(tmp)));
                results_bills.ItemsSource = query.ToList();
            }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void deleteBill_button_Click(object sender, RoutedEventArgs e)
        {
            if (results_bills.SelectedItem != null)
                if (MessageBox.Show("Czy na pewno usunąć?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new ArLibCon())
                    {
                        Bill tmp = (Bill)results_bills.SelectedItem;
                        var query = db.Bills.Where(bill => bill.idKary == tmp.idKary);

                        db.Bills.RemoveRange(query);
                        db.SaveChanges();
                        NavigationService.Refresh();
                    }
        }

        private void payBill_button_Click(object sender, RoutedEventArgs e)
        {
            if (results_bills.SelectedItem != null)
                using (var db = new ArLibCon())
                {
                    Bill tmp = (Bill)results_bills.SelectedItem;
                    var chosen = db.Bills.SingleOrDefault(bill => bill.idKary == tmp.idKary);

                    chosen.czyOpłacona = true;
                    db.SaveChanges();
                    NavigationService.Refresh();
                }
        }
    }
}
