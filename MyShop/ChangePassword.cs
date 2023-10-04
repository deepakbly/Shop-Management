using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShop
{
    public partial class ChangePassword : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (txtnewpass.Text == txtconfirm.Text)
            {
                SqlCommand cmd = new SqlCommand("exec ChangePassword '" + AppData.C_id + "','" + txtnewpass.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Mismach", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void clear()
        {
            txtconfirm.Text = "";
            txtnewpass.Text = "";
        }
    }
}
