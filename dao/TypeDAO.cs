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
    class TypeDAO
    {
        public static readonly string READ_ALL = "SELECT * FROM Type";
        public readonly string READ_BY_ID = "SELECT * FROM Type WHERE ID = @id";
        public readonly string CREATE = "INSERT INTO Type (name, description,active) VALUES(@name,@des,1)";
        public readonly string UPDATE = "UPDATE Type SET name = @name, description = @des WHERE ID = @id";
        public readonly string DELETE = "UPDATE Type SET active=0 WHERE ID = @id ";

        public List<Type> getAll()
        {
            List<Type> list = new List<Type>();
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
                            list.Add(new Type(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3)));

                        }
                    }
                }

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
            return list;
        }
        public void create(Type acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.name;
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

        public void delete(Type acc)
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
        public void update(Type acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;


                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.name;
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
