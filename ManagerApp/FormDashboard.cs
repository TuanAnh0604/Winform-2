using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerApp
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            listViewWaterBill.View = View.Details;
            listViewWaterBill.GridLines = true;
            listViewWaterBill.FullRowSelect = true;
            // tao cac cot hien thi
            listViewWaterBill.Columns.Add("Customer", 120);
            listViewWaterBill.Columns.Add("Type", 80);
            listViewWaterBill.Columns.Add("People", 30);
            listViewWaterBill.Columns.Add("Water last month", 120);
            listViewWaterBill.Columns.Add("Water current month", 120);
            listViewWaterBill.Columns.Add("Water used", 50);
            listViewWaterBill.Columns.Add("Total Money", 80);
            listViewWaterBill.Columns.Add("Created At", 100);
        }
    }
}
