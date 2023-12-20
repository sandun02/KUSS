using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Username and Password", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (cmbType.Text == "admin")
                {
                    if (txtName.Text == "admin" && txtPassword.Text == "admin")
                    {
                        MessageBox.Show("Welcome to Cinema Booking System", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        SeatsBooking ss = new SeatsBooking();
                        ss.ShowDialog();
                    }

                    else
                    {
                        MessageBox.Show("Username and Password is Incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (txtName.Text == "user" && txtPassword.Text == "user")
                    {

                        MessageBox.Show("Welcome to Cinema Booking System", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Movies ss = new Movies();
                        ss.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username and Password is Incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
