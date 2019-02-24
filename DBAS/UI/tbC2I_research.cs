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
    public partial class tbC2I_research : Form
    {
        public tbC2I_research()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x;
            float Prb;

            if (textBox1.Text == null)
            {
                MessageBox.Show("请输入参数的值");
            }

            else if (int.TryParse(textBox1.Text.ToString(), out x))
            {
                x = int.Parse(textBox1.Text.ToString());

                if (x < 0 || x > 100)
                {
                    MessageBox.Show("请输入0-100的数字");
                }

                else
                {
                    Prb = (float)x;
                    Prb = Prb / 100;

                    //创建数据库连接类的对象
                    SqlConnection con = new SqlConnection("server=.;database=DBAS;integrated security=SSPI");
                    //打开连接
                    con.Open();
                    //执行con对象的函数，返回一个SqlCommand类型的对象
                    SqlCommand cmd = con.CreateCommand();
                    //将sql语句交给cmd对象
                    cmd.CommandText = "select distinct a.SCell as aSCell,b.SCell as bSCell,c.SCell as cSCell " +
                                      "from tbC2Inew as a,tbC2Inew as b,tbC2Inew as c " +
                                      "where a.NCell = b.SCell and b.NCell = c.SCell and c.NCell = a.SCell " + 
                                      "and a.PrbABS6 > "+ Prb + " and b.PrbABS6 > "+ Prb + " and c.PrbABS6 > "+ Prb + " " + 
                                         "or a.NCell = c.SCell and c.NCell = b.SCell and b.NCell = a.SCell " +
                                      "and a.PrbABS6 > "+ Prb + " and b.PrbABS6 > "+ Prb + " and c.PrbABS6 > "+ Prb + " ";

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "tbCell");
                    dataGridView1.DataSource = ds.Tables["tbCell"];

                    con.Close();
                }
            }

            else
            {
                MessageBox.Show("请输入纯数字");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
