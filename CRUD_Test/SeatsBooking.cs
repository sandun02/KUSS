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
    
    public partial class SeatsBooking : Form
    {
        
        List<Customer> ListCustomer = new List<Customer>();
        public SeatsBooking()
        {
            InitializeComponent();
        }
        public static string FilmTitle;
        private void Form4_Load(object sender, EventArgs e)
        {
            
            
            Draw100chairs();
            //lblFilmTitle.Text = Form1.MovieTitle;
            FilmTitle = cmbMovieTitle.Text;
        }

        
        private void Draw100chairs()
        {
            int chair = 1;
            for(int i =0; i< pnChair.RowCount; i++)
            {
                for(int j=0;j < pnChair.ColumnCount; j++)
                {
                    Label lblchair = new Label();

                    lblchair.Text = chair + ""; // To string
                    lblchair.AutoSize = false;
                    lblchair.Dock = DockStyle.Fill;
                    lblchair.TextAlign = ContentAlignment.MiddleCenter;
                    lblchair.BackColor = Color.White;

                    pnChair.Controls.Add(lblchair, i, j);

                    chair++;

                    

                    lblchair.Click += Lblchair_Click;
                }
            }
        }

        private void Lblchair_Click(object sender, EventArgs e)
        {
            Label lblchair = sender as Label;
            //Change white to skyblue
            if(lblchair.BackColor == Color.White)
            {
                lblchair.BackColor = Color.SkyBlue;
            }
            //Change skyblue to white
            else if(lblchair.BackColor == Color.SkyBlue)
            {
                lblchair.BackColor = Color.White;
            }
            
            //YellowGreen.Don't order
            else if(lblchair.BackColor == Color.YellowGreen)
            {
                MessageBox.Show("The Chair" + lblchair.Text + " is choose.");
            } 
        }
        public static int Tprice;
        private void btnOrder_Click(object sender, EventArgs e)
        {
            switch (cmbMovieTitle.Text)
            {
                case "John Wick 3":
                    Tprice = 580;
                    break;
                case "The Dark Knight":
                    Tprice = 620;
                    break;
                case "Black Panther":
                    Tprice = 530;
                    break;
                case "Inception":
                    Tprice = 560;
                    break;
                case "Passengers":
                    Tprice = 635;
                    break;
                case "Beauty and the Beast":
                    Tprice = 540;
                    break;
                case "Aladdin":
                    Tprice = 535;
                    break;
                case "Me Before You":
                    Tprice = 550;
                    break;
                case "Teenager Mutant Ninja Turtles: Mutant Mayhem":
                    Tprice = 640;
                    break;
                case "The Secret Kingdom":
                    Tprice = 680;
                    break;
                case "The Quest For Tom Sawyer's Gold":
                    Tprice = 660;
                    break;
                case "Asterix & Obelix : The Middle Kingdom":
                    Tprice = 725;
                    break;
                case "Evil Dead Rise":
                    Tprice = 670;
                    break;
                case "The Last Voyage Of The Demeter":
                    Tprice = 760;
                    break;
                case "Knock At The Cabin":
                    Tprice = 788;
                    break;
                case "Insidious : The Red Door":
                    Tprice = 740;
                    break;
            }
            CustomerD sandun = new CustomerD();

            if(sandun.ShowDialog() == DialogResult.OK)
            {
                Customer cus = new Customer();
                cus.NameCustomer = sandun.txtNameCustomer.Text;
                cus.CustomerNo = sandun.txtCustomerNo.Text;

                for(int i = 0; i < pnChair.Controls.Count; i++)
                {
                    Label lblchair = pnChair.Controls[i] as Label;
                    if (lblchair.BackColor == Color.SkyBlue)
                    {
                        lblchair.BackColor = Color.YellowGreen;
                        int chair = int.Parse(lblchair.Text);
                        cus.chairs.Add(chair);
                    }
                }
                lblPrice.Text = cus.Price + ".00";
                ListCustomer.Add(cus);

                
                DisplayTotalMoney();
                
                DisplayCustomerOnListBox();
            }
        }
        private void DisplayTotalMoney()
        {
            double sum = 0;
            foreach(Customer cus in ListCustomer)
            {
                sum += cus.Price;
                lblTotalPrice.Text = sum + ".00";
            }
        }
        private void DisplayCustomerOnListBox()
        {
            lstCustomers.Items.Clear();
            foreach(Customer cus in ListCustomer)
            {
                lstCustomers.Items.Add(cus);
            }
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCustomers.SelectedIndex != -1)
            {
                Customer cus = lstCustomers.SelectedItem as Customer;
                lblPrice.Text = cus.Price + ".00";
            }
        }

        private void btnTikketCalculation_Click(object sender, EventArgs e)
        {
            Customer cus = lstCustomers.SelectedItem as Customer;
            if(lstCustomers.SelectedIndex != -1)
            {
                for(int i=0;i < pnChair.Controls.Count; i++)
                { 
                    Label lblchair = pnChair.Controls[i] as Label;
                    int codeChair = int.Parse(lblchair.Text);
                    int flag = 0;
                    while(cus.chairs.Count > 0 && flag < cus.chairs.Count)
                    {
                        int orderedChair = cus.chairs[0];
                        if(codeChair == orderedChair)
                        {
                            lblchair.BackColor = Color.White;
                            cus.chairs.Remove(orderedChair);
                        }
                        flag++;
                    }

                }
                ListCustomer.Remove(cus);
                DisplayCustomerOnListBox();
                DisplayTotalMoney();
            }
            else
            {
                MessageBox.Show("You should select customer.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            
            Receipt san = new Receipt();
            san.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketBooking YM = new TicketBooking();
            YM.Show();
            
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login L = new Login();
            L.ShowDialog();
        }
    }
}
