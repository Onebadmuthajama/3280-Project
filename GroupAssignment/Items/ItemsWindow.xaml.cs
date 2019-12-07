using System.Windows;
using GroupAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace GroupAssignment.Items {
    /// <summary>
    ///     Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window {
        private readonly clsItemsLogic _logic;

        private List<ItemDescription> _items;
        private ItemDescription _item;

        /// <summary>
        ///     Eventually, this will be where an item will be updated, and data will be sent to the database
        /// </summary>
        public ItemsWindow() {
            _items = new List<ItemDescription>();
            _logic = new clsItemsLogic();
            _item = new ItemDescription();

            InitializeComponent();

            _items = _logic.GetItems();
            DataGridItems.ItemsSource = _items;
        }

        private void DataGridItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (DataGridItems.SelectedItem == null) {
                return;
            }

            textBoxCode.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemCode.ToString();
            textBoxCost.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemCost.ToString();
            textBoxDescription.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemDesc;
        }

        private void RadioButtonDelete_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = true;
            textBoxDescription.IsEnabled = false;
            textBoxCost.IsEnabled = false;
        }

        private void RadioButtonUpdate_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = false;
            textBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;
        }

        private void RadioButtonAdd_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = false;
            textBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) {
            _item.ItemDesc = textBoxDescription.Text;
            _item.ItemCode = _logic.GetId();

            if (textBoxDescription.Text == string.Empty) {
                _item.ItemDesc = "NULL";
            }

            if (radioButtonAdd.IsChecked == true && ValidateAdd()) {
                _logic.AddItem(_item);
                _items.Add(_item);
            }

            if (radioButtonDelete.IsChecked == true && ValidateDelete()) {
                _logic.DeleteItem(_item);
                _items.Remove(_items.FirstOrDefault(x => x.ItemCode == int.Parse(textBoxCode.Text)));
            }

            if (radioButtonUpdate.IsChecked == true && ValidateUpdate()) {
                _logic.UpdateItem(_item);
                _items = _logic.GetItems();
            }

            _item = new ItemDescription();

            UpdateTable();
        }

        private void Validate(string action) {
            int.TryParse(textBoxCode.Text, out var i);
            MessageBox.Show($"{action} is a number only field");
        }

        private bool ValidateAdd() {
            try {
                double.Parse(textBoxCost.Text);
            }
            catch {
                Validate("cost");
                return false;
            }

            if (!string.IsNullOrEmpty(textBoxCost.Text)) {
                _item.ItemCost = decimal.Parse(textBoxCost.Text);
            }

            return true;
        }

        private bool ValidateUpdate() {
            try {
                double.Parse(textBoxCost.Text);
                int.Parse(textBoxCode.Text);
            }
            catch {
                Validate("code or cost");
                return false;
            }

            if (!string.IsNullOrEmpty(textBoxCode.Text)) _item.ItemCode = int.Parse(textBoxCode.Text);
            if (!string.IsNullOrEmpty(textBoxCost.Text)) _item.ItemCost = decimal.Parse(textBoxCost.Text);

            return true;
        }

        private bool ValidateDelete() {
            try {
                int.Parse(textBoxCode.Text);
            }
            catch {
                Validate("code");
                return false;
            }

            if (!string.IsNullOrEmpty(textBoxCode.Text)) _item.ItemCode = int.Parse(textBoxCode.Text); 

            return true;
        }

        private void UpdateTable() {
            DataGridItems.ItemsSource = null;
            DataGridItems.ItemsSource = _items;
        }
    }
}