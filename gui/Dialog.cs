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

namespace Fitness.gui
{
    public partial class Dialog : MaterialForm
    {
        public String pass;
        public Dialog()
        {
            InitializeComponent();
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }  
        }
        public String showDialog()
        {
            

        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            pass = txtPass.Text;
         
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
