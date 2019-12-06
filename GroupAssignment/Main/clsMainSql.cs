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
        ///     Returns a data set containing all item descriptions from the database
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

        public int GetLargestInvoiceId() {
            const string sql = "select InvoiceNum from Invoices order by InvoiceNum desc";

            var result = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable().Select(x => x.Field<int>("invoiceNum")).FirstOrDefault();
            return result;
        }

        /// <summary>
        ///     Returns a data set containing items for invoiceId
        /// </summary>
        /// <returns></returns>
        public List<LineItems> GetAllItemsForInvoice(int invoiceId) {
            var sql = $"SELECT LineItems.InvoiceNum, LineItems.LineItemNum, LineItems.ItemCode, ItemDesc.Cost FROM LineItems INNER JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE LineItems.InvoiceNum = {invoiceId};";

            var result = new List<LineItems>();
            var ds = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds) {
                var itemDescription = new LineItems {
                    InvoiceNum = row.Field<int>("InvoiceNum"),
                    LineItemNum = row.Field<int>("LineItemNum"),
                    ItemCode = row.Field<int>("ItemCode"),
                    ItemCost = row.Field<decimal>("Cost")
                };

                result.Add(itemDescription);
            }

            return result;
        }
    }
}