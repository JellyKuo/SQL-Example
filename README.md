# SQL-Example
提供基本SQL連線和操作的程式碼

## 基本介紹

 - `SQL.cs`
     - SQL連線與存取
 - `LoginForm.cs`
     - 登入介面，也是程式進入的第一個Form
 - `MainForm.cs`
     - 主介面，實作登出按鈕
 - `Crypto.cs`
     - 加密、解密字串用 (範例尚未用到)

## Class
###### SQL.cs

1. `Connect(string User, string Pass)`
     - 初始化連線，帶入使用者名稱和密碼
2. `GetConnectipnState`
     - 傳回連線狀態(string)
3. `Logout`
     - 登出並釋放連線以供再次登入
4. `ExecuteNonQuery(string cmdStr)` ** Async **
     - Async，傳回 `Task<int>`
     - 執行不回傳的SQL Query，傳回int代表受影響的資料行數
5. `ExecuteReadQuery(string cmdStr)` ** Async **
     - Async，傳回 `Task<SqlDataReader>`
     - 執行傳回的SQL Query，傳回SqlDataReader (WIP)
