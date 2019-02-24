using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBAS.UI
{
    public partial class tbKPI_research : Form
    {
        public tbKPI_research()
        {
            InitializeComponent();
            this.Load += new EventHandler(tbKPI_research_Load);
        }

        private void tbKPI_research_Load(object sender, EventArgs e)
        {
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
            //打开连接
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //将sql语句交给cmd对象

            cmd.CommandText = "select distinct NE_Name from tbKPI order by NE_Name";
            //用cmd的函数执行语句，返回SqlDataReader对象result,result是数据库中的查询结果
            SqlDataReader result = cmd.ExecuteReader();
            //用Read函数，每执行一次，返回一个包含下一行数据的集合

            while (result.Read())
            {
                this.comboBox1.Items.Add(result[0].ToString());
            }
            result.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的网元");
                return;
            }

            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的属性");
                return;
            }

            else
            {
                //每次查询之前先清空之前查询的表
                chart1.Series[0].Points.Clear();
                //接收两个下拉列表的选择
                string select1 = comboBox1.SelectedItem.ToString();
                string select2 = comboBox2.SelectedItem.ToString();
                string date1 = dateTimePicker1.Text.ToString();
                string date2 = dateTimePicker2.Text.ToString();

                string time1 = date1 + " 00:00:00";
                string time2 = date2 + " 00:00:00";

                if (time1.CompareTo(time2) == 1)           //起始时间选在结束时间之后，需重新选择
                {
                    MessageBox.Show("起始时间必须在结束时间之前");
                }

                else
                {
                    //创建数据库连接类的对象
                    SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                    //打开连接
                    con.Open();
                    //执行con对象的函数，返回一个SqlCommand类型的对象
                    SqlCommand cmd = con.CreateCommand();
                    //将sql语句交给cmd对象
                    cmd.CommandText = "select round(avg(" + select2 + "),1),Start_Time " +
                                      "from tbKPI where NE_Name = '" + select1 + "' " +
                                      "and Start_Time between '" + time1 + "' and  '" + time2 + "' " +
                                      "group by Start_Time";

                    //用cmd的函数执行语句，返回SqlDataReader对象result,result是数据库中的查询结果
                    SqlDataReader result = cmd.ExecuteReader();
                    //用Read函数，每执行一次，返回一个包含下一行数据的集合

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    // 线的颜色为红色
                    chart1.Series[0].Color = Color.Red;
                    //线条粗细
                    chart1.Series[0].BorderWidth = 2;

                    while (result.Read())
                    {
                        // 添加数据
                        chart1.Series[0].Points.AddXY(result[1].ToString(), result[0].ToString());
                        chart1.Series[0].ToolTip = "当前" + select2 + "值：#VAL";
                    }

                    // 隐藏图示
                    chart1.Legends[0].Enabled = false;

                    result.Close();
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null)
            {
                MessageBox.Show("查询条件为空");
            }
            else
            {
                string select1 = comboBox1.SelectedItem.ToString();
                string select2 = comboBox2.SelectedItem.ToString();
                FolderBrowserDialog fb = new FolderBrowserDialog();
                string filePath = null;
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    filePath = fb.SelectedPath;
                }
                if (filePath != null)
                {
                    chart1.SaveImage(filePath + "/表tbKPI网元" + select1 + " " + select2 + "值变化情况.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("导出成功");
                }
                else
                {
                    chart1.SaveImage("D:/表tbKPI网元" + select1 + " " + select2 + "值变化情况.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("导出成功");
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void tbKPI_research_Load_1(object sender, EventArgs e)
        {

        }
    }
}
