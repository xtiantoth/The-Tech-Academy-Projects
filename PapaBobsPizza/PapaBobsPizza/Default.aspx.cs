using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsPizza.DTO;
using PapaBobsPizza.Domain;

namespace PapaBobsPizza
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        protected void CrustDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        protected void SausageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        protected void PepperoniCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        protected void OnionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        protected void GreenPeppersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recalculateTotalCost();
        }

        private void recalculateTotalCost()
        {
            if (SizeDropDownList.SelectedValue != "" && CrustDropDownList.SelectedValue != "")
            DisplayTotalCost();
            
            else resultLabel.Text = "";
        }

        public decimal calculateTotalCost()
        {   var order = buildOrder();
            return order.TotalCost;
        }
        public void DisplayTotalCost()
        {   
            resultLabel.Text = String.Format("{0:C}", calculateTotalCost());
        }
        
        //Validation before submitting data to database

        private bool validateData()
        {
            if (validateCrust()
                && validateSize()
                && validateName()
                && validateAddress()
                && validateZip()
                && validatePhone())
            {
                return true;
            }
            else return false;
        }

        private bool validateCrust()
        {
            if (CrustDropDownList.SelectedValue == String.Empty)
            {
                WarningLabel.Text = "Error: Please select a crust.";
                WarningLabel.Visible = true;
                return false;
            }
            else return true;
        }

        private bool validateSize()
        {
            if (SizeDropDownList.SelectedValue == String.Empty)
            {
                WarningLabel.Text = "Error: Please select a size.";
                WarningLabel.Visible = true;
                return false;
            }
            else return true;
        }

        private bool validateName()
        {
            if (NameTextBox.Text.Trim().Length == 0)
            {
                WarningLabel.Text = "Error: Please enter a Name.";
                WarningLabel.Visible = true;
                return false;
            }
            else return true;
        }
        private bool validateAddress()
        {
            if (AddressTextBox.Text.Trim().Length == 0)
            {
                WarningLabel.Text = "Error: Please enter an Address.";
                WarningLabel.Visible = true;
                return false;
            }
            else return true;

        }
        private bool validateZip()
        {
            if (ZipTextBox.Text.Trim().Length == 0)
            {
                WarningLabel.Text = "Error: Please enter a Zip.";
                WarningLabel.Visible = true;
                return false;
            }
            return true;
        }
        private bool validatePhone()
        {
            string Warning = "";
            if (!validPhone(PhoneTextBox.Text.Trim(), out Warning))
            {
                WarningLabel.Text = Warning;
                WarningLabel.Visible = true;
                return false;
            }

            else if (PhoneTextBox.Text.Trim().Length == 0)
            {
                WarningLabel.Text = "Error: Please enter a Phone number.";
                WarningLabel.Visible = true;
                return false;
            }
            return true;
        }

        private bool validPhone(string PhoneNumber, out string Warning)
        {
            Warning = "";
            char[] PhoneArray = PhoneNumber.ToCharArray();
            try
            {
                if (PhoneArray.Length == 8);
                else {
                    Warning = "Error: The length of the phone number is incorrect.";
                        return false;
                     };
            }
            catch (Exception e)
            {
                if (e.Message == "Input string was not in a correct format.")
                {
                    Warning = "Error: The phone number should only contain numbers";
                }
                else Warning = e.Message;

                return false;
            }
            
            return true;
        }

        private DTOOrder buildOrder()
        {
            DTOOrder Order = new DTOOrder();
            Order.Id = Guid.NewGuid();
            Order.Address = AddressTextBox.Text;
            Order.Crust = (DTO.Enums.CrustType)Enum.Parse(typeof(DTO.Enums.CrustType), CrustDropDownList.SelectedValue);
            Order.GreenPeppers = (GreenPeppersCheckBox.Checked) ? true : false;
            Order.Name = NameTextBox.Text;
            Order.Onions = (OnionsCheckBox.Checked) ? true : false;
            Order.PaymentType = (CreditRadioButton.Checked) ? DTO.Enums.PaymentType.Credit : DTO.Enums.PaymentType.Cash;
            Order.Pepperoni = (PepperoniCheckBox.Checked) ? true : false;
            Order.Phone = PhoneTextBox.Text;
            Order.Sausage = (SausageCheckBox.Checked) ? true : false;
            Order.Size = (DTO.Enums.SizeType)Enum.Parse(typeof(DTO.Enums.SizeType), SizeDropDownList.SelectedValue);
            Order.Zip = ZipTextBox.Text;
            Order.TotalCost = PizzaPricesManager.calculateTotalCost(Order);
            return Order;
        }
        
        protected void OrderButton_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                try
                {
                    var newOrder = buildOrder();
                    OrdersManager.SaveOrder(newOrder);
                    Response.Redirect("OrderSuccess.html");
                }
                catch (Exception ex)
                {
                    WarningLabel.Text = ex.Message;
                    WarningLabel.Visible = true;
                }
            }
        }
    }
}