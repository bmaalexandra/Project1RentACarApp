using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarAppProject1
{
    public partial class RegisterNewCarRentScreen : Form
    {
        public RegisterNewCarRentScreen()
        {
            InitializeComponent();
        }

        //this function return true if the End Date is equal or bigger than the Start Date
        public bool endDateIsEqualOrBiggerThanStartDate(string endDate, string startDate) {
            DateTime endDate1 = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime startDate1 = DateTime.ParseExact(startDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (endDate1.CompareTo(startDate1) == 1 || endDate1.CompareTo(startDate1) == 0)
            {
                return true;
            }
            else { return false; }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxClientID.Text) && !string.IsNullOrEmpty(textBoxCarPlate.Text) && !string.IsNullOrEmpty(textBoxStartDate.Text) && !string.IsNullOrEmpty(textBoxEndDate.Text) && !string.IsNullOrEmpty(textBoxCity.Text))
            {
                if (endDateIsEqualOrBiggerThanStartDate(textBoxEndDate.Text, textBoxStartDate.Text))
                {



                    this.Close();
                    MenuScreen obj = new MenuScreen();
                    obj.Show();
                }
                else 
                {
                    MessageBox.Show("The Start Date is bigger than End Date!");
                }
            }
            else 
            {
                MessageBox.Show("All the fields are mandatory!!");
            }
        }

        private void RegisterNewCarRentScreen_Load(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCarPlate.Text = null;
            textBoxClientID.Text = null;
            textBoxStartDate.Text = null;
            textBoxEndDate.Text = null;
            textBoxCity.Text = null;
        }
    }
}
