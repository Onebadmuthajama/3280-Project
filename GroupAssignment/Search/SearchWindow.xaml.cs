using System.Windows;
using GroupAssignment.Items;

namespace GroupAssignment.Search {
    /// <summary>
    ///     Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window {
        public SearchWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// opens items window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenItemsWindow(object sender, RoutedEventArgs e) {
            var iw = new ItemsWindow();
            Close();
            iw.ShowDialog();
        }
    }
}