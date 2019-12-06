using System.Windows;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        clsSearchLogic sl;

        public SearchWindow() {
            InitializeComponent();

            //start up the search logic
            sl = new clsSearchLogic();

            //populate datagrid with Invoices
            listDisplay.DataContext = sl.getItems();
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