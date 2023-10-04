using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace MyShop
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        SqlCommand cmd = new SqlCommand();

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            if(txtc_name.Text=="" || txtownername.Text=="" || txtownerNo.Text == "" || txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Fill Mandetory Fields.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtpassword.Text == txtconfirmpass.Text)
                {
                    SqlCommand cmd = new SqlCommand("exec CustomerIn '" + txtc_name.Text + "','" + txtownername.Text + "','" + txtc_address.Text + "','" + txtc_no.Text + "','" + txtownerNo.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Signup Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.Close();
                    Thread th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Password Mismach", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           

        }

        void opennewform()
        {
            Application.Run(new Login());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtc_name.Text = "";
            txtc_address.Text = "";
            txtc_no.Text = "";
            txtownername.Text = "";
            txtownerNo.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtconfirmpass.Text = "";
        }
    }
}
