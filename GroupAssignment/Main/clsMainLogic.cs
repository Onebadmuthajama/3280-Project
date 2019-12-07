using GroupAssignment.Models;

namespace GroupAssignment.Main {
    internal class clsMainLogic {
        public clsMainLogic() {
        }

        /// <summary>
        ///     Converts an ItemDescription object to a LineItems object
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public LineItems ParseItemDescriptionToLineItem(ItemDescription itemDescription, int invoiceId) {
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