﻿using System;
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
    public partial class ListCustomersScreen : Form
    {
        public ListCustomersScreen()
        {
            InitializeComponent();
        }

        private void ListCustomersScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academy_netDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.academy_netDataSet.Customers);

        }

       
    }
}
