//AUTHORS:      (Group 1) Tanner Cilento & Pranjal Gururani
//COURSE:       ISYS 601 Section 201
//FORM:         frmOrder.cs 
//PURPOSE:      To create a form that will take a customer's personal information, 
//              and details about the delivery location. Furthermore, the form will include
//              item selections for the deli clerk to select. The total cost will also 
//              be calculated once the order is completed and processed.
//INPUT:        The customer's name, street address, city, state, zip code, phone number 
//              and subdivision location is all entered. If delivery is required the information
//              previously listed must also be placed in the corresponding delivery textboxes. 
//              The item must be selected, along with the bread/crust type. Once the item information
//              is selected then the quantity must be chosen.
//PROCESS:      A user enters a customer's information into the Customer Details groupbox, then will
//              make the decision if they want to select delivery or not. If delivery is required the user
//              will click the chkDelivery checkbox. Then the user information will be transferred into the 
//              the Delivery Details groupbox. The user will then select cboSelectItem combo box, what item
//              is required. Then from the cboSelectOption combo box they will select the bread/crust 
//              type requested. Finally the user may choose the quantity needed. This process may be repeated
//              until the desired items are all added and listed in the lstDisplay listbox. The user
//              can then press the btnOrder button to process the order and the order total is then displayed
//              in the txtOrderTotal textbox.
//OUTPUT:       The bread/crust type, item ordered, quantity, price and subtotal are outputted in 
//              the lstDisplay listbox. When the complete order is processed then the order total
//              is displayed in the txtOrderTotal textbox.
//HONOR CODE:   “On my honor, as an Aggie, I have neither given
//              nor received unauthorized aid on this academic

///<summary>
///The program is designed to order pizzas or sandwiches.
///User selects pizzas and/or sandwiches and enters the 
///quantity. This step can be performed many number of times.
///The program dispays the total amount of the order.
///</summary>

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
    public partial class frmOrder : Form
    {
        // Set the class variables.
        private string[] strPizza = new string[] {"Select an Item...", "Original", "Pan", "Thin", "Wheat" };
        private string[] strSandwich = new string[] { "Select an Item...", "White", "Pumpernickel", "Rye", "Sourdough", "Multigrain" };
        public static string strSelectItem;
        decimal decItemCost = 0;
        decimal decTotalItemCost = 0;
        decimal decSubtotal = 0;
        public static int intQuantity;



        public frmOrder()
        {
            InitializeComponent();


            StartPosition = FormStartPosition.CenterScreen; //Have form open in the center of the screen.
            cboSelectItem.SelectedIndex = 0;
            cboSelectOption.SelectedItem = "";
            txtCustomerCity.Focus();
        }

        /// <summary>
        /// Has what will happen whenever an item is chosen from the cboSelectItem combo box.
        /// Including what the item price will be, what picture will be displayed and what options
        /// will be included in the cboSelectOption combo box. 
        /// </summary>
        private void cboSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try // The try and catch block is used to handle exception 

            {
                strSelectItem = Convert.ToString(cboSelectItem.Text); // Convert input in text box to a string


                switch (strSelectItem) // Selects action to be performed as per user's selection
                {
                    // Selects actions for sandwich order
                    case "Ham & Swiss Sandwich":
                    case "Turkey & Provolone Sandwich":
                    case "BLT Sandwich":
                        cboSelectOption.Items.Clear();  // Clear combo box
                        txtQuantity.Clear(); // Clear quantity
                        cboSelectOption.ResetText(); // Reset combo box
                        cboSelectOption.Items.AddRange(strSandwich); // Add sandwiches names to combo box
                        cboSelectOption.SelectedIndex = 0;//Sets the item for combobox
                        decItemCost = 5.00m; // Set the price
                        picItemType.Image = Properties.Resources.Sandwich; // Set the Image for a sandwich
                        break;
                    // Selects actions for pizza order
                    case "Med. Cheese Pizza":
                    case "Med. Pepperoni Pizza":
                    case "Med. Supreme Pizza":
                        cboSelectOption.Items.Clear(); // Clear combo box
                        txtQuantity.Clear(); // Clear quantity
                        cboSelectOption.ResetText(); // Reset combo box
                        cboSelectOption.Items.AddRange(strPizza); // Add sandwiches names to combo box
                        cboSelectOption.SelectedIndex = 0; //Sets the item for combobox
                        decItemCost = 9.50m; // Set the price
                        picItemType.Image = Properties.Resources.pizza;  // Set the Image for a sandwich
                        break;

                }
            }
            catch (Exception ex)  //Displays message when an exception occurs 
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType() + "\n\n" + ex.StackTrace);
            }

        }
        
        /// <summary>
        /// Add an item to the lstDisplay list box if the data entered into
        /// the form is valid. 
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try // The try and catch block is used to handle exception 
            {
                if (IsValidData()) // Checks if all input values are valid entries
                {
                   
                   
                    
                    string strSelectOption = Convert.ToString(cboSelectOption.Text);
                    intQuantity = Convert.ToInt32(txtQuantity.Text);

                    // Make sure that the quantity entered is above 0.
                    if (intQuantity > 0)
                    {
                        decTotalItemCost = decItemCost * (decimal)intQuantity;
                        decSubtotal += decTotalItemCost;
                        string strTemp = strSelectOption + " " + strSelectItem + ", " + intQuantity + "@" + decItemCost.ToString("f2") + ", total " + decTotalItemCost.ToString("c2");
                        lstDisplay.Items.Add(strTemp); // Add items to the list box

                        cboSelectItem.SelectedIndex = 0;
                        cboSelectOption.SelectedIndex = -1;
                        txtQuantity.Text = "";
                        picItemType.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid quantity", "Entry Error");
                    }
                }


            }
            catch (Exception ex) //Displays message when an exception occurs 
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType() + "\n\n" + ex.StackTrace);
            }
        }


        /// <summary>
        /// Clears all the data fields on the form.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {

            txtCustomerCity.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtCustomerState.Clear();
            txtCustomerStreet.Clear();
            txtCustomerSubdivision.Clear();
            txtCustomerZip.Clear();
            txtDeliveryCity.Clear();
            txtDeliveryName.Clear();
            txtDeliveryPhone.Clear();
            txtDeliveryState.Clear();
            txtDeliveryStreet.Clear();
            txtDeliverySubdivision.Clear();
            txtDeliveryZip.Clear();
            txtQuantity.Clear();
            txtOrderTotal.Clear();
            lstDisplay.Items.Clear();

            cboSelectItem.SelectedIndex = 0;
            cboSelectOption.SelectedIndex = -1;

            picItemType.Image = null;
            chkDelivery.Checked = false;


        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Data validation to make sure none of the customer detail textboxes are
        /// left empty.
        /// </summary>
        ///  /// <param name="textBox"></param>
        /// <param name="name"></param>
        /// <returns> Boolean value specifying if required values are present</returns>
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Data validation to make sure valid inputs are present in combo box
        /// </summary>
        ///  /// <param name="textBox"></param>
        /// <param name="name"></param>
        /// <returns> Boolean value specifying if required values are present</returns>
        public bool IsComboBoxPresent(ComboBox combobox, string name)
        {
            if (!(combobox.Text == "Original" || combobox.Text == "Pan"|| combobox.Text == "Thin"|| combobox.Text == "Wheat" || combobox.Text == "White" || combobox.Text == "Pumpernickel" || combobox.Text == "Rye" || combobox.Text == "Sourdough" || combobox.Text == "Multigrain" || combobox.Text ==  "Ham & Swiss Sandwich" || combobox.Text == "Turkey & Provolone Sandwich" || combobox.Text == "BLT Sandwich" || combobox.Text == "Med. Cheese Pizza" || combobox.Text == "Med. Pepperoni Pizza" || combobox.Text == "Med. Supreme Pizza"))
            {
                MessageBox.Show(name + " It is a required field.", "Entry Error");
                combobox.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Data validation to make sure none of the delivery textboxes are
        /// left empty.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="name"></param>
        /// <returns> Boolean value specifying if values are present specifically in Delivery Details</returns>
        public bool IsDeliveryPresent(TextBox textBox, string name)
        {
            if (chkDelivery.Checked)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show(name + " is a required field.", "Entry Error");
                    textBox.Focus();
                    return false;
                }
                return true;
            }
            else
                return true;

        }

        /// <summary>
        /// Calls the methods IsPresent, IsDeliveryPresent, IsWithinRange, 
        /// and IsInteger. Validates that the data entered into the form
        /// will pass all these conditions.
        /// </summary>
        /// <returns> Boolean value specifying if all valid inputs have been entered by user</returns>
        public bool IsValidData()
        {
            return


                // Validate the Customer Details
                IsPresent(txtCustomerName, "CustomerName") &&
                IsPresent(txtCustomerStreet, "CustomerStreet") &&
                IsPresent(txtCustomerCity, "Customer City") &&
                IsPresent(txtCustomerState, "CustomerState") &&
                IsPresent(txtCustomerZip, "CustomerZip") &&
                IsPresent(txtCustomerPhone, "CustomerPhone") &&
                IsPresent(txtCustomerSubdivision, "CustomerSubdivision") &&

                // Validate the Delivery Details
                IsDeliveryPresent(txtDeliveryName, "DeliveryName") &&
                IsDeliveryPresent(txtDeliveryStreet, "DeliveryStreet") &&
                IsDeliveryPresent(txtDeliveryCity, "DeliveryCity") &&
                IsDeliveryPresent(txtDeliveryState, "DeliveryState") &&
                IsDeliveryPresent(txtDeliveryZip, "DeliveryZip") &&
                IsDeliveryPresent(txtDeliveryPhone, "DeliveryPhone") &&
                IsDeliveryPresent(txtDeliverySubdivision, "DeliverySubdivision") &&

                // Validate the comboboxes
                IsComboBoxPresent(cboSelectItem, "Select an item. ") &&
                IsComboBoxPresent(cboSelectOption, "Select an option. ")&&

                // Validate the quantity
                IsPresent(txtQuantity, "Quantity") &&
                IsInteger(txtQuantity, "Quantity") &&


                // Validate the range
                IsWithinRange(txtDeliveryCity, "Location");
        }

        /// <summary>
        /// Validates that the delivery city is either College Station
        /// or Bryan.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="name"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns> Boolean value specifying if input location is Bryan or College Station</returns>
        public bool IsWithinRange(TextBox textBox, string name)
        {
            if (chkDelivery.Checked) // check if delivery check box is checked by user
            {
                string location = Convert.ToString(textBox.Text).ToLower(); // converts location entered to a string
                if (location == "bryan" || location == "college station") // checks if the location entered is either bryan or college station
                {
                    return true;
                }
                else // displays message that delivery is possible only in Bryan or College Station
                {
                    MessageBox.Show("The delivery is only available in Bryan or College Station" + "\n" + "Please enter one of these cities in Delivery Details" + "\n" + "If required(optional), kindly change details in Customer Details too." + "\n" + "Thank you!", "Entry Error");
                    txtDeliveryCity.Clear(); // Clears delivery city
                    txtDeliveryCity.Focus(); // Focusses on location text box
                    return false;
                }
            }
            else
                return true; // this is used in case delivery check box is not checked
        }

        /// <summary>
        /// Validates that the entry into the txtQuantity textbox 
        /// is a valid integer.
        /// </summary>
        ///  /// <param name="textBox"></param>
        /// <param name="name"></param>
        /// <returns> Boolean value specifying if quantity is integer</returns>
        public bool IsInteger(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a integer value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// If the chkDelivery checkbox is checked then the data entered 
        /// for customer details is sent to the corresponding delivery details
        /// textboxes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDelivery_CheckedChanged(object sender, EventArgs e)
        {
            try // The try and catch block is used to handle exception
            {

                bool blnIsChecked = chkDelivery.Checked; // Checks if check box  chkDelivery is checked
                if (!blnIsChecked) // If the check box is not checked disable delivery details and disable tab stops
                {
                    //Disables Delivery details text boxes
                    txtDeliveryName.Enabled = false;
                    txtDeliveryCity.Enabled = false;
                    txtDeliveryPhone.Enabled = false;
                    txtDeliveryState.Enabled = false;
                    txtDeliverySubdivision.Enabled = false;
                    txtDeliveryStreet.Enabled = false;
                    txtDeliveryZip.Enabled = false;

                    //Disable Tab Stop for text boxes
                    txtDeliveryName.TabStop = false;
                    txtDeliveryCity.TabStop = false;
                    txtDeliveryPhone.TabStop = false;
                    txtDeliveryState.TabStop = false;
                    txtDeliverySubdivision.TabStop = false;
                    txtDeliveryStreet.TabStop = false;
                    txtDeliveryZip.TabStop = false;

                    //Clears the text boxes
                    txtDeliveryCity.Clear();
                    txtDeliveryName.Clear();
                    txtDeliveryPhone.Clear();
                    txtDeliveryState.Clear();
                    txtDeliveryStreet.Clear();
                    txtDeliverySubdivision.Clear();
                    txtDeliveryZip.Clear();
                }

                if (blnIsChecked) // If the check box is checked, enable delivery details and copy text from customer details to delivery details
                {


                    if (IsWithinRange(txtCustomerCity, "City"))
                    //Copies text from Customer Details to Delivery Details
                    {
                        //Enables Delivery details text boxes
                        txtDeliveryName.Enabled = true;
                        txtDeliveryCity.Enabled = true;
                        txtDeliveryPhone.Enabled = true;
                        txtDeliveryState.Enabled = true;
                        txtDeliverySubdivision.Enabled = true;
                        txtDeliveryStreet.Enabled = true;
                        txtDeliveryZip.Enabled = true;

                        //Highlight the text boxes starting from street address
                        txtDeliveryName.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliveryCity.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliveryPhone.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliveryState.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliverySubdivision.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliveryStreet.BackColor = System.Drawing.Color.LightYellow;
                        txtDeliveryZip.BackColor = System.Drawing.Color.LightYellow;

                        //Copies corresponds details from Customer text boxes
                        txtDeliveryName.Text = txtCustomerName.Text;
                        txtDeliveryCity.Text = txtCustomerCity.Text;
                        txtDeliveryPhone.Text = txtCustomerPhone.Text;
                        txtDeliveryState.Text = txtCustomerState.Text;
                        txtDeliverySubdivision.Text = txtCustomerSubdivision.Text;
                        txtDeliveryStreet.Text = txtCustomerStreet.Text;
                        txtDeliveryZip.Text = txtCustomerZip.Text;
                    }

                    else
                    {
                        //Enables Delivery details text boxes
                        txtDeliveryName.Enabled = true;
                        txtDeliveryCity.Enabled = true;
                        txtDeliveryPhone.Enabled = true;
                        txtDeliveryState.Enabled = true;
                        txtDeliverySubdivision.Enabled = true;
                        txtDeliveryStreet.Enabled = true;
                        txtDeliveryZip.Enabled = true;

                        //Enables Tab Stop for text boxes
                        txtDeliveryName.TabStop = true;
                        txtDeliveryCity.TabStop = true;
                        txtDeliveryPhone.TabStop = true;
                        txtDeliveryState.TabStop = true;
                        txtDeliverySubdivision.TabStop = true;
                        txtDeliveryStreet.TabStop = true;
                        txtDeliveryZip.TabStop = true;

                        //Copies only details Customer text boxes
                        txtDeliveryName.Text = txtCustomerName.Text;
                        txtDeliveryStreet.Focus();

                    }
                }
            }
            catch (Exception ex)  //Displays message when an exception occurs 
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType() + "\n\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Finalizes the order, calculates the order total and displays it in 
        /// the txtOrderTotal textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            decimal decTaxOnOrder = 0.0m;// Declares and initializes variable to hold tax
            decTaxOnOrder = .0825m * decSubtotal; // Calculate tax on order

            decimal decTotalCost = Math.Round((decTaxOnOrder + decSubtotal), 2); // Calculates total cost

            txtOrderTotal.Text = decTotalCost.ToString("c2"); // Displays the total cost
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form inventoryForm = new frmInventory();
            inventoryForm.ShowDialog();
        }
    }
}




