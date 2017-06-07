using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 夢想之都管理程式
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 應用程式的主畫面
        /// </summary>

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            Console.WriteLine("Debug組態, LoginForm載入Debug快速登入");
            Debug();
#endif
        }

        SQL sql = new SQL();
        Panel[] UrlPanel;
        Label[] UrlNameLabel;
        Button[] UrlButton;

        #region MenuStrip

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SQL.Logout();
            this.Dispose();
            FormProvider.LoginForm.Show();
        }

        private void 重新整理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProvider.ExitApp("結束ToolStripMenuItem", null);
        }

        #endregion

        [Conditional("DEBUG")]
        private void Debug()
        {
            ToolStripMenuItem DebugToolStripItem = new ToolStripMenuItem()
            {
                Name = "DebugToolStripItem",
                Text = "Debug",
                BackColor = Color.Pink
            };
            ToolStripMenuItem RefreshDataToolStripItem = new ToolStripMenuItem()
            {
                Name = "RefreshDataToolStripItem",
                Text = "RefreshData()"
            };
            RefreshDataToolStripItem.Click += (sender, e) => RefreshData(); ;
            ToolStripMenuItem GetUserDataToolStripItem = new ToolStripMenuItem()
            {
                Name = "GetUserDataToolStripItem",
                Text = "GetUserData()"
            };
            GetUserDataToolStripItem.Click += (sender, e) => GetUserData(); ;
            ToolStripMenuItem GetUrlDataToolStripItem = new ToolStripMenuItem()
            {
                Name = "GetUrlDataToolStripItem",
                Text = "GetUrlData()"
            };
            GetUrlDataToolStripItem.Click += (sender, e) => GetUrlData(); ;
            ToolStripMenuItem Test = new ToolStripMenuItem()
            {
                Name = "Test",
                Text = "Test()"
            };
            Test.Click += (sender, e) =>
            {
                UrlPanel = new Panel[3];
                UrlNameLabel = new Label[3];
                UrlButton = new Button[3];
                int pY = 30;
                for (int i = 0; i < 3; i++)
                {
                    UrlPanel[i] = new Panel()
                    {
                        Name = "UrlPanel" + i.ToString(),
                        Size = new Size(285, 50),
                        Location = new Point(8, pY),
                        BackColor = Color.LightBlue
                    };
                    UrlNameLabel[i] = new Label()
                    {
                        Name = "UrlNameLabel" + i.ToString(),
                        Text = i.ToString()
                    };
                    UrlPanel[i].Controls.Add(UrlNameLabel[i]);
                    urlBox.Controls.Add(UrlPanel[i]);
                }
            };


            DebugToolStripItem.DropDownItems.Add(Test);
            DebugToolStripItem.DropDownItems.Add(RefreshDataToolStripItem);
            DebugToolStripItem.DropDownItems.Add(GetUserDataToolStripItem);
            DebugToolStripItem.DropDownItems.Add(GetUrlDataToolStripItem);
            menuStrip1.Items.Add(DebugToolStripItem);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("Debug組態, 自動擷取資料已停用");
#else
            RefreshData();
#endif
        }  //自動取得資料

        private void RefreshData()
        {
            GetUserData();
            GetUrlData();
        }

        private async void GetUserData()
        {
            var UserData = await sql.GetUserData();
            nameLabel.Text = UserData[0];
            departmentLabel.Text = UserData[1];
            permissionLabel.Text = UserData[2];
        }

        private async void GetUrlData()
        {
            var UrlData = await sql.GetUrlData();

            UrlPanel = new Panel[UrlData.Count];
            UrlNameLabel = new Label[UrlData.Count];
            UrlButton = new Button[UrlData.Count];
            int pY = 0;
            for (int i = 0; i < UrlData.Count; i++)
            {
                UrlPanel[i] = new Panel()
                {
                    Name = "UrlPanel" + i.ToString(),
                    Size = new Size(285, 50),
                    Location = new Point(8, pY),
                    BackColor = Color.LightBlue
                };
                pY += 50;
                UrlNameLabel[i] = new Label()
                {
                    Name = "UrlNameLabel" + i.ToString(),
                    Text = UrlData[i][0],
                    AutoSize = false,
                    Dock = DockStyle.Left,
                    TextAlign = ContentAlignment.MiddleLeft,
                };
                UrlButton[i] = new Button()
                {
                    Name = "UrlButton" + i.ToString(),
                    Text = "前往",
                    Size = new Size(100,42),
                    Location = new Point(180,3),
                    Anchor = AnchorStyles.Right,
                    Tag = UrlData[i][1]
                };
                UrlButton[i].Click += (sender, e) =>
                {
                    var SendButton = sender as Button;
                    System.Diagnostics.Process.Start(SendButton.Tag as string);
                };

                UrlPanel[i].Controls.Add(UrlNameLabel[i]);
                UrlPanel[i].Controls.Add(UrlButton[i]);
                urlBoxPanel.Controls.Add(UrlPanel[i]);
            }


        }
    }
}