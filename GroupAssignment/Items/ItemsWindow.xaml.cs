using System;
using System.Windows;
using System.Data;

namespace GroupAssignment.Items {
    /// <summary>
    ///     Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        clsItemsLogic logic;
        String itemDescription;
        String itemCost;
        String itemCode;
        /// <summary>
        /// Eventually, this will be where an item will be updated, and data will be sent to the database
        /// </summary>
        /// 

        public ItemsWindow()
        {
            logic = new clsItemsLogic();
            InitializeComponent();
            updateTable();
           
        }

        private void RadioButtonAdd_Checked(object sender, RoutedEventArgs e)
        {
            textBoxCode.IsEnabled = false;
            txtBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;   
        }

        private void RadioButtonDelete_Checked(object sender, RoutedEventArgs e)
        {
            textBoxCode.IsEnabled = true;
            txtBoxDescription.IsEnabled = false;
            textBoxCost.IsEnabled = false;
        }

        private void RadioButtonUpdate_Checked(object sender, RoutedEventArgs e)
        {
            textBoxCode.IsEnabled = true;
            txtBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(textBoxCode.Text))) itemCode = textBoxCode.Text;
            else itemCode = null;
            if (!(String.IsNullOrEmpty(textBoxCost.Text))) itemCost = textBoxCost.Text;
            else itemCost = null;
            if (!(String.IsNullOrEmpty(txtBoxDescription.Text))) itemDescription = txtBoxDescription.Text;
            else itemDescription = null;

            if (radioButtonAdd.IsChecked == true)
            {
                logic.addItem(itemDescription, itemCost);
            }
            if (radioButtonDelete.IsChecked == true)
            {
                logic.deleteItem(itemCode);
            }
            if (radioButtonUpdate.IsChecked == true)
            {
                logic.updateItem(itemCode, itemDescription, itemCost);
            }
            updateTable();
            


        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public void updateTable()
        {
         //   DataGridItems.DataContext = logic.getItems();
        }


    }
}