using System.Collections.Generic;
using System.Windows;
using GroupAssignment.Models;

namespace GroupAssignment.Items {
    internal class clsItemsLogic {
        private readonly clsItemsSQL _sql;

        private int _code;

        public clsItemsLogic() {
            _sql = new clsItemsSQL();
            _code = _sql.GetLastCode();
        }

        public List<ItemDescription> GetItems() {
            BumpCode();
            return _sql.GetItems();
        }

        public void AddItem(ItemDescription item) {
            BumpCode();
            _sql.AddItem(item);
        }

        public void DeleteItem(ItemDescription item) {
            if (_sql.InUse(item.ItemCode) == false) {
                _sql.DeleteItem(item.ItemCode);
            }
            else {
                MessageBox.Show("Item number " + item.ItemCode + " is still in use on invoice " + _sql.UsedOnInvoice(item.ItemCode));
            }
        }

        public void UpdateItem(ItemDescription item) {
            _sql.UpdateItem(item);
        }

        public int GetId() {
            return _code;
        }

        private void BumpCode() {
            _code++;
        }
    }
}