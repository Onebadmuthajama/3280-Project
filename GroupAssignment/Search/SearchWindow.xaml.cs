using System;
using System.Windows;
//using System.Data;
using GroupAssignment.Main;
using GroupAssignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        
        
        //current main window to return invoice number to
        MainWindow currentMain;

        //logic class
        clsSearchLogic _searchLogic;

        //list of actual invoice objects
        List<Invoice> invoiceList;
        //lists for sorting
        List<int> numberList;
        List<DateTime> dateList;
        List<int> costList;


        /// <summary>
        /// Open window and do initial setup of datagrid and comboboxes
        /// </summary>
        /// <param name="mainWindow"></param>
        public SearchWindow(MainWindow mainWindow) {
            //store main window
            currentMain = mainWindow;

            //start up the search logic
            _searchLogic = new clsSearchLogic();

            //populate datagrid with initial unsorted invoices
            invoiceList = _searchLogic.GetAllItems();

            //populate comboboxes
            numberList = _searchLogic.Get<int>("InvoiceNum").Distinct().ToList();
            numberList.Sort();
            dateList = _searchLogic.Get<DateTime>("InvoiceDate").Distinct().ToList();
            dateList.Sort();
            costList = _searchLogic.Get<int>("TotalCost").Distinct().ToList();
            costList.Sort();


            //set up visual
            InitializeComponent();
            //disable select button to prevent selecting nothing
            selectButton.IsEnabled = false;

            //set up comboboxes
            numFilter.ItemsSource = numberList;
            dateFilter.ItemsSource = dateList;
            chargeFilter.ItemsSource = costList;

            //populate datagrid with Invoices
            listDisplay.ItemsSource = invoiceList;

        }

        /// <summary>
        /// refill datagrid with filtered query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSearch(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //disable select button to prevent selecting nothing
            selectButton.IsEnabled = false;

            int? n = null;
            if (numFilter.SelectedIndex != -1)
            {
                n = numberList[numFilter.SelectedIndex];
            }
            DateTime? d = null;
            if (dateFilter.SelectedIndex != -1)
            {
                d = dateList[dateFilter.SelectedIndex];

            }
            int? c = null;
            if (chargeFilter.SelectedIndex != -1) {
                c = costList[chargeFilter.SelectedIndex];
            }

            /*
             * This would narrow down all comboboxes when one option is selected.
             * It's commented out because it can get annoying
             * 
            //populate comboboxes
            numberList = _searchLogic.Get<int>("InvoiceNum",n,d,c).Distinct().ToList();
            numberList.Sort();
            dateList = _searchLogic.Get<DateTime>("InvoiceDate", n, d, c).Distinct().ToList();
            dateList.Sort();
            costList = _searchLogic.Get<int>("TotalCost", n, d, c).Distinct().ToList();
            costList.Sort();

            //set up comboboxes
            numFilter.ItemsSource = numberList;
            dateFilter.ItemsSource = dateList;
            chargeFilter.ItemsSource = costList;
            */

            //populate datagrid with sorted invoices
            invoiceList = _searchLogic.Get(n, d, c);

            //set up datagrid
            listDisplay.ItemsSource = invoiceList;


        }

        /// <summary>
        ///     When a DataGrid item is selected and in bounds of the invoice list, make the select button active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //only enable if selection is in bounds
            if (listDisplay.SelectedIndex < invoiceList.Count() & listDisplay.SelectedIndex > -1)
            {
                selectButton.IsEnabled = true;
            }
            else
            {
                selectButton.IsEnabled = false;
            }
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
            try
            {
                //set main invoice num
                currentMain.InvoiceIdTextBox.Text = invoiceList[listDisplay.SelectedIndex].InvoiceNumber.ToString();
                Close();
            }
            catch(Exception ex)
            {
                throw new Exception($"SearchWindow.SelectInvoice encountered an error. - {ex}");
            }
        }

        
    }
}