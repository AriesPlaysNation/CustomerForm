using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private List<Customer> customers = null;



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer addCustomers = new frmAddCustomer();
            Customer customer = addCustomers.newCustomer();
            if(customer != null)
            {
                customers.Add(customer);
                CustomerDB.SaveCustomers(customers);
                AddCustomersBox();
            }
        }

        private void AddCustomersBox()
        {
            lstCustomers.Items.Clear();
            foreach (Customer customer in customers)
            {
                lstCustomers.Items.Add(customer.GetDisplayText());
            }
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();
            AddCustomersBox();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex != -1)
            {
                Customer customer = customers[lstCustomers.SelectedIndex];
                string message = "Delete customer " + customer.FirstName + " " + customer.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Delete?", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    customers.Remove(customer);
                    CustomerDB.SaveCustomers(customers);
                    AddCustomersBox();
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}