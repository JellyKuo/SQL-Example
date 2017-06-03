using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//很重要，所有SQL打頭的都在這
using System.Data.SqlClient;
//除了這個Class，其他都不用using這個

namespace 夢想之都管理程式
{
    class SQL
    {
        /// <summary>
        /// 這裡控制與SQL伺服器的連線與操作
        /// </summary>

        protected static SqlConnection conn;  //基於安全原因，禁止除了此Class的方法存取SqlConnection
        public int UserID { get; set; }

        public SQL()  //初始化
        {
            if (conn == null)
                throw new Exception("SqlConnection未就緒!");
            var cmd = new SqlCommand("SELECT CURRENT_USER", conn);
            var UserReader = cmd.ExecuteReader();
            cmd.CommandText = "SELECT 使用者ID FROM 使用者資料 WHERE 帳號 = " + UserReader.GetString(1);
            var IDReader = cmd.ExecuteReader();
            this.UserID = IDReader.GetInt32(0);
        }

        public static void Connect(string User, string Pass)  //開始連線
        {
            string ConnStr;  //儲存連線參數
            string Server = "tcp:dreamcity.database.windows.net,1433";  //Server位置
            string Catalog = "夢想之都";  //DB Schema

            ConnStr = String.Format("Server={0};" +
                "Initial Catalog={1};" +  //初始Schema
                "Persist Security Info=False;" +  //不保存安全資訊
                "User ID={2};" +  //使用者ID
                "Password={3};" +  //使用者密碼
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;"  //連線逾時
                , Server, Catalog, User, Pass);  //製作連線參數

            conn = new SqlConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();  //開啟連線
            ConnStr = null;  //從記憶體釋放連線參數
        }

        public static string GetConnectionState()  //取得連線狀態
        {
            if (conn != null)
                return conn.State.ToString();
            else
                return null;
        }

        public static void Logout()  //登出
        {
            if (conn != null)
            {
                Console.WriteLine("Logging out");
                conn.Close();  //關閉連線
                conn.Dispose();  //釋放資源
            }
            else
                Console.WriteLine("User is not logged in");
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
            await reader.ReadAsync();
            return reader;
        }  //執行傳回的SQL Query

        public async Task<string> GetUserName()
        {
            SqlCommand cmd = new SqlCommand("SELECT 名稱 FROM 使用者資料 WHERE 使用者ID = " + UserID.ToString(), conn);
            var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            return reader.GetString(0);
        }
    }
}
