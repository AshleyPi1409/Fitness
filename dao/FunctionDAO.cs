using Fitness.dto;
using Fitness.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dao
{
    class FunctionDAO
    {
        public readonly string READ_ALL = "SELECT * FROM Functions";
        public readonly string READ_BY_ID = "SELECT * FROM Functions WHERE ID = @id";
        public readonly string CREATE = "INSERT INTO Functions (functionName, description, active) VALUES(@name,@des,1)";
        public readonly string UPDATE = "UPDATE Functions SET functionName = @name, description = @des WHERE ID = @id";
        public readonly string DELETE = "UPDATE Functions SET active = 0 WHERE ID = @id ";



        public FunctionDAO()
        {


        }

        public List<Functions> getAll()
        {
            List<Functions> list = new List<Functions>();
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
                            list.Add(new Functions(reader.GetInt32(0) , reader.GetString(1),reader.GetString(2),reader.GetBoolean(3)));    

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
        public void create(Functions acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.funcName;
                cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = acc.description;


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

        public void delete(Functions acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = DELETE;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = acc.id;

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
        public void update(Functions acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;

          
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.funcName;
                cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = acc.description;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = acc.id;

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
    }
}
