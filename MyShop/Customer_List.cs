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
    public partial class Customer_List : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        SqlDataAdapter adpt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        public Customer_List()
        {
            InitializeComponent();
        }

        private void Customer_List_Load(object sender, EventArgs e)
        {
            griddisplay();
            paneldata.Visible = false;
        }

        void griddisplay()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adpt = new SqlDataAdapter("select id,customer_name,customer_address,customer_contactno from tblCustomer where c_id='"+AppData.C_id+"'", con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dgvCustomer.DataSource = dt;
            con.Close();
        }

        string CustId;

        private void dgvCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            paneldata.Visible = true;
            CustId = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adpt = new SqlDataAdapter("select id, customer_name, customer_address, customer_contactno from tblCustomer where id = '" + CustId + "'", con);
            DataTable dt1 = new DataTable();
            adpt.Fill(dt1);
            txtcust_name.Text =dt1.Rows[0]["customer_name"].ToString();
            txtcust_address.Text = dt1.Rows[0]["customer_address"].ToString();
            txtcust_no.Text = dt1.Rows[0]["customer_contactno"].ToString();
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DialogResult dr = MessageBox.Show("Do you want to Update this Customer.", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                cmd = new SqlCommand("exec CustomerUp '"+CustId+ "','" + txtcust_name.Text + "','" + txtcust_address.Text + "','" + txtcust_no.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Updated Successfully.", "Success");
                clear();
                paneldata.Visible = false;
                griddisplay();
            }
            else
            {
                MessageBox.Show("Customer Updation Process Failed.", "Failed");
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DialogResult dr = MessageBox.Show("Do you want to delete this Customer.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete from tblCustomer where id='" + CustId + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Deleted Successfully.","Success");
                clear();
                paneldata.Visible = false;
                griddisplay();
            }
            else
            {
                MessageBox.Show("Customer Deletion Process Failed.","Failed");
            }
            con.Close();
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            paneldata.Visible = false;
            griddisplay();
        }

        void clear()
        {
            txtcust_address.Text = "";
            txtcust_name.Text = "";
            txtcust_no.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
