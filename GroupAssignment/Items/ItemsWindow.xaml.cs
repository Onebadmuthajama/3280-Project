using System.Windows;

namespace GroupAssignment.Items {
    /// <summary>
    ///     Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        clsItemsLogic logic;
        /// <summary>
        /// Eventually, this will be where an item will be updated, and data will be sent to the database
        /// </summary>
        public ItemsWindow()
        {
            logic = new clsItemsLogic();
            InitializeComponent();

           // DataGridItems.ItemsSource = logic.getItems();


        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}