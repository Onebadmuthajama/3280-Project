using System.Windows;
using System.Data;
using GroupAssignment.Main;
using GroupAssignment.Models;
using System.Collections.Generic;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        clsSearchLogic _searchLogic;
        clsSearchSQL _searchSQL;

        List<Invoice> invoiceList;

        public SearchWindow(MainWindow mainWindow) {
        //public SearchWindow() { 
            //start up the search logic
            _searchLogic = new clsSearchLogic();
            _searchSQL = new clsSearchSQL();

            invoiceList = _searchSQL.GetAllItems();


            InitializeComponent();

            //set up comboboxes
            numFilter.ItemsSource = invoiceList;
            //dateFilter.ItemsSource = ;
            //chargeFilter.ItemsSource = ;

            //populate datagrid with Invoices
            listDisplay.ItemsSource = invoiceList;

            

        }

        /// <summary>
        ///     Closes the window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void CloseWindow(object sender, RoutedEventArgs e) {
            Close();
        }

        /// <summary>
        ///     Sets main window invoice number and closes this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInvoice(object sender, RoutedEventArgs e)
        {
            int pass = invoiceList[listDisplay.SelectedIndex].InvoiceNumber;
            MessageBox.Show(pass.ToString(), "a", MessageBoxButton.OK);
            //set main invoice num
            Close();
        }
    }
}