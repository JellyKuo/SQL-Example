using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 夢想之都管理程式
{
    /// <summary>
    /// 此Class負責提供Form，並確保Form在Hide後可以再次被呼叫
    /// </summary>
    class FormProvider
    {
        public static LoginForm LoginForm
        {
            get
            {
                if (_LoginForm == null)
                {
                    _LoginForm = new LoginForm();
                    _LoginForm.FormClosing += FormProvider.ExitApp;
                }
                return _LoginForm;
            }
        }

        private static LoginForm _LoginForm;

        public static MainForm MainForm
        {
            get
            {
                if (_MainForm == null)
                {
                    _MainForm = new MainForm();
                    _MainForm.FormClosing += FormProvider.ExitApp;
                }
                return _MainForm;
            }
        }
        private static MainForm _MainForm;

        private static void ExitApp(object sender, System.Windows.Forms.FormClosingEventArgs e)  //關閉應用程式
        {
            Console.WriteLine(((Form)sender).Name+"呼叫關閉! 嘗試登出SQL");
            SQL.Logout();
            Application.Exit();
        }
    }
}
