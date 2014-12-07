using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace 实验_数据库开发_一_
{
    class SQLHelper
    {
        private static string connectionString =
            Properties.Settings.Default.connectionStr;

        public static bool TestDBConnect()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int ExcuteNonQuery(
            string sql,
            params SqlParameter[] paramters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.AddRange(paramters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExcuteScalar(
            string sql,
            params SqlParameter[] paramters)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.AddRange(paramters);
                    return command.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(
            string sql,
            params SqlParameter[] paramters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(paramters);
            try
            {
                connection.Open();
                SqlDataReader myReader = command.ExecuteReader(
                    System.Data.CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally
            //{
            //    cmd.Dispose();
            //    connection.Close();
            //}	
        }
    }
}
