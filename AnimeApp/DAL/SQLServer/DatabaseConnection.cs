using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.SQLServer
{
    public class DatabaseConnection
    {
        private static string connectionString = @"Data Source=DUXINH;Initial Catalog=AnimeDB;User ID=sa;Password=123";

        public static SqlConnection KetNoi()
        {
            return new SqlConnection(connectionString);
        }

        public static void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = KetNoi())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }

            }
        }
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = KetNoi())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    } 
}
