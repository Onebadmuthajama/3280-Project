using System;
using System.Collections.Generic;
using System.Data;
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
                    ItemCode = row.Field<string>("ItemCode"),
                    ItemDesc = row.Field<string>("ItemDesc"),
                    ItemCost = row.Field<decimal>("Cost")
                };

                result.Add(itemDescription);
            }

            return result;
        }

        /// <summary>
        ///     Returns a data set containing items for invoiceId
        /// </summary>
        /// <returns></returns>
        public List<LineItems> GetAllItemsForInvoice(int invoiceId) {
//            const string sql = "SELECT InvoiceNum, LineItemNum, ItemCode, Cost FROM [LineItems] JOIN ItemDesc ON [LineItems].ItemCode = ItemDesc.ItemCode";
            const string sql = "SELECT InvoiceNum, LineItemNum, LineItems.ItemCode, Cost FROM [LineItems] JOIN ItemDesc ON [LineItems].ItemCode = ItemDesc.ItemCode";

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

//    SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
//    FROM Orders
//    INNER JOIN Customers ON Orders.CustomerID= Customers.CustomerID;

    //    SELECT InvoiceNum, LineItemNum, ItemCode, Cost FROM[LineItems] JOIN ItemDesc ON[LineItems].ItemCode = ItemDesc.ItemCode
}