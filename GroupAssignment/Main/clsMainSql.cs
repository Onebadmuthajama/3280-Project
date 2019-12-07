using System.Collections.Generic;
using System.Data;
using System.Linq;
using GroupAssignment.Models;

namespace GroupAssignment.Main {
    internal class clsMainSql {
        private readonly clsDataAccess _dataAccess;

        public clsMainSql() {
            _dataAccess = new clsDataAccess();
        }

        /// <summary>
        ///     Returns a list of ItemDesc object
        /// </summary>
        /// <returns></returns>
        public List<ItemDescription> GetAllItems() {
            const string sql = "select * from ItemDesc";

            var result = new List<ItemDescription>();
            var ds = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds) {
                var itemDescription = new ItemDescription {
                    ItemCode = row.Field<int>("ItemCode"),
                    ItemDesc = row.Field<string>("ItemDesc"),
                    ItemCost = row.Field<decimal>("Cost")
                };

                result.Add(itemDescription);
            }

            return result;
        }

        /// <summary>
        ///     Returns an int representing the largest invoiceNum in the database
        /// </summary>
        /// <returns></returns>
        public int GetLargestInvoiceId() {
            const string sql = "select InvoiceNum from Invoices order by InvoiceNum desc";

            var result = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable().Select(x => x.Field<int>("invoiceNum")).FirstOrDefault();
            return result;
        }

        /// <summary>
        ///     Returns an int representing the largest lineItemNum in the database
        /// </summary>
        /// <returns></returns>
        public int GetLargestLineItemId() {
            const string sql = "select LineItemNum from LineItems order by LineItemNum desc";

            var result = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable().Select(x => x.Field<int>("LineItemNum")).FirstOrDefault();
            return result;
        }

        /// <summary>
        ///     Deletes the invoice from the database for the passed in Id
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public int DeleteInvoice(int invoiceId) {
            var sql = $"Delete from Invoices where InvoiceNum = {invoiceId}";

            var result = _dataAccess.ExecuteNonQuery(sql);

            return result;
        }

        /// <summary>
        ///     Deletes invoice, and child rows associated to the invoice, then adds the invoice + children.  The order of operations is there to handle updates.
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="items"></param>
        public void AddInvoice(Invoice invoice, List<LineItems> items) {
            var sql = ($"Insert Into [Invoices] (InvoiceNum, InvoiceDate, TotalCost) Values({invoice.InvoiceNumber}, {invoice.InvoiceDate.Value:MM/dd/yyyy}, {invoice.TotalCost});");
            DeleteInvoice(invoice.InvoiceNumber);

            _dataAccess.ExecuteNonQuery(sql);

            sql = ($"Delete from [LineItems] where InvoiceNum = {invoice.InvoiceNumber};");
            _dataAccess.ExecuteNonQuery(sql);

            foreach (var item in items) {
                sql = ($"Insert Into [LineItems] (InvoiceNum, LineItemNum, ItemCode) Values({item.InvoiceNum}, {item.LineItemNum}, {item.ItemCode});");
                _dataAccess.ExecuteNonQuery(sql);
            }
        }
    }
}