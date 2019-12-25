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
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private Customer customer = null;

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                customer = new Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
                this.Close();
            }
        }

        private bool isValid()
        {
            return Validator.IsPresent(txtFirstName) && Validator.IsPresent(txtLastName) && Validator.IsPresent(txtEmail) && Validator.IsValidEmail(txtEmail);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Customer newCustomer()
        {
            this.ShowDialog();
            return customer;
        }
    }
}