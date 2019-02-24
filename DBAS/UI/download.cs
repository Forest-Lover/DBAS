using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.SqlClient;
using DBAS.Classes;

namespace DBAS.UI
{
    public partial class download : Form
    {
        private FolderBrowserDialog fb;
        public download()
        {
            InitializeComponent();

        }
        public download(List<string> li)
        {
            InitializeComponent();
            foreach (string str in li)
            {
                this.comboBox1.Items.Add(str);
            }
            this.comboBox2.Items.Add("excel");
            this.comboBox2.Items.Add("csv");
            this.comboBox2.Text = "csv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = null;
            if (textBox2.Text == null)
            {
                filename = this.textBox1.Text + "\\" + comboBox1.Text.ToString();//拼接文件名
            }
            else
            {
                filename = this.textBox1.Text + "\\" + textBox2.Text.ToString();//拼接文件名
            }
            if(comboBox1.SelectedItem != null)
            {
                string connSql = @"Data Source=(local);Initial Catalog=DBAS;Integrated Security=True";
                string commSql = string.Format("SELECT * FROM [{0}]", comboBox1.SelectedItem.ToString());
                //MessageBox.Show(commSql);
                try
                {
                    if (comboBox2.SelectedItem.ToString().Equals("csv"))
                    {
                        load_txt.DatatoTxt(filename, connSql, commSql);
                    }
                    else
                    {
                        load_excel.DataSetToExcel(filename, connSql, commSql);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("未选择导出的表");
            }
           
            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt = DataBaseHelper.ExecuterQuery(connSql, commSql);
            //DatatoExcel.DataSetToExcel(dt, filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                string foldPath = fb.SelectedPath;
                this.textBox1.Text = foldPath;
                //DirectoryInfo theFolder = new DirectoryInfo(foldPath);
                //FileInfo[] dirInfo = theFolder.GetFiles();
                ////遍历文件夹
                //foreach (FileInfo file in dirInfo)
                //{
                //    MessageBox.Show(file.ToString());
                //}
                //MessageBox.Show(comboBox1.SelectedItem.ToString());

            }
        }

    }
}
