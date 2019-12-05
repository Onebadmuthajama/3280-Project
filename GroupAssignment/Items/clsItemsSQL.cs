using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    class clsItemsSQL
    {
        clsDataAccess dba;

        public clsItemsSQL()
        {
            dba = new clsDataAccess();
        }
        public DataSet Getitems()
        {
            DataSet result = dba.ExecuteSqlStatement("select * from ItemDesc");
            return result;
        }
        public List<string> updateItemDesc(String code)
        {
            //need to figure out how to modify item description from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> updateItemCost(String code)
        {
            //need to figure out how to modify item cost from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> deleteItem(String code)
        {
            //need to figure out how to delete item from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> addItem(String code, String Desc, String cost)
        {

            //need to figure out how to add item to index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public bool inUse(String code)
        {
            if (String.IsNullOrEmpty(usedOnInvoice(code)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public String usedOnInvoice(String code)
        {
            List<String> invoiceList = new List<String>();
            List<String> compareList = new List<String>();
            int i=0;

            invoiceList = dba.ExecuteSqlStatement("select ItemCode from LineItems").Tables[0].AsEnumerable().Select(x => x.Field<String>("ItemCode")).ToList();
  
            foreach(String s in invoiceList)
            {
                    if (s.Equals(code))
                    {
                        compareList.Add(s);
                    }
                    i++;
            }
             
            StringBuilder invoices = new StringBuilder();
            foreach (String s in compareList)
            {
                invoices.Append(s + " ");
            }
            return invoices.ToString(); 
        }
        public String getLastCode()
        {
            List<String> myList = new List<String>();

            myList = dba.ExecuteSqlStatement("select ItemCode from ItemDesc").Tables[0].AsEnumerable().Select(x => x.Field<String>("ItemCode")).ToList();

            String last = myList[myList.Count - 1];
            return last;

        }
    }
}


