using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.Classes
{
    class DatatoExcel
    {
        public static void DataSetToExcel(System.Data.DataTable dataTable, string filename)//传入查询的表以及存储的路径
        {
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
            //取得标题
            int rowIndex = 1;

            int colIndex = 0;
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;

                excel.Cells[1, colIndex] = col.ColumnName;
            }

            //取得表格中的数据
            foreach (DataRow row in dataTable.Rows)
            {
                rowIndex++;
                colIndex = 0;
                foreach (DataColumn col in dataTable.Columns)
                {
                    colIndex++;
                    excel.Cells[rowIndex, colIndex] = row[col.ColumnName];

                    ////设置表格内容居中对齐
                    //workSheet.Range[excel.Cells[rowIndex, colIndex],

                    //    excel.Cells[rowIndex, colIndex]].HorizontalAlignment =XlVAlign.xlVAlignCenter;
                }
                //if (rowIndex%500 == 0)
                //{
                //    MessageBox.Show(rowIndex.ToString());
                //}                
            }
            MessageBox.Show("导出完成");
            dataTable = null;
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
