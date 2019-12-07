using System.Windows;
using GroupAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace GroupAssignment.Items {
    /// <summary>
    ///     This is where the item is displayed, selected, deleted, updated, and added. 
    /// </summary>
    public partial class ItemsWindow : Window {
        private readonly clsItemsLogic _logic;

        private List<ItemDescription> _items;
        private ItemDescription _item;

        /// <summary>
        ///     initilizes items logic and sql, then fills datagrid with feteched items  
        /// </summary>
        public ItemsWindow() {

            _items = new List<ItemDescription>();
            _logic = new clsItemsLogic();
            _item = new ItemDescription();

            InitializeComponent();

            _items = _logic.GetItems();
            DataGridItems.ItemsSource = _items;
        }
        /// <summary>
        /// sends text to datagrid items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (DataGridItems.SelectedItem == null) {
                return;
            }

            textBoxCode.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemCode.ToString();
            textBoxCost.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemCost.ToString();
            textBoxDescription.Text = ((ItemDescription)DataGridItems.SelectedItem).ItemDesc;
        }
        /// <summary>
        /// determines what user wants to do based on radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonDelete_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = true;
            textBoxDescription.IsEnabled = false;
            textBoxCost.IsEnabled = false;
        }
        /// <summary>
        /// determines what user wants to do based on radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonUpdate_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = false;
            textBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;
        }
        /// <summary>
        /// determines what user wants to do based on radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonAdd_Checked(object sender, RoutedEventArgs e) {
            textBoxCode.IsEnabled = false;
            textBoxDescription.IsEnabled = true;
            textBoxCost.IsEnabled = true;
        }
        /// <summary>
        /// goes back to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e) {
            Close();
        }
        /// <summary>
        /// event is based on previous methods. if update will update description and or cost based on itemCode. if new will add new item with auto 
        /// generated itemCode, inputed descritpion and cost. If delete will delete based on ItemCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// validate user input to make sure they are only using numbers in cost and code
        /// </summary>
        /// <param name="action"></param>
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
        /// <summary>
        /// used to validate the input when user selects update
        /// </summary>
        /// <returns></returns>

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
        /// <summary>
        /// used to validate input when user selects delete
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// updates table after items have been updated, added, or deleted
        /// </summary>

        private void UpdateTable() {
            DataGridItems.ItemsSource = null;
            DataGridItems.ItemsSource = _items;
        }
    }
}