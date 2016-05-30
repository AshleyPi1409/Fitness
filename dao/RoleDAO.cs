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
    class RoleDAO
    {
        
        public static readonly string READ_ALL = "SELECT * FROM Roles";
        
        public readonly string READ_BY_ID = "SELECT * FROM Roles WHERE ID = @id";
        public readonly string CREATE = "INSERT INTO Roles (roleName, description,active) VALUES(@name,@des,true)";
        public readonly string UPDATE = "UPDATE Roles SET roleName = @name, description = @des WHERE ID = @id";
        public readonly string DELETE = "UPDATE Roles SET active=false WHERE ID = @id ";



        public RoleDAO()
        {


        }

        public List<Roles> getAll()
        {
            List<Roles> list = new List<Roles>();
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
                            list.Add(new Roles(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetBoolean(3)));    

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
        public void create(Roles acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.roleName;
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

        public void delete(Roles acc)
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
        public void update(Roles acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;


                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.roleName;
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
        public String getRoleName(int id)
        {
            foreach(Roles r in getAll()){
                if (r.id == id) return r.roleName;
            }
            return null;
        }
    }
}
