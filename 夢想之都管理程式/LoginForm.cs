using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 夢想之都管理程式
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
#if DEBUG
            Console.WriteLine("Debug組態");
            Debug();
#else
            Console.WriteLine("Release組態");
#endif
        }

        [Conditional("DEBUG")]
        private void Debug()
        {
            loginButton.Size = new Size(140, 30);
            Button DebugButton = new Button()
            {
                Size = new Size(140, 30),
                Location = new Point(loginButton.Location.X+150,loginButton.Location.Y),
                Name = "DebugButton",
                Text = "DEBUG",
                BackColor = Color.Pink
            };
            DebugButton.Click += (sender, e) =>
            {
                SQL.Connect("TestClient", "P@ssw0rd");
                FormProvider.MainForm.Show();
                this.Hide();
            };
            this.Controls.Add(DebugButton);
        }  //Debug方便登入用

        private void 測試網路連線ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        MessageBox.Show("網路連線看似正常", "測試網路連線", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("網路連線有點問題喔", "測試網路連線", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            ToggleControl(false);
            try
            {
                SQL.Connect(userBox.Text, passBox.Text);

                for (int i = 0; i < 3; i++)  //檢查連線狀態3次
                {
                    if (SQL.GetConnectionState() == "Open")
                    {
                        Console.WriteLine("連線成功! " + SQL.GetConnectionState() + ", 狀態檢查次數: " + i.ToString());
                        ToggleControl(true);
                        FormProvider.MainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        Console.WriteLine("連線狀態: " + SQL.GetConnectionState() + ", 目前次數: " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "錯誤!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleControl(true);
            }

        }

        private void ToggleControl(bool State)
        {
            userBox.Enabled = State;
            passBox.Enabled = State;
            loginButton.Enabled = State;
        }
    }
}
