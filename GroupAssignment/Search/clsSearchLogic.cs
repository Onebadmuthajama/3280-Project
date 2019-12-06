using System;
using System.Collections.Generic;
/*using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using GroupAssignment.Models;

namespace GroupAssignment.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// Used by all functions
        /// </summary>
        clsSearchSQL _SearchSQL;

        /// <summary>
        ///     Constructor generates SQL object for use
        /// </summary>
        public clsSearchLogic()
        {
            _SearchSQL = new clsSearchSQL();
        }

        /// <summary>
        ///     Returns all items from Invoices
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetAllItems()
        {
            return _SearchSQL.GetAllItems();
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
            //if no parameters, return all
            if(n == null && d == null && c == null)
            {
                return _SearchSQL.GetAllItems();
            }

            //else filter
            return _SearchSQL.Get(n, d, c);
        }


        /// <summary>
        ///     Returns all items in the specified column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <returns></returns>
        public List<T> Get<T>(String col)
        {
            return _SearchSQL.Get<T>(col);
        }

        /// <summary>
        ///     Returns all items in the specified column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <returns></returns>
        public List<T> Get<T>(String col, int? n, DateTime? d, int? c)
        {
            //if no parameters, return all
            if (n == null && d == null && c == null)
            {
                return _SearchSQL.Get<T>(col);
            }

            //else filter
            return _SearchSQL.Get<T>(col, n, d, c);
            
        }

    }
}
