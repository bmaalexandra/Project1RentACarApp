using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace RentACarAppProject1
{
    public partial class ListRentsScreen : Form
    {
        public ListRentsScreen()
        {
            InitializeComponent();
        }

        private void ListRentsScreen_Load(object sender, EventArgs e)
        {
            this.carsTableAdapter.Fill(this.academy_netDataSet.Cars);
        }
    }
}
