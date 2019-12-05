using System.Windows;
using GroupAssignment.Items;
using GroupAssignment.Search;

namespace GroupAssignment.Main {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// opens the search window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenSearchWindow(object sender, RoutedEventArgs e) {
            var sw = new SearchWindow();
            sw.ShowDialog();
        }

        /// <summary>
        /// opens the item window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenItemWindow(object sender, RoutedEventArgs e) {
            var sw = new ItemsWindow();
            sw.ShowDialog();
        }

        private void BtnToItems_Click(object sender, RoutedEventArgs e)
        {
            var iw = new ItemsWindow();
            Close();
            iw.ShowDialog();
        }
    }
}