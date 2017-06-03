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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)  //登出按鈕
        {
            try
            {
                SQL.Logout();  //登出
                if (SQL.GetConnectionState() != null)
                    throw new Exception("SQL isn't nulled properly!");  //SQL連線沒有被Null
                LoginForm lf = new LoginForm();  //傳回登入表單
                lf.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            SQL.Logout();  //登出
            if (SQL.GetConnectionState() != null)
                throw new Exception("SQL isn't nulled properly!");  //SQL連線沒有被Null
            Application.ExitThread();
        }
    }
}
