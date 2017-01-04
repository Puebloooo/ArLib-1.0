﻿using ArLib.Classes;
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
    public partial class SearchTransactionPage : Page
    {
        public SearchTransactionPage()
        {
            InitializeComponent();
            using (var db = new ArLibCon())
            {
                results_transactions.ItemsSource = db.Transactions.ToList();
            }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ArLibCon())
            {
                string tmp = quicksearch_tb.Text;

                var query = from transaction in db.Transactions
                            where (transaction.idWypożyczenia.ToString().Contains(tmp) || transaction.idKsiążki.ToString().Contains(tmp) || transaction.idCzytelnika.ToString().Contains(tmp))
                            select transaction;

                results_transactions.ItemsSource = query.ToList();
            }
        }
        private void returnBook_Click(object sender, RoutedEventArgs e)
        {
            if (results_transactions.SelectedItem != null)
                using (var db = new ArLibCon())
                {
                    Transaction selected = (Transaction)results_transactions.SelectedItem;
                    var selectedBook = db.Books.SingleOrDefault(b => b.ID == selected.idKsiążki);
                    if (selectedBook.czyWypożyczona == true)
                    {
                        var transaction = db.Transactions.SingleOrDefault(b => (b.idKsiążki == selectedBook.ID && b.czyZwrócona == false));
                        var reader = db.Readers.SingleOrDefault(b => b.ID == transaction.idCzytelnika);
                        var book = db.Books.SingleOrDefault(b => b.ID == selectedBook.ID);

                        transaction.dataZwrotu = DateTime.Today;
                        transaction.czyZwrócona = true;
                        reader.limitWypożyczeń += 1;
                        book.czyWypożyczona = false;

                        db.SaveChanges();
                        MessageBox.Show("Pomyślnie zwrócono książkę!");
                        NavigationService.Refresh();
                    }
                }
        }
        private void deleteTransaction_button_Click(object sender, RoutedEventArgs e)
        {
            if (results_transactions.SelectedItem != null)
                if (MessageBox.Show("Czy na pewno usunąć?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new ArLibCon())
                    {
                        Transaction tmp = (Transaction)results_transactions.SelectedItem;

                        var query = from transaction in db.Transactions
                                    where transaction.idWypożyczenia == tmp.idWypożyczenia
                                    select transaction;

                        db.Transactions.RemoveRange(query);
                        db.SaveChanges();
                        NavigationService.Refresh();
                    }
        }
    }
}
