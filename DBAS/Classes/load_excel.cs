using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.Classes
{
    class load_excel
    {
        public static void DataSetToExcel(string filename, string connectionString, string commandSql)//传入查询的表以及存储的路径
        {
            //1.打开数据库，2，写数据
            using(SqlConnection conn =new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                conn.Open();
                SqlCommand comm = new SqlCommand(commandSql, conn);
                reader = comm.ExecuteReader();//打开数据库读
                //开启excel
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    // if equal null means EXCEL is not installed.
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }
                Workbook workBook;
                if (File.Exists(filename))
                {
                    workBook = excel.Workbooks.Open(filename, 0, false, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                }
                else
                {
                    workBook = excel.Workbooks.Add(true);
                }
                //new a worksheet
                Worksheet workSheet = workBook.ActiveSheet as Worksheet;

                //write data
                workSheet = (Worksheet)workBook.Worksheets.get_Item(1);//获得第i个sheet，准备写入
                                                                       //set visible the Excel will run in background
                excel.Visible = false;
                //set false the alerts will not display
                excel.DisplayAlerts = false;
                int col = 0, row = 2;
                if (reader.HasRows)
                {
                    for (col = 0; col < reader.FieldCount; col++)
                    {
                        excel.Cells[1, col + 1] = reader.GetName(col);
                    }

                    while (reader.Read())
                    {
                        for (col = 0; col < reader.FieldCount; col++)
                        {
                            excel.Cells[row, col + 1] = reader.GetValue(col).ToString();

                        }
                        row++;
                    }
                }
                reader.Close();
                conn.Close();
                MessageBox.Show("导出完成");
                workBook.SaveAs(filename);
                workBook.Close(false, Missing.Value, Missing.Value);
                //quit and clean up objects
                excel.Quit();
                workSheet = null;
                workBook = null;
                excel = null;
                GC.Collect();


            }  
        }
    }
}
