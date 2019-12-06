using System.Windows;
using System.Data;
using GroupAssignment.Models;
using System.Collections.Generic;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        clsSearchLogic sl;
        List<Invoice> list;

        EnumerableRowCollection<int> invoiceNum;

        public SearchWindow() {
            InitializeComponent();

            //start up the search logic
            sl = new clsSearchLogic();
            list = sl.getAllItems();

            //populate datagrid with Invoices
            listDisplay.ItemsSource = list;

            

        }

        /// <summary>
        ///     Closes the window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void CloseWindow(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}