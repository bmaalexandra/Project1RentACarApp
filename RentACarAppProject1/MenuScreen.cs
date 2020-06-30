using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarAppProject1
{
    public partial class MenuScreen : Form
    {
        public MenuScreen()
        {
            InitializeComponent();
        }
        
        //when we press option "8 Quit", we close the application
        private void linkLabelQuit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); //for closing the program
        }

        private void linkLabelListCustomers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListCustomersScreen obj = new ListCustomersScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelUpdateCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateCustomerScreen obj = new UpdateCustomerScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelRegisterNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterNewCustomerScreen obj = new RegisterNewCustomerScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelListAvailableCars_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListAvailableCarsScreen obj = new ListAvailableCarsScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelListRents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListRentsScreen obj = new ListRentsScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelUpdateNewCarRent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateCarRentScreen obj = new UpdateCarRentScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void linkLabelRegisterNewCartRent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterNewCarRentScreen obj = new RegisterNewCarRentScreen();

            if (obj == null)
            {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
