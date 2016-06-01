using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Fitness.utils;
using System.Data.Common;
using Fitness.dto;
using System.Data;

namespace Fitness.dao
{
    class AccountDAO
    {


        public static readonly string READ_ALL = "SELECT * FROM Accounts";
        public static readonly string READ_BY_ID = "SELECT * FROM Accounts WHERE ID = @id";
        public static readonly string CREATE = "INSERT INTO Accounts (accountName, password, fullName, roleID,active) VALUES(@account,@pass,@name,@roleID,1)";
        public static readonly string UPDATE = "UPDATE Accounts SET accountName = @account, password = @pass, fullName = @name, roleID = @roleID , active=1 WHERE ID = @id";
        public static readonly string DELETE = "DELETE FROM Accounts  WHERE ID = @id ";
        public static readonly string REACTIVE = "UPDATE Accounts SET active = 1 WHERE ID = @id ";


        public AccountDAO()
        {


        }

        public List<Accounts> getAll()
        {
            List<Accounts> list = new List<Accounts>();
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();  
            
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = READ_ALL;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Accounts(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetInt32(4),reader.GetBoolean(5)));

                        }
                    }
                }
            
            }
            catch(Exception e)
            {
                Console.WriteLine("khong the ket noi");
                Console.WriteLine(e.StackTrace);
            }
            finally
           
            {                
                con.Close();
                con.Dispose();
                con = null;
                
            }
                return list;
        }

        public Accounts getAllByAccount(String acc)
        {
            List<Accounts> list = getAll();
            foreach (Accounts a in list)
            {
                if (a.accountName.Equals(acc))
                {
                    return a;
                }
            }
            return null;
        }

        public void create(Accounts acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@account", SqlDbType.NVarChar).Value = acc.accountName;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = acc.passWord;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.fullName;
                cmd.Parameters.Add("@roleID", SqlDbType.Int).Value = acc.role;
               

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("khong the ket noi");
                Console.WriteLine(e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
                con = null;

            }
        }

        public Accounts findByAccName(String name)
        {
            foreach (Accounts a in getAll())
            {
                if (a.accountName.Equals(name)) return a;
            }
            return null;
        }

        public void delete(int id)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = DELETE;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("khong the ket noi");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
                con = null;

            }
        }
        public void reactive(int id)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = REACTIVE;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("khong the ket noi");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
                con = null;

            }
        }
        public void update(Accounts acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;

                cmd.Parameters.Add("@account", SqlDbType.NVarChar).Value = acc.accountName;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = acc.passWord;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.fullName;
                cmd.Parameters.Add("@roleID", SqlDbType.Int).Value = acc.role;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = acc.id;

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("khong the ket noi");
                Console.WriteLine(e);   
            }
            finally
            {
                con.Close();
                con.Dispose();
                con = null;
            }
                
        }
    }
}
