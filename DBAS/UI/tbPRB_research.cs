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
    public partial class tbPRB_research : Form
    {
        public tbPRB_research()
        {
            InitializeComponent();
            this.Load += new EventHandler(tbPRB_research_Load);
        }

        private void tbPRB_research_Load(object sender, EventArgs e)
        {
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
            //打开连接
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //将sql语句交给cmd对象

            cmd.CommandText = "select distinct NE_Name from tbPRB order by NE_Name";
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
                MessageBox.Show("请选择想要查询的起始时间");
                return;
            }

            else if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的结束时间");
                return;
            }

            else if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的属性");
                return;
            }

            else
            {
                //每次查询之前先清空之前查询的表
                chart1.Series[0].Points.Clear();
                //接收三个下拉列表的选择
                string select1 = comboBox1.SelectedItem.ToString();
                string hour1 = comboBox2.SelectedItem.ToString();
                string hour2 = comboBox3.SelectedItem.ToString();
                string select2 = comboBox4.SelectedItem.ToString();
                string date1 = dateTimePicker1.Text.ToString();
                string date2 = dateTimePicker2.Text.ToString();

                string time1 = date1 + " " + hour1;
                string time2 = date2 + " " + hour2;

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
                    cmd.CommandText = "select round(avg(" + select2 + "),1),Start_Time from tbPRB " +
                                      "where NE_Name = '" + select1 + "' and Start_Time " +
                                      "between '" + time1 + "' and '" + time2 + "' " +
                                      "group by Start_Time order by Start_Time";

                    //用cmd的函数执行语句，返回SqlDataReader对象result,result是数据库中的查询结果
                    SqlDataReader result = cmd.ExecuteReader();
                    //用Read函数，每执行一次，返回一个包含下一行数据的集合

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    // 线的颜色为红色
                    chart1.Series[0].Color = Color.Red;
                    //线条粗细
                    chart1.Series[0].BorderWidth = 2;
                    chart1.ChartAreas[0].AxisY.Maximum = -100;
                    chart1.ChartAreas[0].AxisY.Minimum = -120;

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
                    chart1.SaveImage(filePath+"/tbPRB查询结果.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    //chart1.SaveImage(filePath + "/表tbPRB网元" + select1 + " " + select2 + "值变化情况.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("导出成功");
                }
                else
                {
                    chart1.SaveImage("D:/表tbPRB网元" + select1 + " " + select2 + "值变化情况.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbPRB_research_Load_1(object sender, EventArgs e)
        {

        }
    }
}
