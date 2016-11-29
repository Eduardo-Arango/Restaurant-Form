using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payment
{
    public partial class frmPayment : Form
	{
		public frmPayment()
		{
			InitializeComponent();
		}

		private void Payment_Load(object sender, EventArgs e)
		{
			lstCreditCardType.Items.Add("Pork chop");
			lstCreditCardType.Items.Add("Chicken");
			lstCreditCardType.Items.Add("Fish");
			lstCreditCardType.SelectedIndex = 0;

			string[] months = {"Select a Side...", 
				"Baked Potato", "Side Salad", "Assorted Vegetables", "French Fries"};

            foreach (string month in months)
			{
				cboExpirationMonth.Items.Add(month);
			}
			cboExpirationMonth.SelectedIndex = 0;

            string[] years = {"Select a Desert...",
               "Chocolate Cake", "Pumpkin Pie", "Ice Cream", "Cookie"};

            foreach (string year in years)
           // {
            //    cboExpirationMonth.Items.Add(month);
            // }
            // cboExpirationMonth.SelectedIndex = 0;

           //  int year = DateTime.Today.Year;
			// int endYear = year + 8;
			// cboExpirationYear.Items.Add("Select a Desert...");
			// while (year < endYear)
			{
				cboExpirationYear.Items.Add(year);
				// year++;
			}
			cboExpirationYear.SelectedIndex = 0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (IsValidData())
			{
				this.SaveData();
			}
		}

		private bool IsValidData()
		{
			if (rdoCreditCard.Checked)
			{
				if (lstCreditCardType.SelectedIndex == -1)
				{
					MessageBox.Show("You must select an item", "Entry Error");
					lstCreditCardType.Focus();
					return false;
				}
				if (txtCardNumber.Text == "")
				{
					MessageBox.Show("You must enter cooking instructions", "Entry Error");
					txtCardNumber.Focus();
					return false;
				}
				if (cboExpirationMonth.SelectedIndex == 0)
				{
					MessageBox.Show("You must select a side.", "Entry Error");
					cboExpirationMonth.Focus();
					return false;
				}
				if (cboExpirationYear.SelectedIndex == 0)
				{
					MessageBox.Show("You must select a desert", "Entry Error");
					cboExpirationYear.Focus();
					return false;
				}
			}

            if (rdoBillCustomer.Checked)
            {
                if (lstCreditCardType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select an item", "Entry Error");
                    lstCreditCardType.Focus();
                    return false;
                }
                if (txtCardNumber.Text == "")
                {
                    MessageBox.Show("You must enter cooking instructions", "Entry Error");
                    txtCardNumber.Focus();
                    return false;
                }
                if (cboExpirationMonth.SelectedIndex == 0)
                {
                    MessageBox.Show("You must select a side.", "Entry Error");
                    cboExpirationMonth.Focus();
                    return false;
                }
                if (cboExpirationYear.SelectedIndex == 0)
                {
                    MessageBox.Show("You must select a desert", "Entry Error");
                    cboExpirationYear.Focus();
                    return false;
                }
            }
            return true;
		}

       
        private void SaveData()
		{
			string msg = null;
			if (rdoCreditCard.Checked == true)
			{
				msg += "To go" + "\n";
				msg += "\n";
				msg += "Item: " + lstCreditCardType.Text + "\n";
				msg += "Cooking Instructions: " + txtCardNumber.Text + "\n";
                msg += "Side: "
                    + cboExpirationMonth.Text + "\n";
                   // + cboExpirationYear.Text + "\n";
                msg += "Desert: " + cboExpirationYear.Text + "\n";
               
                if (rdoBillCustomer.Checked == true)
			{
				msg += "Eat in" + "\n";
				msg += "\n";
				msg += "Item: " + lstCreditCardType.Text + "\n";
				msg += "Cooking Instructions: " + txtCardNumber.Text + "\n";
                msg += "Side: "
                    + cboExpirationMonth.Text + "\n";
                    // + cboExpirationYear.Text + "\n";
                msg += "Desert: " + cboExpirationYear.Text + "\n";
                }
			// else
			// {
			// 	msg += "Send bill to customer." + "\n";
			// 	msg += "\n";
			}

			bool isDefaultBilling = chkDefault.Checked;
			// msg += "Default billing: " + isDefaultBilling;
            msg += "Eat in" + "\n";
            msg += "\n";
            msg += "Item: " + lstCreditCardType.Text + "\n";
            msg += "Cooking Instructions: " + txtCardNumber.Text + "\n";
            msg += "Side: "
                + cboExpirationMonth.Text + "\n";
            // + cboExpirationYear.Text + "\n";
            msg += "Desert: " + cboExpirationYear.Text + "\n";

             this.Tag = msg;
			 this.DialogResult = DialogResult.OK;
		}

		private void Billing_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdoCreditCard.Checked)
				EnableControls();
		//	else
				// DisableControls();
		}

		private void EnableControls()
		{
			lstCreditCardType.Enabled = true;
			txtCardNumber.Enabled = true;
			cboExpirationMonth.Enabled = true;
			cboExpirationYear.Enabled = true;
		}

		private void DisableControls()
		{
			lstCreditCardType.Enabled = false;
			txtCardNumber.Enabled = false;
			cboExpirationMonth.Enabled = false;
			cboExpirationYear.Enabled = false;
		}

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}