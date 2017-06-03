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

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Logging in");
                SQL.Connect(userBox.Text,passBox.Text);
                if (SQL.GetConnectionState() == "Open")
                    LoggedIn();  //登入成功
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoggedIn()
        {
            Console.WriteLine("Logged In!");
            MainForm mf = new MainForm();  //顯示主介面表單
            mf.Show();
            this.Hide();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
