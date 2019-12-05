using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    class clsItemsLogic
    {
        private int cost;
        private int itemCode;
        private int invoiceNumber;
        private String description;
        clsItemsSQL iSQL;
        List<String> itemDescription;

        public clsItemsLogic()
        {
            iSQL = new clsItemsSQL();
            itemDescription = new List<String>();
        }
        public List<String> getItems()
        {
            itemDescription = iSQL.Getitems("30.00");
            return itemDescription;
        }
        public void addItem()
        {

        }
        public void deleteItem()
        {

        }
        public void updateItem(int itemID)
        {



        }



    }
}
