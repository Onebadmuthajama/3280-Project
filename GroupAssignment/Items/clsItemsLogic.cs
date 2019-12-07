using System.Collections.Generic;
using System.Windows;
using GroupAssignment.Models;

namespace GroupAssignment.Items {
    internal class clsItemsLogic {
        private static int code;

        private readonly clsItemsSQL iSQL;

        public clsItemsLogic() {
            iSQL = new clsItemsSQL();
            code = iSQL.getLastCode();
        }

        public List<ItemDescription> getItems() {
            return iSQL.GetAllItemsForItems();
        }

        public void addItem(string itemDescription, decimal itemCost) {
            bumpCode();
            iSQL.addItem(code, itemDescription, itemCost);
        }

        public void deleteItem(int itemCode) {
            if (iSQL.inUse(itemCode) == false)
                iSQL.deleteItem(itemCode);
            else
                MessageBox.Show("Item number " + itemCode + " is still in use on invoice " + iSQL.usedOnInvoice(itemCode));
        }

        public void updateItem(int code, string itemDescription, decimal itemCost) {
            if (itemDescription != null && itemCost != 0) {
                iSQL.updateItemCost(code, itemCost);
                iSQL.updateItemDesc(code, itemDescription);
            }
            else if (itemDescription != null && itemCost == 0) {
                iSQL.updateItemDesc(code, itemDescription);
            }
            else if (itemCost != 0 && itemDescription == null) {
                iSQL.updateItemCost(code, itemCost);
            }
            else {
                MessageBox.Show("What did you want to upate?");
            }
        }

        public void bumpCode() {
            code++;
        }

        public LineItems ParseItemDesc(ItemDescription itemDescription, int invoiceId) {
            var lineItem = new LineItems {
                InvoiceNum = invoiceId,
                ItemCode = itemDescription.ItemCode,
                LineItemNum = itemDescription.ItemCode,
                ItemCost = itemDescription.ItemCost
            };

            return lineItem;
        }
    }
}