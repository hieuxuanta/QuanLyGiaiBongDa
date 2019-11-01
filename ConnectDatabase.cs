using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiGiaiBongDa
{
    public class ConnectDatabase
    {
        string strConnect = @"Data Source=DESKTOP-4NUB104\SQLEXPRESS;Initial Catalog=QLGiaiBongDa;Integrated Security=True";
        SqlConnection sqlConnection;

        private void ConnectData()
        {
            sqlConnection = new SqlConnection(strConnect);
            if(sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        private void CloseData()
        {
            if(sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public DataTable LoadData(string sql)
        {
            DataTable dt = new DataTable();
            ConnectData();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dt);
            CloseData();
            return dt;
        }

        public void UpdateData(string sql)
        {
            ConnectData();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            CloseData();
        }
    }
}
