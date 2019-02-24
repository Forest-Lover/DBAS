using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.UI
{
    public partial class import : Form
    {
        private OpenFileDialog f1;         // 文件路径选择文本框
        private string strSourcePath;     // 保存文件路径的字符串
        public import()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1 = new OpenFileDialog();
            if (f1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = f1.FileName.ToString();
                strSourcePath = this.textBox1.Text;//记录文件路径在字符串变量之中
                object missing = Missing.Value;
                string path = f1.FileName.ToString();
                string strConn;
                strConn = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable
                (System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                conn.Close();
                foreach (DataRow dr in sheetNames.Rows)
                {
                    comboBox1.Items.Add(dr[2].ToString().Replace("$", ""));
                }
                this.Show();
                //定义sql连接
                SqlConnectionStringBuilder sqlconStringBuilder = new SqlConnectionStringBuilder();
                //sql连接字串
                sqlconStringBuilder.ConnectionString = @"Data Source=(local);Initial Catalog=DBAS;Integrated Security=True";
                string strSql = string.Format("select name from sys.tables");
                using (SqlConnection conn1 = new SqlConnection(sqlconStringBuilder.ConnectionString))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        conn1.Open();
                        SqlCommand sqlCommand = new SqlCommand(strSql, conn1);//执行查询，返回查询结果
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add((reader.GetString(0)));
                        }
                        //MessageBox.Show(list.LongCount().ToString());
                        conn1.Close();
                        reader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("未选择文件路径");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            //MessageBox.Show(e.RowsCopied.ToString());
            progressBar1.PerformStep();
            progressBar1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //导入函数
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请选择导入文件路径");
                return;
            }
            //定义sql连接
            SqlConnectionStringBuilder sqlconStringBuilder = new SqlConnectionStringBuilder();
            //sql连接字串
            sqlconStringBuilder.ConnectionString = @"Data Source=(local);Initial Catalog=DBAS;Integrated Security=True";
            //定义excel路径
            string path = f1.FileName.ToString();
            //定义excel连接
            OleDbConnectionStringBuilder excelStringBuilder = new OleDbConnectionStringBuilder();
            //excel连接字串
            excelStringBuilder.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties= 'Excel 12.0;HDR=YES;IMEX=1'";


            //建立excel连接
            using (OleDbConnection con_excel = new OleDbConnection(excelStringBuilder.ConnectionString))
            {
                //打开excel文件
                con_excel.Open();
                //定义语句计算选定sheet中数据的行数
                string strSql = string.Format("SELECT COUNT(*) FROM [{0}$]", comboBox1.SelectedItem.ToString());
                //MessageBox.Show(strSql);
                //执行查询语句
                OleDbCommand cmdSourceRowCount = new OleDbCommand(strSql, con_excel);
                //建立数据库连接
                using (SqlConnection con_bulkcopy = new SqlConnection(sqlconStringBuilder.ConnectionString))
                {
                    //打开数据库
                    con_bulkcopy.Open();
                    //定义语句计算表中的数据行数
                    strSql = string.Format("SELECT COUNT(*) FROM {0}", comboBox1.SelectedItem.ToString());
                    //执行查询语句
                    SqlCommand cmdRowCount = new SqlCommand(strSql, con_bulkcopy);
                    //定义超时
                    cmdRowCount.CommandTimeout = 3600;
                    //定义语句提取选定sheet中数据
                    strSql = string.Format("SELECT * FROM [{0}$]", comboBox1.SelectedItem.ToString());
                    //提取语句
                    OleDbCommand cmdSourceData = new OleDbCommand(strSql, con_excel);
                    //定义超时
                    cmdSourceData.CommandTimeout = 3600;

                    SqlBulkCopyOptions options = SqlBulkCopyOptions.FireTriggers;
                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = Convert.ToInt32(cmdSourceRowCount.ExecuteScalar().ToString());

                    //MessageBox.Show(progressBar1.Maximum.ToString());
                    if (progressBar1.Maximum <= 1000)
                    {
                        progressBar1.Value = 100;
                        progressBar1.Step = 100;
                    }
                    else
                    {
                        progressBar1.Value = 1000;
                        progressBar1.Step = 1000;
                    }

                    //建立数据集
                    using (OleDbDataReader excelReader = cmdSourceData.ExecuteReader())
                    {
                        //建立块拷贝
                        using (SqlBulkCopy bcp = new SqlBulkCopy(sqlconStringBuilder.ConnectionString, options))
                        {
                            //以1000记录为单位
                            bcp.BatchSize = progressBar1.Value;
                            //设定超时
                            bcp.BulkCopyTimeout = 500000000;
                            //设定通知事件前处理的数据行数
                            bcp.NotifyAfter = progressBar1.Value;
                            bcp.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
                            //指定目标数据库表名
                            bcp.DestinationTableName = comboBox2.SelectedItem.ToString();//数据库表名与excel表sheet名应该一致
                            //导入
                            bcp.WriteToServer(excelReader);
                        }
                        //关闭数据集
                        excelReader.Close();
                    }
                    //关闭数据库连接
                    con_bulkcopy.Close();
                }
                //关闭excel文件
                con_excel.Close();
            }
            //弹窗导入完成
            MessageBox.Show("导入成功");
        }
    }
}
