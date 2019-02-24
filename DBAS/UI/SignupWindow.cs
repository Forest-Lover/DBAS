using DBAS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.UI
{
    public partial class SignupWindow : Form
    {
        private DbConnection conn;
        private SigninWindow w;

        public SignupWindow(SigninWindow w, DbConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.w = w;
        }

        private void SignupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            w.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Account a = new Account() { Name = tbName.Text, Password = tbPassword.Text, Type = 0 };
            switch (a.Registe(conn))
            {
                case Account.RegistryResult.OK:
                    labelTips.Text = "注册成功！";
                    break;
                case Account.RegistryResult.NAME_EXISTED:
                    labelTips.Text = "用户名已存在！";
                    break;
                case Account.RegistryResult.PWD_FORMATE_WRONG:
                    labelTips.Text = "密码最少需要5位！";
                    break;
                default:
                    break;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
