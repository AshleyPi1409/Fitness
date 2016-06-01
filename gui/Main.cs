using Fitness.dao;
using Fitness.dto;
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
        CustomerDAO cusDAO = new CustomerDAO();
        AccountDAO accDAO = new AccountDAO();
        public Main()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen500, Primary.Brown800, Primary.BlueGrey500, Accent.Orange100, TextShade.BLACK);
            


            GetSource.getTableSource(AccountDAO.READ_ALL, dgvAccount);
            GetSource.getTableSource(CustomerDAO.READ_ALL, dgvCustomer);
            //GetSource.getTableSource(BillDAOL.READ_ALL, dgvBill);
            GetSource.getTableSource(BookedDAO.READ_ALL, dgvBooked);

            GetSource.getComboxSource(RoleDAO.READ_ALL, cbbRole, "roleName");
            GetSource.getComboxSource(TypeDAO.READ_ALL, cbbType, "Name");
            GetSource.getComboxSource(TypeDAO.READ_ALL, cbbType2, "Name");

            cbbRole.SelectedIndex = -1;


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

        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Accounts a = new Accounts();
            a.accountName = txtAcc.Text;
            a.fullName = txtAccName.Text;
            a.role = Int32.Parse(cbbRole.SelectedValue.ToString());
            Dialog dialog = new Dialog();
            dialog.ShowDialog();
            a.passWord = dialog.pass;
            if (a.passWord != null)
            {

                accDAO.create(a);
                GetSource.getTableSource(AccountDAO.READ_ALL, dgvAccount);
                MessageBox.Show("Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Can not create this account ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAcc.Text = "";
            txtAccName.Text = "";
            cbbRole.SelectedIndex = -1;
        }

        private void materialFlatButton12_Click(object sender, EventArgs e)
        {
            txtAcc.Text = "";
            txtAccName.Text = "";
            cbbRole.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = 0;
            DataGridView dgv = sender as DataGridView;
            if (dgvAccount != null && dgvAccount.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvAccount.SelectedRows[0];
                id = Int32.Parse(i.Cells[0].Value.ToString());
            }
            Accounts acc = new Accounts();
            acc.accountName = txtAcc.Text;
            acc.fullName = txtAccName.Text;
            acc.role = Int32.Parse(cbbRole.SelectedValue.ToString());
            Dialog dialog = new Dialog();
            dialog.ShowDialog();
            acc.passWord = dialog.pass;
            if (id != 0 && acc.passWord != null)
            {
                acc.id = id;
                accDAO.update(acc);
                GetSource.getTableSource(AccountDAO.READ_ALL, dgvAccount);
                MessageBox.Show("Edited", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Can not edit this account ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Delete this account ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                int id = -1;
                DataGridView dgv = sender as DataGridView;
                if (dgvAccount != null && dgvAccount.SelectedRows.Count > 0)
                {
                    DataGridViewRow i = dgvAccount.SelectedRows[0];
                    id = Int32.Parse(i.Cells[0].Value.ToString());
                }

                Accounts acc = new Accounts();
                acc.accountName = txtAcc.Text;
                acc.fullName = txtAccName.Text;
                acc.role = Int32.Parse(cbbRole.SelectedValue.ToString());
                if (id != -1)
                {

                    acc.id = id;
                    accDAO.delete(id);
                    GetSource.getTableSource(AccountDAO.READ_ALL, dgvAccount);
                }
                MessageBox.Show("Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Can not deleted this account ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.Compare(dgvAccount.CurrentCell.OwningColumn.Name, "active") == 0)
            {
                bool checkBoxStatus = Convert.ToBoolean(dgvAccount.CurrentCell.EditedFormattedValue);

                if (checkBoxStatus)
                {
                    int id = Convert.ToInt32(dgvAccount.CurrentRow.Cells[0].Value);
                    accDAO.reactive(id);
                }
                else
                {
                    int id = Convert.ToInt32(dgvAccount.CurrentRow.Cells[0].Value);
                    accDAO.delete(id);
                }
            }
        }

        private void btnCusCreate_Click(object sender, EventArgs e)
        {
            Customer a = new Customer();
            a.name = txtCusName.Text;
            a.address = txtCusAddr.Text;
            a.phone = txtCusPhone.Text;
            cusDAO.create(a);
            GetSource.getTableSource(CustomerDAO.READ_ALL, dgvCustomer);
            MessageBox.Show("Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCusEdit_Click(object sender, EventArgs e)
        {
            Customer a = new Customer();
            a.name = txtCusName.Text;
            a.address = txtCusAddr.Text;
            a.phone = txtCusPhone.Text;
            int id = -1;
            if (dgvAccount != null && dgvCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvCustomer.SelectedRows[0];
                id = Int32.Parse(i.Cells[0].Value.ToString());
            }
            if (id != -1)
            {
                a.id = id;
                cusDAO.update(a);
                GetSource.getTableSource(CustomerDAO.READ_ALL, dgvCustomer);
                MessageBox.Show("Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCusDele_Click(object sender, EventArgs e)
        {
            Customer a = new Customer();
            a.name = txtCusName.Text;
            a.address = txtCusAddr.Text;
            a.phone = txtCusPhone.Text;
            int id = -1;
            if (dgvAccount != null && dgvCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow i = dgvCustomer.SelectedRows[0];
                id = Int32.Parse(i.Cells[0].Value.ToString());
            }
            if (id != -1)
            {
                a.id = id;
                cusDAO.delete(a);
                GetSource.getTableSource(CustomerDAO.READ_ALL, dgvCustomer);
                MessageBox.Show("Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
