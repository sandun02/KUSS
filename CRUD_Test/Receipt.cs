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
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
            lblTitle.Text = TicketBooking.MovieTitle;
            lblCategory.Text = TicketBooking.Category;
            lblID.Text = TicketBooking.ID;
            lblName.Text = TicketBooking.UserName;
            lblQTY.Text = TicketBooking.QTY;
            lblTotal.Text = TicketBooking.TotalPrice;
        }
    }
}
