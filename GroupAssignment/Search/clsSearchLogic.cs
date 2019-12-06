using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAssignment.Models;

namespace GroupAssignment.Search
{
    class clsSearchLogic
    {
        clsSearchSQL sSQL;

        public clsSearchLogic()
        {
            sSQL = new clsSearchSQL();
        }

        /// <summary>
        ///     Returns all items from Invoices
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetAllItems()
        {
            return sSQL.GetAllItems();
        }
    }
}
