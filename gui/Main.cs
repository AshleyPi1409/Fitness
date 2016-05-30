using Fitness.dao;
using Fitness.utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness.gui
{
    public partial class Main : MaterialForm
    {
        RoleDAO roleDAO = new RoleDAO();
        public Main()
        {
            InitializeComponent();
            

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            tblLayCal.Width = 123;

            GetSource.getTableSource(AccountDAO.READ_ALL,dgvAccount);
            GetSource.getTableSource(CustomerDAO.READ_ALL, dgvCustomer);
            GetSource.getTableSource(BillDAOL.READ_ALL, dgvBill);
            GetSource.getTableSource(BookedDAO.READ_ALL, dgvBooked);

            GetSource.getComboxSource(RoleDAO.READ_ALL, cbbRole, "roleName");
            GetSource.getComboxSource(TypeDAO.READ_ALL, cbbType, "Name");
            GetSource.getComboxSource(TypeDAO.READ_ALL, cbbType2, "Name");
            
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel14_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tblLayCal.Width = 364;
            groupBox1.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tblLayCal.Width = 123;
            groupBox1.Hide();
        }

        private void materialSingleLineTextField7_Click(object sender, EventArgs e)
        {

        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvAccount.SelectedRows[0];

                txtAccName.Text = i.Cells[3].Value.ToString();
                txtAcc.Text = i.Cells[1].Value.ToString();
                String temp = i.Cells[4].Value.ToString();
       
                cbbRole.SelectedValue = Int32.Parse(temp);
            }
        }

        private void dgvCourse_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvCourse.SelectedRows[0];

                txtCourseName.Text = i.Cells[1].Value.ToString();
                txtCourseMont.Text = i.Cells[2].Value.ToString();
                txtCoursePrice.Text = i.Cells[3].Value.ToString();
                String temp = i.Cells[4].Value.ToString();
               
                cbbRole.SelectedValue = Int32.Parse(temp);
            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvCustomer.SelectedRows[0];

                txtCusName.Text = i.Cells[1].Value.ToString();
                txtCusAddr.Text = i.Cells[2].Value.ToString();
                txtCusPhone.Text = i.Cells[3].Value.ToString();
                
            }
        }
    }
}
