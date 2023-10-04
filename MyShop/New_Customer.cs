using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShop
{
    public partial class New_Customer : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        SqlCommand cmd = new SqlCommand();

        public New_Customer()
        {
            InitializeComponent();
        }

        private void New_Customer_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtcust_name.Text = "";
            txtcust_no.Text = "";
            txtcust_address.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            
               
        }

        void opennewform()
        {
            Application.Run(new CustTransaction());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (txtcust_name.Text == "" || txtcust_no.Text == "" || txtcust_address.Text == "")
            {
                MessageBox.Show("Fill Mandetory Fields.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("exec CustomerInsert '" + AppData.C_id + "','" + txtcust_name.Text + "','" + txtcust_address.Text + "','" + txtcust_no.Text + "'", con);
                cmd.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("exec CustomerInsert", con);
                // AppData.GetNewId = cmd.ExecuteScalar().ToString();
                SqlDataAdapter adpt = new SqlDataAdapter("select MAX(id) as id from tblCustomer", con);
                DataTable dt3 = new DataTable();
                adpt.Fill(dt3);
                AppData.GetNewId = dt3.Rows[0]["id"].ToString();
                con.Close();
                DialogResult dr = MessageBox.Show("Customer saved successfully. Do you want to continue transaction process.", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    this.Close();
                    Thread th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    txtcust_name.Text = "";
                    txtcust_no.Text = "";
                    txtcust_address.Text = "";
                }
        }
    }
}
}