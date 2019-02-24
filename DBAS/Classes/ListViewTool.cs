using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.Classes
{
    public static class ListViewTool
    {
        public static void RefreshByDbDataReader(ListView listview, DbDataReader reader)
        {
            listview.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                listview.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                string[] strarray = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    strarray[i] = reader[i].ToString();
                listview.Items.Add(new ListViewItem(strarray));
            }
        }
    }
}
