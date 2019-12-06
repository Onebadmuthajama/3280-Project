using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Text;
using GroupAssignment.Models;



//TODO: Figure out SQL DateTime format.
//Use it to fix filtered Get()s



namespace GroupAssignment.Search
{
    class clsSearchSQL
    {
        /// <summary>
        /// Used to access database
        /// </summary>
        private readonly clsDataAccess _dataAccess;

        /// <summary>
        /// Constructor generates data access class for use
        /// </summary>
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

        /// <summary>
        ///     Returns filtered invoices by number, date, cost
        /// </summary>
        /// <param name="n">invoice number</param>
        /// <param name="d">invoice date</param>
        /// <param name="c">invoice charge</param>
        /// <returns></returns>
        public List<Invoice> Get(int? n, DateTime? d, int? c)
        {

            var sql = $"SELECT Invoices.InvoiceNum, Invoices.InvoiceDate, Invoices.TotalCost FROM Invoices WHERE";

            //add AND to query
            bool and = false;

            //is num defined
            if (n != null)
            {
                sql += $" Invoices.InvoiceNum = {n}";
                and = true;
            }
            //is date defined
            if (d != null) {
                DateTime dat = (DateTime)d;
                if (and)
                {
                    sql += $" AND";
                }
                sql += $" Invoices.InvoiceDate = {dat.ToString("d")}";
                and = true;
            }
            //is cost defined
            if (c != null)
            {
                if (and)
                {
                    sql += $" AND";
                }
                sql += $" Invoices.TotalCost = {c}";
            }

            //closing semicolon
            sql += ";";

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


        /// <summary>
        ///     Returns all items in the specified column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <returns></returns>
        public List<T> Get<T>(String col)
        {
            var sql = $"SELECT Invoices."+col+" FROM Invoices;";

            var result = new List<T>();
            var ds = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds)
            {
                result.Add(row.Field<T>(col));
            }

            return result;
        }

        /// <summary>
        ///     Returns all items in the specified column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <returns></returns>
        public List<T> Get<T>(String col, int? n, DateTime? d, int? c)
        {
            var sql = $"SELECT Invoices." + col + " FROM Invoices WHERE";

            //add AND to query
            bool and = false;

            //is num defined
            if (n != null)
            {
                sql += $" Invoices.InvoiceNum = {n}";
                and = true;
            }
            //is date defined
            if (d != null)
            {
                DateTime dat = (DateTime)d;
                if (and)
                {
                    sql += $" AND";
                }
                sql += $" Invoices.InvoiceDate = {dat.ToString("d")}";
                and = true;
            }
            //is cost defined
            if (c != null)
            {
                if (and)
                {
                    sql += $" AND";
                }
                sql += $" Invoices.TotalCost = {c}";
            }

            //closing semicolon
            sql += ";";


            var result = new List<T>();
            var ds = _dataAccess.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds)
            {
                result.Add(row.Field<T>(col));
            }

            return result;
        }


    }
}
