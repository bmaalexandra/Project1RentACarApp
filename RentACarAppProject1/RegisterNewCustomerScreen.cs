using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace RentACarAppProject1
{
    public partial class RegisterNewCustomerScreen : Form
    {
        public RegisterNewCustomerScreen()
        {
            InitializeComponent();
        }

        //this function check if the date format is dd-MM-yyyy
        public bool validateDate(string str) {
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

        public bool validateZipCode(string str) {
            if (str.Length == 6)
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxClientID.Text) && !string.IsNullOrEmpty(textBoxClientName.Text) && !string.IsNullOrEmpty(textBoxBirthDate.Text) && !string.IsNullOrEmpty(textBoxCity.Text))
            {
                if (validateDate(textBoxBirthDate.Text))
                {
                    String mainconnection = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    SqlConnection sqlconnection = new SqlConnection(mainconnection);
                    String sqlquery = "SET IDENTITY_INSERT Customers ON if not exists(select * from Customers where CustomerID=@CustomerID) begin insert into [dbo].[Customers](CustomerID, Name, BirthDate, Location) values (@CustomerID, @Name, @BirthDate, @Location) end SET IDENTITY_INSERT Customers OFF";
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

        private void RegisterNewCustomerScreen_Load(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxClientID.Text = null;
            textBoxClientName.Text = null;
            textBoxBirthDate.Text = null;
            textBoxCity.Text = null;
            textBoxZIPCode.Text = null;
        }
    }
}
