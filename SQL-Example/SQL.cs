using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; //很重要，所有SQL打頭的都在這


namespace SQL_Example
{
    class SQL
    {
        private string ConnStr;  //儲存連線參數
        private SqlConnection conn;  //不允許應用程式直接接觸連線

        public SQL(string User,string Pass,bool ConnectNow)  //初始化
        {
            string Server = "tcp:jellykuo.database.windows.net,1433";  //Server位置
            string Catalog = "TestDB";  //DB Schema

            ConnStr = String.Format("Server={0};" +
                "Initial Catalog={1};" +  //初始Schema
                "Persist Security Info=False;" +  //不保存安全資訊
                "User ID={2};" +  //使用者ID
                "Password={3};" +  //使用者密碼
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;"  //連線逾時
                , Server, Catalog,User,Pass);  //製作連線參數
            if (ConnectNow)
                Connect();
        }

        public async void Connect()  //開始連線
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnStr;
                await conn.OpenAsync();  //Async開啟連線
                
                ConnStr = null;  //從記憶體釋放連線參數
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Task<int> ExecuteNonQuery(string cmdStr)  //執行不回傳的SQL Query
        {
            if (conn == null)
                throw new Exception("SQL連線未建立!");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdStr;
            return cmd.ExecuteNonQueryAsync();
        }

        public async Task<SqlDataReader> ExecuteReadQuery(string cmdStr)
        {
            if (conn == null)
                throw new Exception("SQL連線未建立!");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdStr;
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            return reader;
        }  //執行傳回的SQL Query
    }
}
