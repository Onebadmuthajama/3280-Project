using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GroupAssignment.Models;

namespace GroupAssignment.Search
{
    class clsSearchSQL
    {
        private readonly clsDataAccess _dataAccess;

        public clsSearchSQL()
        {
            _dataAccess = new clsDataAccess();
        }

        /// <summary>
        ///     Returns a data set containing all invoices from the database
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetAllItems()
        {
            var sql = $"SELECT Invoices.InvoiceNum, Invoices.InvoiceDate, Invoices.TotalCost FROM Invoices;";

            var result = new List<Invoice>();
            var ds = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds)
            {
                var inv = new Invoice
                {
                    InvoiceNumber = row.Field<int>("InvoiceNum"),
                    InvoiceDate = row.Field<DateTime>("InvoiceDate"),
                    TotalCost = row.Field<int>("TotalCost")
                };

                result.Add(inv);
            }

            return result;
        }
    }
}
