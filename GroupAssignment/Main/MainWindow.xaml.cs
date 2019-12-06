using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GroupAssignment.Items;
using GroupAssignment.Models;
using GroupAssignment.Search;

namespace GroupAssignment.Main {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly List<LineItems> _items;
        private readonly clsMainLogic _mainLogic;
        private readonly clsMainSql _mainSql;

        private int _invoiceId;

        public MainWindow() {
            _mainLogic = new clsMainLogic();
            _mainSql = new clsMainSql();
            _items = new List<LineItems>();

            InitializeComponent();
            SelectItemComboBox.ItemsSource = _mainSql.GetAllItems();
            ItemDataGrid.ItemsSource = _items;
        }

        /// <summary>
        ///     opens the search window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenSearchWindow(object sender, RoutedEventArgs e) {
            var sw = new SearchWindow(this);
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
            var lineItem = (LineItems) ItemDataGrid.SelectedItem;
            _items.Remove(lineItem);
            UpdateDataGridContent();
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
            _invoiceId = _mainSql.GetLargestInvoiceId() + 1;
            InvoiceIdTextBox.Text = _invoiceId.ToString();
            InvoiceDatePicker.SelectedDate = DateTime.Now;
            InvoiceCostTextBox.Text = "$0.00";
            ItemCostTextBox.IsEnabled = true;
            SelectItemComboBox.IsEnabled = true;
            AddItemButton.IsEnabled = true;
//            DeleteItemButton.IsEnabled = true;
            ItemDataGrid.IsEnabled = true;  
            NewInvoiceButton.IsEnabled = false;
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
            var totalCost = new decimal(0.00);
            var lineItem = _mainLogic.ParseItemDesc((ItemDescription) SelectItemComboBox.SelectedItem, _invoiceId);
            _items.Add(lineItem);
            totalCost += _items.Sum(item => item.ItemCost);
            InvoiceCostTextBox.Text = totalCost.ToString("$0.00");
            UpdateDataGridContent();
        }

        private void UpdateDataGridContent() {
            ItemDataGrid.ItemsSource = null;
            ItemDataGrid.ItemsSource = _items;
        }

        private void UpdateSelectedItemTextBoxContent(object sender, SelectionChangedEventArgs selectionChangedEventArgs) {
            ItemCostTextBox.Text = ((ItemDescription) SelectItemComboBox.SelectedItem).ItemCost.ToString("$0.00");
        }

        private void UpdateDeleteItemButton(object sender, SelectionChangedEventArgs e) {
            DeleteItemButton.IsEnabled = ((DataGrid) sender).SelectedItems.Count >= 1;
        }
    }
}