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
    class DiaryDAO
    {
        public static readonly string READ_ALL = "SELECT * FROM Diary";
        public static readonly string CREATE = "INSERT INTO Diary (account, date, description) VALUES (@acc, @day, @des)";
        public List<Diary> getAll()
        {
            List<Diary> list = new List<Diary>();
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
                            list.Add(new Diary(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3)));

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

        public void create(Diary acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;

                cmd.Parameters.Add("@acc", SqlDbType.Int).Value = acc.account;
                cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = acc.date;
                cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = acc.description;
              

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

    }
}
