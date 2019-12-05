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
        public List<string> Getitems(String cost)
        {
            var result = dba.ExecuteSqlStatement("select ItemDesc from ItemDesc").Tables[0].AsEnumerable()
                 .Where(x => x.Field<String>("Cost").Equals(cost)).Select(y => y.Field<String>("ItemDesc"))
                 .ToList();

            return result;
        }
    }
}
