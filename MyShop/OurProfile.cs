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
    public partial class OurProfile : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        DataTable dt = new DataTable();
        SqlDataAdapter adpt = new SqlDataAdapter();
        
        public OurProfile()
        {
            InitializeComponent();
        }

        private void OurProfile_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            adpt = new SqlDataAdapter("select c_name,c_ownername,c_address,c_contactno,owner_no from tblCompany where id='" + AppData.C_id + "'", con);
            adpt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtc_name.Text = dt.Rows[0]["c_name"].ToString();
                txtownername.Text = dt.Rows[0]["c_ownername"].ToString();
                txtc_address.Text = dt.Rows[0]["c_address"].ToString();
                txtc_no.Text = dt.Rows[0]["c_contactno"].ToString();
                txtownerNo.Text = dt.Rows[0]["owner_no"].ToString();
            }
            else
            {
                MessageBox.Show("Page load error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("exec ProfileUpdation '"+AppData.C_id+ "','" + txtc_name.Text + "','" + txtownername.Text + "','" + txtc_address.Text + "','" + txtc_no.Text + "','"+txtownerNo.Text+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
