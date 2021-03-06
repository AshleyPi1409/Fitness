﻿using Fitness.dao;
using Fitness.dto;
using Fitness.gui;
using MaterialSkin;
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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen500, Primary.Brown800, Primary.BlueGrey500, Accent.Lime700, TextShade.BLACK);
            txtPass.PasswordChar = '*';
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
                if (temp.active == true)
                {
                    txtAcc.Text = "";
                    txtPass.Text = "";
                    MessageBox.Show("Login sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main myMain = new Main(acc);
                    myMain.Show();
                }
                else MessageBox.Show("Your Account is deactived");
            }
            else
            {
                MessageBox.Show("Login false", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Dispose();
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }  
        }

    }
}
