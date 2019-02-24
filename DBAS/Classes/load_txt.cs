using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace DBAS.Classes
{
    class load_txt
    {
        public static void DatatoTxt(string fileName, string connStr, string commStr)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(commStr, conn);
                SqlDataReader reader = null;
                reader = comm.ExecuteReader();
                fileName += ".csv";
                using (FileStream fstream = File.OpenWrite(fileName))
                {
                    StreamWriter sw = new StreamWriter(fstream, System.Text.Encoding.GetEncoding("GB2312"));
                    int col = 0, row = 2;
                    if (reader.HasRows)
                    {
                        string s = null;
                        for (col = 0; col < reader.FieldCount; col++)
                        {

                            if (col != reader.FieldCount)
                            {
                                s = s + reader.GetName(col) + ",";
                            }
                            else
                            {
                                s += reader.GetName(col);
                            }

                        }
                        sw.WriteLine(s);
                        while (reader.Read())
                        {
                            s = null;
                            for (col = 0; col < reader.FieldCount; col++)
                            {
                                if (col != reader.FieldCount)
                                {
                                    s = s + reader.GetValue(col).ToString() + ",";
                                }
                                else
                                {
                                    s += reader.GetValue(col).ToString();
                                }
                            }
                            row++;
                            sw.WriteLine(s);
                        }
                    }
                    sw.Flush();

                }
                MessageBox.Show("导入完成");
                conn.Close();
                reader.Close();
                reader = null;

            }


        }
    }
}
