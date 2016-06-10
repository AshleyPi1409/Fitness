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
    class RoleFuncDAO
    {
        public static readonly string READ_ALL = "SELECT * FROM Role_Func";
        public readonly string READ_BY_ID = "SELECT * FROM Role_Func WHERE idrole = @id";
        public readonly string CREATE = "INSERT INTO Role_Func (idRole, idfunc) VALUES(@role,@func)";
        public readonly string UPDATE = "UPDATE Role_Func SET active=@active WHERE idrole = @role AND idfunc = @func";
        public readonly string DELETE = "DELETE FROM Role_Func  WHERE IDrole = @role AND idfunc = @func";


        public List<RoleFunc> getAll()
        {
            List<RoleFunc> list = new List<RoleFunc>();
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
                            list.Add(new RoleFunc(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetBoolean(3)));

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

        public List<RoleFunc> getAllByIDRole(int id)
        {
            List<RoleFunc> list = new List<RoleFunc>();
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = READ_BY_ID;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new RoleFunc(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetBoolean(3)));

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

        public void create(RoleFunc acc)
        {
            SqlConnection con = null;
            con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = CREATE;


                cmd.Parameters.Add("@role", SqlDbType.NVarChar).Value = acc.roleID;
                cmd.Parameters.Add("@func", SqlDbType.Decimal).Value = acc.funcID;
    

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

        public void delete(RoleFunc acc)
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
        public void update(int role, int func,int act)
        {
            SqlConnection con = Connector.getConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = UPDATE;


                cmd.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
                cmd.Parameters.Add("@func", SqlDbType.Decimal).Value = func;
                cmd.Parameters.Add("@active", SqlDbType.Decimal).Value = act;


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
