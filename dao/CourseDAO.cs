﻿using Fitness.dto;
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
        public static readonly string READ_BY_ID = "SELECT * FROM Course WHERE idtype = @id";
        public static readonly string READ_BY_ID_IF_ACTIVE = "SELECT * FROM Course WHERE idtype = @id AND active=1";
        public static readonly string CREATE = "INSERT INTO Course (name, months, price, idtype, active) VALUES(@name,@month,@price,@type,1)";
        public static readonly string UPDATE = "UPDATE Course SET name = @name,months = @month, price = @price,idtype = @type WHERE ID = @id";
        public static readonly string DELETE = "UPDATE Course SET active = 0 WHERE ID = @id ";
        public static readonly string REACTIVE = "UPDATE Course SET active = 1 WHERE ID = @id ";

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
                            list.Add(new Course(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetBoolean(5)));

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
        public List<Course> getAllByTypeID(int id)
        {
            List<Course> list = new List<Course>();
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = READ_BY_ID;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Course(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetBoolean(5)));

                        }
                    }
                }

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
            return list;
        }
        public List<Course> getAllByTypeID(int id,bool b)
        {
            if (b)
            {
                List<Course> list = new List<Course>();
                SqlConnection con = null;
                con = Connector.getConnection();
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = READ_BY_ID_IF_ACTIVE;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new Course(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetBoolean(5)));

                            }
                        }
                    }

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
                return list;
            }
            else return null;
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
