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
    public partial class Horror : Form
    {
        public Horror()
        {
            InitializeComponent();
        }

        private void pictureBoxH1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketBooking sn = new TicketBooking();
            sn.ShowDialog();
            
        }

        private void pictureBoxH2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketBooking sn = new TicketBooking();
            sn.ShowDialog();
            
        }

        private void pictureBoxH3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketBooking sn = new TicketBooking();
            sn.ShowDialog();
            
        }

        private void pictureBoxH4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketBooking sn = new TicketBooking();
            sn.ShowDialog();
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movies h = new Movies();
            h.ShowDialog();
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
