using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Example
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SQL sql;  //宣告全域變數SQL

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                sql = new SQL(User: userBox.Text, Pass: passBox.Text); //初始化SQL物件
                sql.Connect();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
