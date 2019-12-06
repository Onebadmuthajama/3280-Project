using System.Windows;
using System.Data;
using GroupAssignment.Main;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        clsSearchLogic sl;
        DataSet list;

        EnumerableRowCollection<int> invoiceNum;

        public SearchWindow(MainWindow mainWindow) {
            InitializeComponent();

            //start up the search logic
            sl = new clsSearchLogic();
            list = sl.getItems();

            //populate datagrid with Invoices
            //listDisplay.ItemsSource = list.Tables[0].AsEnumerable();

            invoiceNum = list.Tables[0].AsEnumerable().Select(x => x.Field<int>("InvoiceNum"));

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