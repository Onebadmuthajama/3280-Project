using System.Collections.Generic;
using System.Windows;
using GroupAssignment.Models;

namespace GroupAssignment.Items {
    /// <summary>
    /// class that provides logic for itemsWindow, talks to itemsSQL often to get input
    /// </summary>
    internal class clsItemsLogic {
        private readonly clsItemsSQL _sql;
        /// <summary>
        /// int for keepint track of itemCode from itemsWindow
        /// </summary>
        private int _code;
        /// <summary>
        /// initilizes classes for using sQl
        /// </summary>
        public clsItemsLogic() {
            _sql = new clsItemsSQL();
            _code = _sql.GetLastCode();
        }
        /// <summary>
        /// talks to SQL clss to getItems 
        /// </summary>
        /// <returns></returns>
        public List<ItemDescription> GetItems() {
            BumpCode();
            return _sql.GetItems();
        }
        /// <summary>
        /// talks to SQL to add item and bumps code number to the next int.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ItemDescription item) {
            BumpCode();
            _sql.AddItem(item);
        }
        /// <summary>
        /// talks to sql to delete an item from the DB
        /// </summary>
        /// <param name="item"></param>

        public void DeleteItem(ItemDescription item) {
            if (_sql.InUse(item.ItemCode) == false) {
                _sql.DeleteItem(item.ItemCode);
            }
            else {
                MessageBox.Show("Item number " + item.ItemCode + " is still in use on invoice " + _sql.UsedOnInvoice(item.ItemCode));
            }
        }
        /// <summary>
        /// this is updating item
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(ItemDescription item) {
            _sql.UpdateItem(item);
        }
        /// <summary>
        /// returns code id 
        /// </summary>
        /// <returns></returns>
        public int GetId() {
            return _code;
        }
        /// <summary>
        /// methoid to bump code
        /// </summary>
        private void BumpCode() {
            _code++;
        }
    }
}