using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customer = txtCustomer.Text.Trim();
            string typeCustomer = cboCustomerType.Text.Trim();
            //string numberPeople = txtPeople.Text.Trim();
            string lastWater = txtWaterLastMonth.Text.Trim();
            string currentWater = txtWaterCurrentMonth.Text.Trim();
            int countmember = 0;
            double money = 0;

            if (string.IsNullOrEmpty(customer))
            {
                MessageBox.Show("Customer is not empty");
                return;
            }
            if (string.IsNullOrEmpty(typeCustomer))
            {
                MessageBox.Show("typeCustomer is not empty");
                return;
            }
            if (typeCustomer == "Household")
            {
                // da chon loai khac hang la ho gia dinh
                string member = txtPeople.Text.Trim();
                if (!int.TryParse(member, out countmember))
                {
                    MessageBox.Show("People is number");
                    return;
                }
                double usingWater = Convert.ToDouble(currentWater) - Convert.ToDouble(lastWater);
                if (usingWater > 0)
                {
                    MessageBox.Show("So nuoc thang hien tai khong nho hon do nuoc thang truoc");
                    return;
                }
                double peopleWater = usingWater / countmember;
                if (peopleWater == 10)
                {
                    money = (usingWater * 5.973 * 1.1) / countmember;
                }
                else if (peopleWater > 10 && peopleWater <= 20)
                {
                    money = (usingWater * 7.052 * 1.1) / countmember;
                }
                else if (peopleWater > 20 && peopleWater <= 30)
                {
                    money = (usingWater * 8.699 * 1.1) / countmember;
                }
                else if (peopleWater > 30)
                {
                    money = (usingWater * 9.955 * 1.1) / countmember;
                }
                //them du lieu vao listview
                ListViewItem newItems = new ListViewItem(customer);
                newItems.SubItems.Add(typeCustomer);
                newItems.SubItems.Add(countmember.ToString());
                newItems.SubItems.Add(lastWater.ToString());
                newItems.SubItems.Add(currentWater.ToString());
                newItems.SubItems.Add(peopleWater.ToString());
                newItems.SubItems.Add(money.ToString());
                listViewWaterBill.Items.Add(newItems);
            }
            else
            {
                // loai khach hang khac
                txtPeople.Clear();
         
            }

        }

        private void cboCustomerType_DropDownClosed(object sender, EventArgs e)
        {
            if (cboCustomerType.SelectedValue == "Household")
            {
                txtPeople.Enabled = false;
            }
            else
            {
                txtPeople.Clear();
                txtPeople.Enabled = true;
            }
        }

        private void cboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = cboCustomerType.SelectedItem.ToString();
            val = val.Trim();
            if (val == "Household")
            {
                txtPeople.Enabled = true;
            }
            else
            {
                txtPeople.Clear();
                txtPeople.Enabled = false;
            }
        }
    }
}
