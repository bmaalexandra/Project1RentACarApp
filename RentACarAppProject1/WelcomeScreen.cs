using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarAppProject1
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        //when we press on "ENTER", we go to MenuScreen
        private void linkLabelEnter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MenuScreen obj = new MenuScreen();
            
            if (obj == null) {
                obj.Parent = this;
            }

            obj.Show();
            this.Hide();
        }


        //when we press "ESC", we close the application
        private void linkLabelEsc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); //for closing the program
        }
    }
}
