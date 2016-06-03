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
    class BookedDAO
    {
        public static readonly string SPECIAL = "select a.id, b.fullname, c.name, a.startday,a.paid from Booked a , Customer b, Course c where a.customer = b.ID and a.course = c.ID ";
        public static readonly string READ_ALL = "SELECT * FROM Booked";
        public readonly string READ_BY_ID = "SELECT * FROM Booked WHERE ID = @id";
        public readonly string CREATE = "INSERT INTO Booked (customer, staff, course, startday,paid) VALUES(@cus,@staff,@course,@day,@paid)";
        public readonly string UPDATE = "UPDATE Booked SET course = @course, startday = @day, paid = @paid WHERE ID = @id";
        public readonly string DELETE = "DELETE FROM Booked  WHERE ID = @id ";
        public readonly string PAID = "UPDATE Booked SET paid = 1 WHERE ID = @id";
       

        public List<Booked> getAll()
        {
            List<Booked> list = new List<Booked>();
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
                            
                           list.Add(new Booked(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),reader.GetDateTime(4),reader.GetBoolean(5)));

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

        public void create(Booked acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@cus", SqlDbType.Int).Value = acc.customer;
                cmd.Parameters.Add("@staff", SqlDbType.Int).Value = acc.staff;
                cmd.Parameters.Add("@course", SqlDbType.Int).Value = acc.course;
                cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = acc.startDay;
                cmd.Parameters.Add("@paid", SqlDbType.Bit).Value = acc.paid;



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

        public void delete(Booked acc)
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
        public void paid(int id)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = PAID;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("PAIDED = " + rowCount);
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
        public void update(Booked acc)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;

                cmd.Parameters.Add("@course", SqlDbType.Int).Value = acc.course;
                cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = acc.startDay;
                cmd.Parameters.Add("@paid", SqlDbType.Bit).Value = acc.paid;

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
