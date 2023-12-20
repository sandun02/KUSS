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
    public partial class Movies : Form
    {
        public Movies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void btnMoviesDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActionDetails ym = new ActionDetails();
            ym.ShowDialog();
            
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            this.Hide();
            Action s = new Action();
            s.ShowDialog();
            
        }

        private void btnRomance_Click(object sender, EventArgs e)
        {
            this.Hide();
            Romance s = new Romance();
            s.ShowDialog();
            
        }

        private void btnFamily_Click(object sender, EventArgs e)
        {
            this.Hide();
            Family s = new Family();
            s.ShowDialog();
            
        }

        private void btnHorror_Click(object sender, EventArgs e)
        {
            this.Hide();
            Horror s = new Horror();
            s.ShowDialog();
            
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login LL = new Login();
            LL.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
