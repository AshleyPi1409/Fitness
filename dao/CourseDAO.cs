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
    class CourseDAO
    {
        public static readonly string READ_ALL = "SELECT * FROM Course";
        public static readonly string READ_BY_ID = "SELECT * FROM Course WHERE ID = @id";
        public static readonly string CREATE = "INSERT INTO Course (name, months, price, idtype, active) VALUES(@name,@month,@price,@type,true)";
        public static readonly string UPDATE = "UPDATE Course SET name = @name,months = @month, price = @price,idtype = @type WHERE ID = @id";
        public static readonly string DELETE = "UPDATE Course SET active = false WHERE ID = @id ";

        public List<Course> getAll()
        {
            List<Course> list = new List<Course>();
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
                            list.Add(new Course(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4),  reader.GetBoolean(5)));

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

        public void create(Course acc)
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
                cmd.Parameters.Add("@month", SqlDbType.Decimal).Value = acc.months;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = acc.price;
                cmd.Parameters.Add("@type", SqlDbType.Int).Value = acc.type;

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

        public void delete(Course acc)
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
        public void update(Course acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;

             
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acc.name;
                cmd.Parameters.Add("@month", SqlDbType.Decimal).Value = acc.months;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = acc.price;
                cmd.Parameters.Add("@type", SqlDbType.Int).Value = acc.type;

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
