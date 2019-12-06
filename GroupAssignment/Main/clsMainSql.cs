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
    }
}