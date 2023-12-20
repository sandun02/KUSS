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
    public partial class ActionDetails : Form
    {
        public ActionDetails()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dsAction1.Clear();
            sqlDataAdapter1.Fill(dsAction1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.BindingContext[dsAction1, "ActionDB"].Position -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.BindingContext[dsAction1, "ActionDB"].Position += 1;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movies h = new Movies();
            h.ShowDialog();
            
        }
    }
}
