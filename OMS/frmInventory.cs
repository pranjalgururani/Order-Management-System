using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMS
{
    public partial class frmInventory : Form
    {
        string[,] strInventoryArray =   {
                                                {"Flour", "200"},
                                                {"Sugar", "30"},
                                                {"Oil", "25"},
                                                {"Ham", "10"},
                                                {"Turkey", "10"},
                                                {"Scheese", "20"},
                                                {"Lettuce", "14"},
                                                {"Tomato", "14"},
                                                {"Bacon", "10"},
                                                {"Pickles", "20"},
                                                {"Mayo", "15"},
                                                {"Pepprni", "20"},
                                                {"Sauce", "60"},
                                                {"Gcheese", "25"},
                                                {"Salt", "10"},
                                                {"Pepper", "10"},
                                         };



        string[,] strIngredientArray = {
                                        {"Flour","1","1","1","3","3","3"},
                                        {"Yeast",".5",".5",".5","2","2","2"},
                                        {"Sugar",".03",".03",".03",".5",".5",".5"},
                                        {"Oil", ".05",".05","05",".1",".1",".1"},
                                        {"Ham",".1","0","0","0","0",".1"},
                                        {"Turkey","0",".1","0","0","0",".1"},
                                        {"Scheese", ".1",".1","0","0","0","0"},
                                        {"Lettuce",".25",".25",".3","0","0","0"},
                                        {"Tomato",".25",".25",".3","0","0",".3"},
                                        {"Bacon","0","0","0.1","0","0","0.1"},
                                        {"Pickles","0.02","0.02","0","0","0","0"},
                                        {"Mayo","0.02","0.02","0.02","0","0","0"},
                                        {"Mustard","0.02","0.02","0.02","0","0","0"},
                                        {"Pepprni","0","0","0","0","0.3","0.3"},
                                        {"Sauce","0","0","0","1","1","1"},
                                        {"Scheese","0","0","0","0.3","0.2","0.2"},
                                        {"Salt","0.01","0.01","0.01","0.02","0.02","0.02"},
                                        {"Pepper","0.01","0.01","0.01","0.02","0.02","0.02"},
                                       };

        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {

            loadInventoryListBox();

        }

        private void loadInventoryListBox()
        {
            lstInventory.Items.Clear();
            lstInventory.Items.Add("Item" + "\t" + "Quantity");
            for (int i =0; i < strInventoryArray.GetLength(0); i++)
            {
                lstInventory.Items.Add(strInventoryArray[i, 0] + "\t" + strInventoryArray[i, 1]);
            }
        }

        private void changeInventoryListBox()
        {
            int intTempQuantity = frmOrder.intQuantity;
            string strOrder =frmOrder.strSelectItem;
            switch (strOrder)
            {
                case "Ham & Swiss Sandwich":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 1]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 1]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 1] = Convert.ToString(decInventoryStatus);

                    }
                    break;
                case "Turkey & Provolone Sandwich":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 2]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 2]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 2] = Convert.ToString(decInventoryStatus);

                    }
                    break;
                case "BLT Sandwich":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 3]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 3]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 3] = Convert.ToString(decInventoryStatus);

                    }
                    break;
                case "Med. Cheese Pizza":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 4]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 4]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 4] = Convert.ToString(decInventoryStatus);

                    }
                    break;
                case "Med. Pepperoni Pizza":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 5]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 5]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 5] = Convert.ToString(decInventoryStatus);

                    }
                    break;
                case "Med. Supreme Pizza":
                    for (int i = 0; i < strInventoryArray.GetLength(0); i++)
                    {
                        decimal decInventoryStatus = Convert.ToDecimal(strInventoryArray[i, 6]);
                        decimal decIngredient = Convert.ToDecimal(strIngredientArray[i, 6]);

                        decInventoryStatus = decInventoryStatus - (intTempQuantity * decIngredient);

                        strInventoryArray[i, 6] = Convert.ToString(decInventoryStatus);

                    }
                    break;

            }

            loadInventoryListBox();
        }

    }
}
