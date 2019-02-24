using DBAS.Classes;
using DBAS.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS
{
    public partial class MainWindow : Form
    {
        public DbConnection conn { get; set; }
        public Account CurrentAccount { get; set; }
        private download d;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Server=localhost; Database=DBAS; Integrated Security=true";
                conn.Open();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + "\r\n是否继续？", "数据访问错误", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.Close();
                }
            }

            SigninWindow win = new SigninWindow(this,conn);
            if (win.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            NavTreeTool.RefreshByDbConnection(treeView1, CMSTreeNode, conn);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void 打开CMSTreeNode_Click(object sender, EventArgs e)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = String.Format("SELECT TOP 1000 * from {0}", treeView1.SelectedNode.Text);
            textBox1.Text = cmd.CommandText;
            DbDataReader reader = cmd.ExecuteReader();
            ListViewTool.RefreshByDbDataReader(listView1, reader);
            reader.Close();
        }

        private void 删除CMSTreeNode_Click(object sender, EventArgs e)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = String.Format("DROP TABLE {0}", treeView1.SelectedNode.Text);
            textBox1.Text = cmd.CommandText;
            cmd.ExecuteNonQuery();
            刷新CMSTree_Click(sender,e);
        }

        private void 清空该表CMSTreeNode_Click(object sender, EventArgs e)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = String.Format("DELETE FROM {0}", treeView1.SelectedNode.Text);
            textBox1.Text = cmd.CommandText;
            cmd.ExecuteNonQuery();
        }

        private void 刷新CMSTree_Click(object sender, EventArgs e)
        {
            NavTreeTool.RefreshByDbConnection(treeView1, CMSTreeNode, conn);
            //treeView1.TopNode.Expand();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.TopNode.IsSelected)
                return;
            else
                打开CMSTreeNode_Click(sender, e);
        }

        private void 主邻小区C2I干扰分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C2IPanel C2I = new C2IPanel(this);
            C2I.Show();
            C2I.Init();
        }

        private void 查询重叠覆盖干扰三元组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C2I3Panel C2I3 = new C2I3Panel(this);
            C2I3.Show();
            C2I3.Init();
        }

        private void 数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            import im = new import();
            im.Show();
        }

        private void 数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////定义sql连接
            //SqlConnectionStringBuilder sqlconStringBuilder = new SqlConnectionStringBuilder();
            ////sql连接字串
            //sqlconStringBuilder.ConnectionString = @"Data Source=(local);Initial Catalog=DBAS;Integrated Security=True";
            ////定义语句计算选定sheet中数据的行数
            string strSql = string.Format("select name from sys.tables");
            //using (SqlConnection conn = new SqlConnection(sqlconStringBuilder.ConnectionString))
            //{

            //}
            SqlDataReader reader = null;
            List<string> list = new List<string>();
            try
            {
                //conn.Open();
                SqlCommand sqlCommand = new SqlCommand(strSql, conn as SqlConnection);//执行查询，返回查询结果
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                //MessageBox.Show(list.LongCount().ToString());
                download d = new download(list);
                d.Show();
                //conn.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ////定义sql连接
            //SqlConnectionStringBuilder sqlconStringBuilder = new SqlConnectionStringBuilder();
            ////sql连接字串
            //sqlconStringBuilder.ConnectionString = @"Data Source=(local);Initial Catalog=DBAS;Integrated Security=True";
            ////定义语句计算选定sheet中数据的行数
            //string strSql = string.Format("select name from sys.tables");
            //using (SqlConnection conn = new SqlConnection(sqlconStringBuilder.ConnectionString))
            //{
            //    SqlDataReader reader = null;
            //    List<string> list = new List<string>();
            //    try
            //    {
            //        conn.Open();
            //        SqlCommand sqlCommand = new SqlCommand(strSql, conn);//执行查询，返回查询结果
            //        reader = sqlCommand.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            list.Add(reader.GetString(0));
            //        }
            //        //MessageBox.Show(list.LongCount().ToString());
            //        d = new download(list);
            //        d.Show();
            //        conn.Close();
            //        reader.Close();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void tbCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbCell_research form1 = new tbCell_research();
            form1.Show();
        }

        private void tbKPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbKPI_research form2 = new tbKPI_research();
            form2.Show();
        }

        private void tbPRBnewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbPRB_research form3 = new tbPRB_research();
            form3.Show();
        }

        private void tbC2InewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbC2I_research form4 = new tbC2I_research();
            form4.Show();
        }
    }
}
