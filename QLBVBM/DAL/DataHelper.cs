
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace QLBVBM.DAL
{
    public class DataHelper
    {
        private string connectionString = "server=localhost;database=QLBVMBDB;user=root;password=user";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, List<MySqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public int ExecuteNonQuery(string query, List<MySqlParameter> parameters = null)
        {
            int affectedRows = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    affectedRows = cmd.ExecuteNonQuery();
                }
            }

            return affectedRows;
        }
    }
}
