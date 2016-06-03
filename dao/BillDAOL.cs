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
    class BillDAOL
    {
        public static readonly string READ_ALL = "select a.id, b.fullname, b.address, b.phone, b.id, c.name, a.startday,a.paid from Booked a , Customer b, Course c where a.customer = b.ID and a.course = c.ID and a.paid = 0";
        public readonly string READ_BY_ID = "SELECT * FROM Bill WHERE ID = @id";
        public readonly string CREATE = "INSERT INTO Bill (staff, booked, date) VALUES(@staff,@booked,@day)";
        
        public readonly string DELETE = "DELETE FROM Bill  WHERE ID = @id ";

        public List<Bill> getAll()
        {
            List<Bill> list = new List<Bill>();
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

                            list.Add(new Bill(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(4)));

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

        public void create(Bill acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                
                cmd.Parameters.Add("@staff", SqlDbType.Int).Value = acc.staff;
                cmd.Parameters.Add("@booked", SqlDbType.Int).Value = acc.booked;
                cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = acc.date;
        



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

        public void delete(Bill acc)
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
        //public void update(Bill acc)
        //{
        //    SqlConnection con = Connector.getConnection();
        //    con.Open();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = UPDATE;

        //        cmd.Parameters.Add("@course", SqlDbType.Int).Value = acc.course;
        //        cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = acc.startDay;
        //        cmd.Parameters.Add("@paid", SqlDbType.Bit).Value = acc.paid;

        //        cmd.Parameters.Add("@id", SqlDbType.Int).Value = acc.id;

        //        int rowCount = cmd.ExecuteNonQuery();
        //        Console.WriteLine("Row Count affected = " + rowCount);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("khong the ket noi");
        //        Console.WriteLine(e.StackTrace);
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //        con = null;
        //    }

        //}
    }
}
