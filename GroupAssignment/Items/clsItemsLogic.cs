using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    class clsItemsLogic
    {
        private String cost;
        private String Code;
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
        public void addItem(String itemCode, String itemDescription, String itemCost)
        {

        }
        public void deleteItem(String itemCode)
        {

        }
        public void updateItem(String itemCode, String itemDescription,String itemCost)
        {


        }
        




    }
}
