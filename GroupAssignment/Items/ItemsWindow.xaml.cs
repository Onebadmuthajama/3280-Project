using System;
using System.Windows;
using System.Data;
using GroupAssignment.Models;
using System.Collections.Generic;

namespace GroupAssignment.Items {
    /// <summary>
    ///     Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        clsItemsLogic logic;
        String itemDescription;
        double itemCost;
        int itemCode;
        private List<LineItems> _items;
        /// <summary>
        /// Eventually, this will be where an item will be updated, and data will be sent to the database
        /// </summary>
        /// 

        public ItemsWindow()
        {
            _items = new List<LineItems>();
            logic = new clsItemsLogic();
            InitializeComponent();
          //  updateTable();
           
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
            if (!(String.IsNullOrEmpty(textBoxCode.Text))) itemCode = Int32.Parse(textBoxCode.Text);
            else itemCode = 0;
            if (!(String.IsNullOrEmpty(textBoxCost.Text))) itemCost = Double.Parse(textBoxCost.Text);
            else itemCost = 0;
            if (!(String.IsNullOrEmpty(txtBoxDescription.Text))) itemDescription = txtBoxDescription.Text;
            else itemDescription = null;

            if (radioButtonAdd.IsChecked == true)
            {
                logic.addItem(itemDescription, System.Convert.ToDecimal(itemCost));
            }
            if (radioButtonDelete.IsChecked == true)
            {
                logic.deleteItem(itemCode);
            }
            if (radioButtonUpdate.IsChecked == true)
            {
                decimal d = System.Convert.ToDecimal(itemCost);
                logic.updateItem(itemCode, itemDescription, (System.Convert.ToDecimal(itemCost)));
            }
            updateTable();
            


        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public void updateTable()
        {
            
            DataGridItems.ItemsSource = null;
            DataGridItems.ItemsSource = _items;
            //logic.getItems()
        }



    }
}