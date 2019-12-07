using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GroupAssignment.Models;

namespace GroupAssignment.Items {
    /// <summary>
    /// sql class that talks to DB and returns values based on need.
    /// </summary>
    internal class clsItemsSQL {
        /// <summary>
        /// connects to clsDataAccess
        /// </summary>
        private readonly clsDataAccess _dba;
        /// <summary>
        /// initiates the new clsDattaAccess
        /// </summary>
        public clsItemsSQL() {
            _dba = new clsDataAccess();
        }
        /// <summary>
        /// gets items from sql for table
        /// </summary>
        /// <returns></returns>

        public List<ItemDescription> GetItems() {
            const string sql = "SELECT * FROM ItemDesc";

            var result = new List<ItemDescription>();
            var ds = _dba.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

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
        /// adds item to db
        /// </summary>
        /// <param name="item"></param>

        public void AddItem(ItemDescription item) {
            _dba.ExecuteSqlStatement($"INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES({item.ItemCode}, '{item.ItemDesc}', {item.ItemCost})");
        }
        /// <summary>
        /// this deletes an item from the db
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DeleteItem(int code) {
            var sql = $"Delete from ItemDesc where ItemCode = {code}";
            var result = _dba.ExecuteNonQuery(sql);

            return result;
        }
        /// <summary>
        /// this updates the item
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(ItemDescription item) {
            DeleteItem(item.ItemCode);
            AddItem(item);
        }
        /// <summary>
        /// determines what parts of the item objects are being searched for
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool InUse(int code) {
            if (string.IsNullOrEmpty(UsedOnInvoice(code))) {
                return false;
            }

            return true;
        }
        /// <summary>
        /// this determines if the item is in use or not if so will give an error and give invoice number
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string UsedOnInvoice(int code) {
            var compareList = new List<int>();

            var invoiceList = _dba.ExecuteSqlStatement("select ItemCode from LineItems").Tables[0].AsEnumerable().Select(x => x.Field<int>("ItemCode")).ToList();
  
            foreach(var s in invoiceList) {
                if (s.Equals(code)) {
                    compareList.Add(s);
                }
            }
             
            var invoices = new StringBuilder();

            foreach (var k in compareList) {
                invoices.Append(k + " ");
            }

            return invoices.ToString();
        }
        /// <summary>
        /// gets the largest number in the DB so we know what number the next item code will be
        /// </summary>
        /// <returns></returns>

        public int GetLastCode() {
            const string sql = "select ItemCode from ItemDesc order by ItemCode desc";

            var result = _dba.ExecuteSqlStatement(sql).Tables[0].AsEnumerable().Select(x => x.Field<int>("ItemCode")).FirstOrDefault();
            return result;
        }
    }
}


