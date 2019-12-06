using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GroupAssignment.Search
{
    class clsSearchSQL
    {
        clsDataAccess db;

        public clsSearchSQL() {
            db = new clsDataAccess();
        }

        /// <summary>
        /// Returns all items from Invoices
        /// </summary>
        /// <returns></returns>
        public DataSet GetItems()
        {
            return db.ExecuteSqlStatement("select * from Invoices");
        }
    }
}
