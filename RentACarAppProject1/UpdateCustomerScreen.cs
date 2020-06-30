using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarAppProject1
{
    public partial class UpdateCustomerScreen : Form
    {
        public UpdateCustomerScreen()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCity.Text = null;
            textBoxBirthDate.Text = null;
            textBoxClientName.Text = null;
            textBoxClientID.Text = null;
        }

        //this function check if the date format is dd-MM-yyyy
        public bool validateDate(string str)
        {
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))&");
            bool isValid = regex.IsMatch(str.Trim());
            DateTime dt;
            isValid = DateTime.TryParseExact(str, "dd-MM-yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (isValid)
            {
                return true;
            }
            else { return false; }
        }

        public bool validateZipCode(string str)
        {
            if (str.Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxClientID.Text) && !string.IsNullOrEmpty(textBoxClientName.Text) && !string.IsNullOrEmpty(textBoxBirthDate.Text) && !string.IsNullOrEmpty(textBoxCity.Text))
            {
                if (validateDate(textBoxBirthDate.Text))
                {
                    String mainconnection = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    SqlConnection sqlconnection = new SqlConnection(mainconnection);
                    String sqlquery = "if exists(select * from Customers where CustomerID=@CustomerID) begin update [dbo].[Customers] set Name=@Name, BirthDate=@BirthDate, Location=@Location where CustomerID=@CustomerID end";
                    sqlconnection.Open();
                    SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@CustomerID", textBoxClientID.Text);
                    sqlcommand.Parameters.AddWithValue("@Name", textBoxClientName.Text);
                    DateTime birthDate = DateTime.ParseExact(textBoxBirthDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    sqlcommand.Parameters.AddWithValue("@BirthDate", birthDate);
                    sqlcommand.Parameters.AddWithValue("@Location", textBoxCity.Text);
                    sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("Record is saved");
                    sqlconnection.Close();
                    this.Close();
                    MenuScreen obj = new MenuScreen();
                    obj.Show();
                }
                else { MessageBox.Show("Invalid Date format. The valid date format is dd-MM-yyyy. "); }
            }
            else
            {
                MessageBox.Show("All the fields are mandatory, except ZIP Code!! ");
            }
        }

        private void UpdateCustomerScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
