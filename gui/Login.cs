using Fitness.dao;
using Fitness.dto;
using Fitness.gui;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness
{
    public partial class Login : MaterialForm
    {
        AccountDAO accDAO = new AccountDAO();
        public Login()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            txtAcc.Text = "";
            txtPass.Text = "";
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string acc = txtAcc.Text;

            Accounts temp = accDAO.getAllByAccount(acc);

            if (temp.passWord.Equals(pass))
            {
                txtAcc.Text = "";
                txtPass.Text = "";
                MessageBox.Show("Login sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main myMain = new Main();
                myMain.Show();
            }
            else
            {
                MessageBox.Show("Login false", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose();
            }
        }

    }
}
