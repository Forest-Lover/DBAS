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
    public partial class SigninWindow : Form
    {
        DbConnection conn;
        MainWindow w;

        public SigninWindow(MainWindow w, DbConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.w = w;
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            Account a = new Account() { Name = tbName.Text, Password = tbPassword.Text, Type = 0 };
            if (a.Authenticated(conn))
            {
                w.CurrentAccount = new Account() { Name = tbName.Text, Password = tbPassword.Text, Type = 0 };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                labelTips.Text = "请重试！";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignupWindow(this, conn).ShowDialog();
        }
    }
}
