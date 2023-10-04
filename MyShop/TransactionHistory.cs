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
    public partial class TransactionHistory : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        DataTable dt = new DataTable();

        public TransactionHistory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adpt = new SqlDataAdapter("select (select customer_name from tblCustomer as d where d.id=b.customer_id) as Customer_name,type,discription,amount,date from tblCustMgmt as b where customer_id='" + cmbCustomer.SelectedValue + "' and date between '" + dtpFromdate.Value.ToString("yyyy/dd/MM") + "' and '" + dtptodate.Value.ToString("yyyy/dd/MM") + "'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dgvtransactionHistory.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvtransactionHistory.DataSource = null;
            dtptodate.Text = "";
            dtpFromdate.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadCustomer()
        {
            string querry = "select id,customer_name from tblCustomer where c_id='" + AppData.C_id + "'";
            SqlDataAdapter adpt1 = new SqlDataAdapter(querry, con);
            DataTable dt1 = new DataTable();
            adpt1.Fill(dt1);
            cmbCustomer.DataSource = dt1;
            cmbCustomer.DisplayMember = "customer_name";
            cmbCustomer.ValueMember = "id";
            cmbCustomer.Enabled = true;
            
        }

        private void TransactionHistory_Load(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            LoadCustomer();
        }
    }
}
