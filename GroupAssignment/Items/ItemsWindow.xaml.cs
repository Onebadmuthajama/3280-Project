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
        readonly clsItemsLogic _logic;
        string _itemDescription;
        double _itemCost;
        private int _itemCode;
        private readonly List<ItemDescription> _items;
        /// <summary>
        /// Eventually, this will be where an item will be updated, and data will be sent to the database
        /// </summary>
        /// 

        public ItemsWindow()
        {
            _items = new List<ItemDescription>();
            _logic = new clsItemsLogic();
            InitializeComponent();

            _items = _logic.getItems();
            DataGridItems.ItemsSource = _items;
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
            if (!(String.IsNullOrEmpty(textBoxCode.Text))) _itemCode = Int32.Parse(textBoxCode.Text);
            else _itemCode = 0;
            if (!(String.IsNullOrEmpty(textBoxCost.Text))) _itemCost = Double.Parse(textBoxCost.Text);
            else _itemCost = 0;
            if (!(String.IsNullOrEmpty(txtBoxDescription.Text))) _itemDescription = txtBoxDescription.Text;
            else _itemDescription = null;

            if (radioButtonAdd.IsChecked == true)
            {
                _logic.addItem(_itemDescription, System.Convert.ToDecimal(_itemCost));
            }
            if (radioButtonDelete.IsChecked == true)
            {
                _logic.deleteItem(_itemCode);
            }
            if (radioButtonUpdate.IsChecked == true)
            {
                decimal d = System.Convert.ToDecimal(_itemCost);
                _logic.updateItem(_itemCode, _itemDescription, (System.Convert.ToDecimal(_itemCost)));
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
        }



    }
}