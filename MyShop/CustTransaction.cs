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
    public partial class CustTransaction : Form
    {

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        SqlDataAdapter adpt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        int id = 0;
             
        public CustTransaction()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            clear();
            cmbsearchby.SelectedIndex = -1;
            txtdata.Text = "";
            dgvtransaction.DataSource = null;
            btnSearch.Enabled = true;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            txtamount.Text = "";
            txtdescription.Text = "";
            cmbType.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
            cmbsearchby.SelectedIndex = 1;
            txtdata.Text = "";
            dgvtransaction.DataSource = null;
            btnSearch.Enabled = true;
            AppData.GetNewId = "";
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (cmbsearchby.Text == "Name")
            {
                adpt = new SqlDataAdapter("select id,customer_name from tblCustomer where customer_name='" + txtdata.Text + "' and c_id='" + AppData.C_id + "'", con);
                adpt.Fill(dt);
                if (dt.Rows.Count ==1)
                {
                    
                    id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    string namwe = dt.Rows[0]["customer_name"].ToString();
                    // dgvtransaction.DataSource = dt;
                    if (id > 0)
                    {
                        diaplaybyId();
                    }
                    btnSearch.Enabled = false;
                  
                }
                else
                {
                    MessageBox.Show("Data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dt.Clear();
                con.Close();
            }
            else if (cmbsearchby.Text == "Mobile No")
            {
                adpt = new SqlDataAdapter("select id from tblCustomer where customer_contactno='" + txtdata.Text + "' and c_id='" + AppData.C_id + "'", con);
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    id =Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    // dgvtransaction.DataSource = dt;
                    diaplaybyId();
                    btnSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dt.Clear();
                con.Close();
            }
            else
            {
                MessageBox.Show("Select search by option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DialogResult dr = MessageBox.Show("Please Confirm Transaction", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr==DialogResult.Yes)
            {
                if (AppData.GetNewId == "")
                {
                    cmd = new SqlCommand("exec TransacIn '" + id + "','" + cmbType.SelectedItem + "','" + txtdescription.Text + "','" + txtamount.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaction Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    diaplaybyId();
                    clear();
                }
                else
                {
                    cmd = new SqlCommand("exec TransacIn '" + AppData.GetNewId + "','" + cmbType.SelectedItem + "','" + txtdescription.Text + "','" + txtamount.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaction Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    diaplaybyGetNewId();
                    clear();
                }
            }
            else
            {
                MessageBox.Show("Transaction Failde", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CustTransaction_Load(object sender, EventArgs e)
        {
            if (AppData.GetNewId ==null)
            {

                MessageBox.Show("Search Customer for transaction", "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlDataAdapter adpt1 = new SqlDataAdapter("select customer_name from tblCustomer where id='" + AppData.GetNewId + "'", con);
                DataTable dts = new DataTable();
                adpt1.Fill(dts);
                cmbsearchby.SelectedIndex = 0;
                txtdata.Text = dts.Rows[0]["customer_name"].ToString();
                btnSearch.Enabled = false;
                diaplaybyGetNewId();
                
            }
        }

        void diaplaybyGetNewId()
        {
            SqlDataAdapter GNI = new SqlDataAdapter("select (select customer_name from tblCustomer as d where d.id=b.customer_id) as Customer_name,type,discription,amount,date from tblCustMgmt as b where customer_id='" + AppData.GetNewId + "'", con);
            DataTable dtg = new DataTable();
            GNI.Fill(dtg);
            dgvtransaction.DataSource = dtg;
            con.Close();
        }

        void diaplaybyId()
        {
            SqlDataAdapter GNI = new SqlDataAdapter("select (select customer_name from tblCustomer as d where d.id=b.customer_id) as Customer_name,type,discription,amount,date from tblCustMgmt as b where customer_id='" +id  + "'", con);
            DataTable dtg = new DataTable();
            GNI.Fill(dtg);
            dgvtransaction.DataSource = dtg;
            con.Close();
        }
    }
}
