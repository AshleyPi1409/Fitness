using Fitness.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness.utils
{
    class GetSource
    {
        public static void getTableSource(String statement,DataGridView dgv)
        {
            SqlConnection connection;
            SqlDataAdapter adapter;
            DataTable ds = new DataTable();


            connection = Connector.getConnection();
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(statement, connection);
                adapter.Fill(ds);
                dgv.DataSource = ds;
                dgv.AllowUserToAddRows = false;
              
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 

        }

        public static void getTableSourceFromList<T>(List<T> l,DataGridView dgv)
        {
            BindingSource Source = new BindingSource();

            for (int i = 0; i < l.Count; i++)
            {
                Source.Add(l.ElementAt(i));
            };

            dgv.DataSource = Source;
        }

        public static void getComboxSource(String statement,ComboBox cbb,String text)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            string strCmd = statement;
            SqlCommand cmd = new SqlCommand(strCmd, con);

            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cbb.DataSource = ds.Tables[0];
            cbb.DisplayMember = text;
            cbb.ValueMember = "ID";
            cbb.Enabled = true;
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
