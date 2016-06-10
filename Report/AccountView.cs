using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness.Report
{
    public partial class AccountView : Form
    {
        public AccountView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fitnessManagerDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fitnessManagerDataSet.Accounts);
            // TODO: This line of code loads data into the 'fitnessManagerDataSet.Bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.fitnessManagerDataSet.Bill);

            this.reportViewer1.RefreshReport();
        }
    }
}
