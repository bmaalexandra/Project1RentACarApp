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
    public partial class ListAvailableCarsScreen : Form
    {
        public ListAvailableCarsScreen()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCity.Text = null;
            textBoxEndDate.Text = null;
            textBoxStartDate.Text = null;
            textBoxClienID.Text = null;
            textBoxCarPlate.Text = null;
        }

        private void ListAvailableCarsScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
