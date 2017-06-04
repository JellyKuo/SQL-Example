using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 夢想之都管理程式
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        SQL sql = new SQL();

        #region MenuStrip

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SQL.Logout();
            this.Dispose();
            FormProvider.LoginForm.Show();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProvider.ExitApp(null, null);
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

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
        Label[] labelArray;

        private async void GetUrlData()
        {
            var UrlData = await sql.GetUrlData();
        }

        private void RenderUrlData()
        {

        }
    }
}
