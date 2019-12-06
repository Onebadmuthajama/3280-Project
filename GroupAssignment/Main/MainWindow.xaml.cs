using System;
using System.Windows;
using GroupAssignment.Items;
using GroupAssignment.Search;

namespace GroupAssignment.Main {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly clsMainLogic _mainLogic;
        private readonly clsMainSql _mainSql;

        public MainWindow() {
            _mainLogic = new clsMainLogic();
            _mainSql = new clsMainSql();
            InitializeComponent();
            SelectItemComboBox.ItemsSource = _mainSql.GetAllItems();
            ItemDataGrid.ItemsSource = _mainSql.GetAllItemsForInvoice(5000);
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
            throw new NotImplementedException();
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
        ///     Event Handler for the Save Invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice(object sender, RoutedEventArgs e) {
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
            throw new NotImplementedException();
        }
    }
}