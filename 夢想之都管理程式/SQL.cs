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
        private int UserID { get; set; }

        public SQL()  //初始化
        {
            if (conn == null || SQL.GetConnectionState() == "Closed")
                throw new Exception("SqlConnection未就緒!");
            var cmd = new SqlCommand("SELECT CURRENT_USER", conn);
            var Reader = cmd.ExecuteReader();
            Reader.Read();
            cmd.CommandText = "SELECT 使用者ID FROM 使用者資料 WHERE 帳號 = '" + Reader.GetString(0) + "'";
            Reader.Close();
            Reader = cmd.ExecuteReader();
            Reader.Read();
            this.UserID = Reader.GetInt32(0);
            Reader.Close();
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
                "MultipleActiveResultSets=True;" +
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

        private Task<int> ExecuteNonQuery(string cmdStr)  //執行不回傳的SQL Query
        {
            if (conn == null)
                throw new Exception("SQL連線未建立!");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdStr;
            return cmd.ExecuteNonQueryAsync();
        }

        private async Task<SqlDataReader> ExecuteReadQuery(string cmdStr)
        {
            if (conn == null)
                throw new Exception("SQL連線未建立!");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdStr;
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            return reader;
        }  //執行傳回的SQL Query

        private SqlDataReader ExecuteNonAsyncReadQuery(string cmdStr)
        {
            if (conn == null)
                throw new Exception("SQL連線未建立!");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdStr;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }  //執行傳回的SQL Query

        public async Task<List<string>> GetUserData()
        {
            var Reader = await ExecuteReadQuery("SELECT * FROM 使用者資料 WHERE 使用者ID = " + UserID.ToString());
            var Data = new List<string>();
            await Reader.ReadAsync();
            Data.Add(Reader.GetString(2));
            var DepartmentID = Reader.GetInt32(3);
            var PermissionID = Reader.GetInt32(4);
            Reader.Close();
            Data.Add(await GetDepartmentName(DepartmentID));
            Data.Add(await GetPermissionName(PermissionID));
            return Data;
        }

        private async Task<string> GetDepartmentName(int id)
        {
            var Reader = await ExecuteReadQuery("SELECT 部門名稱 FROM 部門表 WHERE 部門ID = " + id.ToString());
            string DepartmentName = Reader.GetString(0);
            Reader.Close();
            return DepartmentName;
        }

        private async Task<string> GetPermissionName(int id)
        {
            var Reader = await ExecuteReadQuery("SELECT 權限名稱 FROM 權限表 WHERE 權限ID = " + id.ToString());
            await Reader.ReadAsync();
            string PermissionName = Reader.GetString(0);
            Reader.Close();
            return PermissionName;
        }

        public async Task<List<List<string>>> GetUrlData()
        {
            var Reader = await ExecuteReadQuery("SELECT * FROM 連結表");
            var Data = new List<List<string>>();
            int index = 0;
            while (Reader.Read())
            {
                if (!Reader.GetBoolean(3))
                {
                    var row = new List<string>();
                    row.Add(Reader.GetString(1));
                    row.Add(Reader.GetString(2));
                    Data.Add(row);
                    index += 1;
                }

            }

            Reader.Close();
            return Data;
        }
    }
}
