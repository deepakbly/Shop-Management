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

namespace MyShop
{
    public partial class MDI_Main : Form
    {
        public MDI_Main()
        {
            InitializeComponent();
        }

        private void btnMenuCustomer_Click(object sender, EventArgs e)
        {
            if (pnlCustomer.Visible == true)
            {
                pnlCustomer.Visible = false;
                pnlReport.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlTransaction.Visible = false;
            }
            else
            {
                pnlCustomer.Visible = true;
                pnlReport.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlTransaction.Visible = false;
            }
        }

        private void btnMenuTransaction_Click(object sender, EventArgs e)
        {
            if (pnlTransaction.Visible == true)
            {
                pnlTransaction.Visible = false;
                pnlReport.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlCustomer.Visible = false;
            }
            else
            {
                pnlTransaction.Visible = true;
                pnlReport.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlCustomer.Visible = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (pnlReport.Visible == true)
            {
                pnlReport.Visible = false;
                pnlTransaction.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlCustomer.Visible = false;
            }
            else
            {
                pnlReport.Visible = true;
                pnlTransaction.Visible = false;
                pnlOtherFeature.Visible = false;
                pnlCustomer.Visible = false;
            }
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            if (pnlOtherFeature.Visible == true)
            {
                pnlOtherFeature.Visible = false;
                pnlReport.Visible = false;
                pnlTransaction.Visible = false;
                pnlCustomer.Visible = false;
            }
            else
            {
                pnlOtherFeature.Visible = true;
                pnlReport.Visible = false;
                pnlTransaction.Visible = false;
                pnlCustomer.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ////clsGlobalVariable.School_Name = cmbSchoolName.Text;
            Thread th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        void opennewform()
        {
            Application.Run(new Login());
        }

        private void MDI_Main_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome : " + AppData.Company_Name;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(New_Customer))
                {
                    form.Activate();
                    return;
                }
            }
            New_Customer NCustomer = new New_Customer();
            NCustomer.MdiParent = this;
            NCustomer.Show();
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Customer_List))
                {
                    form.Activate();
                    return;
                }
            }
            Customer_List CustomerList = new Customer_List();
            CustomerList.MdiParent = this;
            CustomerList.Show();
        }

        private void btnCustTransaction_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CustTransaction))
                {
                    form.Activate();
                    return;
                }
            }
            CustTransaction Ctransac = new CustTransaction();
            Ctransac.MdiParent = this;
            Ctransac.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(TransactionHistory))
                {
                    form.Activate();
                    return;
                }
            }
            TransactionHistory Htransac = new TransactionHistory();
            Htransac.MdiParent = this;
            Htransac.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ChangePassword))
                {
                    form.Activate();
                    return;
                }
            }
            ChangePassword CPass = new ChangePassword();
            CPass.MdiParent = this;
            CPass.Show();
        }

        private void btnOurProfile_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(OurProfile))
                {
                    form.Activate();
                    return;
                }
            }
            OurProfile OPro = new OurProfile();
            OPro.MdiParent = this;
            OPro.Show();
        }
    }
}
