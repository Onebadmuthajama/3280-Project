using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupAssignment.Items
{
    class clsItemsLogic
    {
        
        clsItemsSQL iSQL;
        static int code;
        public clsItemsLogic()
        {
            iSQL = new clsItemsSQL();
            //code = iSQL.getLastCode();
        }

        public DataSet getItems()
        {
            return iSQL.Getitems();
        }

        public void addItem(String itemDescription, decimal itemCost)
        {
            bumpCode();
            iSQL.addItem(code, itemDescription, itemCost);
        }

        public void deleteItem(int itemCode)
        {
            if(iSQL.inUse(itemCode) == false)
            {
                iSQL.deleteItem(itemCode);
            }
            else
            {
                MessageBox.Show("Item number " + itemCode + " is still in use on invoice " + iSQL.usedOnInvoice(itemCode));
            }
            
        }

        public void updateItem(int code, String itemDescription,decimal itemCost)
           
        {
            if(itemDescription != null && itemCost != 0)
            {
                iSQL.updateItemCost(code, itemCost);
                iSQL.updateItemDesc(code, itemDescription);
            }
            else if(itemDescription != null && itemCost == 0)
            {
                iSQL.updateItemDesc(code, itemDescription);
            }
            else if (itemCost != 0 && itemDescription == null)
            {
                iSQL.updateItemCost(code, itemCost);
            }
            else
            {
                MessageBox.Show("What did you want to upate?");
            }

        }
        public void bumpCode()
        {
            code ++;

        }

        





    }
}
