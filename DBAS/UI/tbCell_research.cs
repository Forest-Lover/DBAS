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
using DBAS.Classes;

namespace DBAS.UI
{
    public partial class tbCell_research : Form
    {
        private DataSet ds;
        public tbCell_research()
        {
            InitializeComponent();
        }

        private void tbCell_research_Load(object sender, EventArgs e)
        {
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
            //打开连接
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //将sql语句交给cmd对象

            cmd.CommandText = "select distinct SECTOR_ID from tbCell order by SECTOR_ID";
            //用cmd的函数执行语句，返回SqlDataReader对象result1,result1是数据库中的查询结果
            SqlDataReader result1 = cmd.ExecuteReader();
            //用Read函数，每执行一次，返回一个包含下一行数据的集合
            while (result1.Read())
            {
                this.comboBox1.Items.Add(result1[0].ToString());
            }
            result1.Close();

            cmd.CommandText = "select distinct SECTOR_NAME from tbCell order by SECTOR_NAME";
            //用cmd的函数执行语句，返回SqlDataReader对象result2,result2是数据库中的查询结果
            SqlDataReader result2 = cmd.ExecuteReader();
            //用Read函数，每执行一次，返回一个包含下一行数据的集合
            while (result2.Read())
            {
                this.comboBox2.Items.Add(result2[0].ToString());
            }
            result2.Close();

            cmd.CommandText = "select distinct ENODEBID from tbCell order by ENODEBID";
            //用cmd的函数执行语句，返回SqlDataReader对象result3,result3是数据库中的查询结果
            SqlDataReader result3 = cmd.ExecuteReader();
            //用Read函数，每执行一次，返回一个包含下一行数据的集合
            while (result3.Read())
            {
                this.comboBox3.Items.Add(result3[0].ToString());
            }
            result3.Close();

            cmd.CommandText = "select distinct ENODEB_NAME from tbCell order by ENODEB_NAME";
            //用cmd的函数执行语句，返回SqlDataReader对象result4,result4是数据库中的查询结果
            SqlDataReader result4 = cmd.ExecuteReader();
            //用Read函数，每执行一次，返回一个包含下一行数据的集合
            while (result4.Read())
            {
                this.comboBox4.Items.Add(result4[0].ToString());
            }
            result4.Close();

            con.Close();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的小区ID");
                return;
            }

            else
            {
                string select = comboBox1.SelectedItem.ToString();

                //创建数据库连接类的对象
                SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                //打开连接
                con.Open();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = con.CreateCommand();
                //将sql语句交给cmd对象
                cmd.CommandText = "select * from tbCell where SECTOR_ID = '"+select+"' ";

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "tbCell");
                dataGridView1.DataSource = ds.Tables["tbCell"];

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的小区名称");
                return;
            }

            else
            {
                string select = comboBox2.SelectedItem.ToString();

                //创建数据库连接类的对象
                SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                //打开连接
                con.Open();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = con.CreateCommand();
                //将sql语句交给cmd对象
                cmd.CommandText = "select * from tbCell where SECTOR_NAME = '" + select + "' ";

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "tbCell");
                dataGridView1.DataSource = ds.Tables["tbCell"];

                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的基站ID");
                return;
            }

            else
            {
                string select = comboBox3.SelectedItem.ToString();

                //创建数据库连接类的对象
                SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                //打开连接
                con.Open();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = con.CreateCommand();
                //将sql语句交给cmd对象
                cmd.CommandText = "select * from tbCell where ENODEBID = '" + select + "' ";

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "tbCell");
                dataGridView1.DataSource = ds.Tables["tbCell"];

                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("请选择想要查询的基站名称");
                return;
            }

            else
            {
                string select = comboBox4.SelectedItem.ToString();

                //创建数据库连接类的对象
                SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                //打开连接
                con.Open();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = con.CreateCommand();
                //将sql语句交给cmd对象
                cmd.CommandText = "select * from tbCell where ENODEB_NAME = '" + select + "' ";

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "tbCell");
                dataGridView1.DataSource = ds.Tables["tbCell"];

                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            string filePath = null;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                filePath = fb.SelectedPath;
            }
            if (filePath != null)
            {
                filePath += "\\tbCell表查询记录";
                try
                {
                    if (ds.Tables["tbCell"] == null)
                    {
                        MessageBox.Show("查询记录为空,请从新查询");
                    }
                    else
                    {
                        DatatoExcel.DataSetToExcel(ds.Tables["tbCell"], filePath);
                    }
                    
                   

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
            else
            {
                filePath = "D:\\tbCell表查询记录";
                try
                {
                    if (ds.Tables["tbCell"] == null)
                    {
                        MessageBox.Show("查询记录为空,请从新查询");
                    }
                    else
                    {
                        DatatoExcel.DataSetToExcel(ds.Tables["tbCell"], filePath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

          
            }
        }
    }
}
