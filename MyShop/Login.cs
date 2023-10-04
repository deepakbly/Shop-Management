using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MyShop
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["dbconnect"].ToString());
        SqlDataAdapter adpt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            adpt = new SqlDataAdapter("select id,c_name from tblCompany where username='" + txtUserName.Text+ "' and password='" + txtPassword.Text+"'", con);
            adpt.Fill(dt); 
            if (dt.Rows.Count > 0)
            {
                AppData.C_id = dt.Rows[0]["id"].ToString();
                AppData.Company_Name = dt.Rows[0]["c_name"].ToString();
                this.Close();
                Thread th = new Thread(OpennewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Login Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void OpennewForm()
        {
            Application.Run(new MDI_Main());
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenRegistration);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        void OpenRegistration()
        {
            Application.Run(new Signup());
        }
    }
}
