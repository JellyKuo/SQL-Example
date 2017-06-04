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

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetUserData();
        }

        private async void GetUserData()
        {
            var UserData = await sql.GetUserData();
            nameLabel.Text = UserData[0];
            departmentLabel.Text = UserData[1];
            permissionLabel.Text = UserData[2];
        } 
    }
}
