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
        static String code;
        public clsItemsLogic()
        {
            iSQL = new clsItemsSQL();
            code = iSQL.getLastCode();
        }

        public DataSet getItems()
        {
            return iSQL.Getitems();
        }

        public void addItem(String itemDescription, String itemCost)
        {
            bumpCode();
            iSQL.addItem(code, itemDescription, itemCost);
        }

        public void deleteItem(String itemCode)
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

        public void updateItem(String code, String itemDescription,String itemCost)
           
        {
            if(itemDescription != null && itemCost != null)
            {
                iSQL.updateItemCost(itemCost);
                iSQL.updateItemDesc(itemDescription);
            }
            else if(itemDescription != null && itemCost == null)
            {
                iSQL.updateItemDesc(itemDescription);
            }
            else if (itemCost != null && itemDescription == null)
            {
                iSQL.updateItemCost(itemCost);
            }
            else
            {
                MessageBox.Show("What did you want to upate?");
            }

        }
        public void bumpCode()
        {
            int x = Int32.Parse(code);
            x++;
            code = x.ToString();

        }

        





    }
}
