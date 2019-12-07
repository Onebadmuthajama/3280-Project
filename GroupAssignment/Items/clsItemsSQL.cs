using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAssignment.Models;

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
        public List<string> updateItemDesc(int code,string newDesc)
        {
            //need to figure out how to modify item descriptiontest from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> updateItemCost(int code, decimal newCost)
        {
            //need to figure out how to modify item cost from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> deleteItem(int code)
        {
            //need to figure out how to delete item from index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public List<string> addItem(int code, String Desc, decimal cost)
        {

            //need to figure out how to add item to index
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(code)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
        public bool inUse(int code)
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
        public String usedOnInvoice(int code)
        {
            List<int> invoiceList = new List<int>();
            List<int> compareList = new List<int>();
            int i=0;

            invoiceList = dba.ExecuteSqlStatement("select ItemCode from LineItems").Tables[0].AsEnumerable().Select(x => x.Field<int>("ItemCode")).ToList();
  
            foreach(int s in invoiceList)
            {
                    if (s.Equals(code))
                    {
                        compareList.Add(s);
                    }
                    i++;
            }
             
            StringBuilder invoices = new StringBuilder();
            foreach (int k in compareList)
            {
                invoices.Append(k + " ");
            }
            return invoices.ToString(); 
        }
        public int getLastCode()
        {
            List<int> myList = new List<int>();

            myList = dba.ExecuteSqlStatement("select ItemCode from ItemDesc").Tables[0].AsEnumerable().Select(x => x.Field<int>("ItemCode")).ToList();

            int last = myList[myList.Count - 1];
            return last;

        }

        public List<ItemDescription> GetAllItemsForItems() {
            const string sql = "SELECT * FROM ItemDesc";

            var result = new List<ItemDescription>();
            var ds = dba.ExecuteSqlStatement(sql).Tables[0].AsEnumerable();

            foreach (var row in ds) {
                var itemDescription = new ItemDescription {
                    ItemCode = row.Field<int>("ItemCode"),
                    ItemDesc = row.Field<string>("ItemDesc"),
                    ItemCost=  row.Field<decimal>("Cost")
                };

                result.Add(itemDescription);
            }

            return result;
        }
    }
}


