using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CRUD_Test
{
    public partial class TicketBooking : Form
    {
        public TicketBooking()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=SandunDB;Integrated Security=True");

        public int price;
        public static int Quantity,Total;
        public static string Category,ID,UserName,MovieTitle,QTY,TotalPrice ;

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do You Want to Close Program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActionDetails D = new ActionDetails();
            D.ShowDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movies am = new Movies();
            am.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Category = cmbCategory.Text;
            ID = txtID.Text;
            UserName = txtName.Text;
            MovieTitle = cmbMovie.Text;

            switch (cmbMovie.Text)
            {
                case "John Wick 3":
                    price = 580;
                    break;
                case "The Dark Knight":
                    price = 620;
                    break;
                case "Black Panther":
                    price = 530;
                    break;
                case "Inception":
                    price = 560;
                    break;
                case "Passengers":
                    price = 635;
                    break;
                case "Beauty and the Beast":
                    price = 540;
                    break;
                case "Aladdin":
                    price = 535;
                    break;
                case "Me Before You":
                    price = 550;
                    break;
                case "Teenager Mutant Ninja Turtles: Mutant Mayhem":
                    price = 640;
                    break;
                case "The Secret Kingdom":
                    price = 680;
                    break;
                case "The Quest For Tom Sawyer's Gold":
                    price = 660;
                    break;
                case "Asterix & Obelix : The Middle Kingdom":
                    price = 725;
                    break;
                case "Evil Dead Rise":
                    price = 670;
                    break;
                case "The Last Voyage Of The Demeter":
                    price = 760;
                    break;
                case "Knock At The Cabin":
                    price = 788;
                    break;
                case "Insidious : The Red Door":
                    price = 740;
                    break;
            }
            txtPrice.Text = price.ToString();
            
            Quantity = int.Parse(txtQty.Text);
            Total = price * Quantity;
            txtTotal.Text = Total.ToString();
            QTY = Quantity.ToString();
            TotalPrice = Total.ToString();
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TicketDetails VALUES(@ID,@name,@Contact_No,@Email,@Movie,@Price,@QTY,@Total)", con);
                cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("@ID", txtID.Text);
                 cmd.Parameters.AddWithValue("@name", txtName.Text);
                 cmd.Parameters.AddWithValue("@Contact_No", txtContactNo.Text);
                 cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                // cmd.Parameters.AddWithValue("@Time", cmbTime.Text);
                // cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString());
                 cmd.Parameters.AddWithValue("@Movie", cmbMovie.Text);
                 cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                 cmd.Parameters.AddWithValue("@QTY", txtQty.Text);
                 cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                


                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Customer is successfully saved in the database!!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();

                txtID.Clear();
                txtName.Clear();
                txtEmail.Clear();
            }


            

        }

        private bool IsValid()
        {
            if(txtName.Text == string.Empty)
            {
                MessageBox.Show("Customer Name is required", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }
        
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCategory.Text)
            {
                case "Action":
                    cmbMovie.Items.Clear();
                    cmbMovie.Items.Add("John Wick 3");
                    cmbMovie.Items.Add("The Dark Knight");
                    cmbMovie.Items.Add("Black Panther");
                    cmbMovie.Items.Add("Inception");
                    break;
                case "Romance":
                    cmbMovie.Items.Clear();
                    cmbMovie.Items.Add("Passengers");
                    cmbMovie.Items.Add("Beauty and the Beast");
                    cmbMovie.Items.Add("Aladdin");
                    cmbMovie.Items.Add("Me Before You");
                    break;
                case "Family":
                    cmbMovie.Items.Clear();
                    cmbMovie.Items.Add("Teenager Mutant Ninja Turtles: Mutant Mayhem");
                    cmbMovie.Items.Add("The Secret Kingdom");
                    cmbMovie.Items.Add("The Quest For Tom Sawyer's Gold");
                    cmbMovie.Items.Add("Asterix & Obelix : The Middle Kingdom");
                    break;
                case "Horror":
                    cmbMovie.Items.Clear();
                    cmbMovie.Items.Add("Evil Dead Rise");
                    cmbMovie.Items.Add("The Last Voyage Of The Demeter");
                    cmbMovie.Items.Add("Knock At The Cabin");
                    cmbMovie.Items.Add("Insidious : The Red Door");
                    break;
                default:
                    cmbMovie.Items.Clear();
                    cmbMovie.Items.Add("Select a category");
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeatsBooking sn = new SeatsBooking();
            sn.ShowDialog();
            
        }

        private void GetStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from TicketDetails", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentRecordDataGridView.DataSource = dt;


        }

    }
}
