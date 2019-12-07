using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GroupAssignment.Models;

namespace GroupAssignment.Items {
    internal class clsItemsSQL {
        private readonly clsDataAccess _dba;

        public clsItemsSQL() {
            _dba = new clsDataAccess();
        }

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

        public void AddItem(ItemDescription item) {
            _dba.ExecuteSqlStatement($"INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES({item.ItemCode}, '{item.ItemDesc}', {item.ItemCost})");
        }

        public int DeleteItem(int code) {
            var sql = $"Delete from ItemDesc where ItemCode = {code}";
            var result = _dba.ExecuteNonQuery(sql);

            return result;
        }

        public void UpdateItem(ItemDescription item) {
            DeleteItem(item.ItemCode);
            AddItem(item);
        }

        public bool InUse(int code) {
            if (string.IsNullOrEmpty(UsedOnInvoice(code))) {
                return false;
            }

            return true;
        }

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

        public int GetLastCode() {
            const string sql = "select ItemCode from ItemDesc order by ItemCode desc";

            var result = _dba.ExecuteSqlStatement(sql).Tables[0].AsEnumerable().Select(x => x.Field<int>("ItemCode")).FirstOrDefault();
            return result;
        }
    }
}


