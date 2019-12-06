using GroupAssignment.Models;

namespace GroupAssignment.Main {
    internal class clsMainLogic {
        public clsMainLogic() {
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