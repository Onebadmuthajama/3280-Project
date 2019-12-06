using System;
using System.Collections.Generic;
using System.Windows;
using GroupAssignment.Items;
using GroupAssignment.Models;
using GroupAssignment.Search;

namespace GroupAssignment.Main {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly int _invoiceId;
        private readonly List<LineItems> _items;
        private readonly clsMainLogic _mainLogic;
        private readonly clsMainSql _mainSql;

        public MainWindow() {
            _mainLogic = new clsMainLogic();
            _mainSql = new clsMainSql();

            InitializeComponent();

            SelectItemComboBox.ItemsSource = _mainSql.GetAllItems();

            _items = _mainSql.GetAllItemsForInvoice(5000);
            _invoiceId = _items[0].InvoiceNum;
            ItemDataGrid.ItemsSource = _items;
        }

        /// <summary>
        ///     opens the search window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenSearchWindow(object sender, RoutedEventArgs e) {
            var sw = new SearchWindow();
            sw.ShowDialog();
        }

        /// <summary>
        ///     opens the item window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenItemWindow(object sender, RoutedEventArgs e) {
            var sw = new ItemsWindow();
            sw.ShowDialog();
        }

        /// <summary>
        ///     Event Handler for the Delete Item button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem(object sender, RoutedEventArgs e) {
            var lineItem = ((LineItems) ItemDataGrid.SelectedItem);
            _items.Remove(lineItem);

            ItemDataGrid.ItemsSource = null;
            ItemDataGrid.ItemsSource = _items;
        }

        /// <summary>
        ///     Event Handler for the Save Changes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChanges(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Event Handler for the Edit Invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoice(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Event Handler for the New Invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Event Handler for the Delete Invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoice(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Event Handler for the Cancel Changes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelChanges(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Event Handler for the Add Item button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem(object sender, RoutedEventArgs e) {
            var lineItem = _mainLogic.ParseItemDesc((ItemDescription) SelectItemComboBox.SelectedItem, _invoiceId);
            _items.Add(lineItem);
            ItemDataGrid.ItemsSource = null;
            ItemDataGrid.ItemsSource = _items;
        }
    }
}