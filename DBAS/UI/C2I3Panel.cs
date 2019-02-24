using DBAS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.UI
{
    public partial class C2I3Panel : Form
    {
        DbConnection conn;
        DbCommand cmd;
        DbDataReader reader;
        ListView listview;
        List<C2IPanel.C2I> C2IList = new List<C2IPanel.C2I>();
        List<C2I3> C2I3List = new List<C2I3>();

        public struct C2I3
        {
            public string a, b, c;
        }

        public C2I3Panel(MainWindow mainwindow)
        {
            InitializeComponent();
            this.conn = mainwindow.conn;
            this.cmd = conn.CreateCommand();
            this.listview = mainwindow.listView1;
        }

        public void Init()
        {
            cmd.CommandText = "SELECT * FROM tbC2Inew";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                C2IPanel.C2I c2i = new C2IPanel.C2I();
                c2i.SCell = reader["SCell"].ToString();
                c2i.NCell = reader["NCell"].ToString();
                //c2i.C2I_mean = double.Parse(reader["C2I_mean"].ToString());
                //c2i.C2I_std = double.Parse(reader["C2I_std"].ToString());
                //c2i.PrbC2I9 = double.Parse(reader["PrbC2I9"].ToString());
                c2i.PrbABS6 = double.Parse(reader["PrbABS6"].ToString());

                C2IList.Add(c2i);
            }
            Console.WriteLine(C2I3List.Count);
            reader.Close();
            //foreach (C2IPanel.C2I c2i in C2IList)
            //{
            //    C2I3 c2i3 = new C2I3();
            //    c2i3.a = c2i.SCell;
            //    c2i3.b = c2i.NCell;
            //}
        }

        enum MatchType { None,SS,SN,NN,NS,SNBoth,NSBoth,F,Other}
        private MatchType match(C2IPanel.C2I x, C2IPanel.C2I y)
        {
            if (x.SCell == x.NCell && y.SCell == y.NCell)
                return MatchType.F;
            if ((x.NCell != y.NCell && x.NCell != y.SCell) && (x.SCell != y.SCell && x.SCell != y.NCell))
                return MatchType.None;
            if (y.SCell == x.SCell && y.NCell == x.NCell)
                return MatchType.SNBoth;
            if (y.NCell == x.SCell && y.SCell == x.NCell)
                return MatchType.NSBoth;
            if (y.SCell == x.SCell)
                return MatchType.SS;
            if (y.SCell == x.NCell)
                return MatchType.SN;
            if (y.NCell == x.NCell)
                return MatchType.NN;
            if (y.NCell == x.SCell)
                return MatchType.NS;
            else
                return MatchType.Other;
        }
        private bool IsSimaliar(C2I3 x,C2I3 y)
        {
            if (x.a == y.a)
            {
                C2IPanel.C2I p = new C2IPanel.C2I() { SCell = x.b, NCell = x.c };
                C2IPanel.C2I q = new C2IPanel.C2I() { SCell = y.b, NCell = y.c };
                MatchType type = match(p, q);
                if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                    return true;
            }
            else if (x.a == y.b)
            {
                C2IPanel.C2I p = new C2IPanel.C2I() { SCell = x.b, NCell = x.c };
                C2IPanel.C2I q = new C2IPanel.C2I() { SCell = y.a, NCell = y.c };
                MatchType type = match(p, q);
                if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                    return true;
            }
            else if (x.a == y.c)
            {
                C2IPanel.C2I p = new C2IPanel.C2I() { SCell = x.b, NCell = x.c };
                C2IPanel.C2I q = new C2IPanel.C2I() { SCell = y.a, NCell = y.b };
                MatchType type = match(p, q);
                if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                    return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value = (double)numericUpDown1.Value/100;
            C2I3List.Clear();

            foreach (C2IPanel.C2I c2i in C2IList)
            {
                C2I3 c2i3 = new C2I3();
                c2i3.a = c2i.SCell;
                c2i3.b = c2i.NCell;

                if (c2i.PrbABS6 < value)
                    continue;

                foreach (C2IPanel.C2I c2i_ in C2IList)
                {
                    if (c2i_.PrbABS6 < value)
                        continue;
                    if (match(c2i, c2i_) == MatchType.SS)
                    {                        
                        foreach (C2IPanel.C2I c2i__ in C2IList)
                        {
                            if (c2i__.PrbABS6 < value)
                                continue;
                            C2IPanel.C2I c2iTemp = new C2IPanel.C2I() { SCell = c2i.NCell, NCell = c2i_.NCell };
                            MatchType type = match(c2i__, c2iTemp);
                            if(type==MatchType.NSBoth||type==MatchType.SNBoth)
                            {
                                c2i3.c = c2i_.NCell;
                                C2I3List.Add(c2i3);
                            }
                        }
                    }
                    else if (match(c2i, c2i_) == MatchType.SN)
                    {
                        foreach (C2IPanel.C2I c2i__ in C2IList)
                        {
                            if (c2i__.PrbABS6 < value)
                                continue;
                            C2IPanel.C2I c2iTemp = new C2IPanel.C2I() { SCell = c2i.SCell, NCell = c2i_.NCell };
                            MatchType type = match(c2i__, c2iTemp);
                            if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                            {
                                c2i3.c = c2i_.NCell;
                                C2I3List.Add(c2i3);
                            }
                        }
                    }
                    else if (match(c2i, c2i_) == MatchType.NN)
                    {
                        foreach (C2IPanel.C2I c2i__ in C2IList)
                        {
                            if (c2i__.PrbABS6 < value)
                                continue;
                            C2IPanel.C2I c2iTemp = new C2IPanel.C2I() { SCell = c2i.SCell, NCell = c2i_.SCell };
                            MatchType type = match(c2i__, c2iTemp);
                            if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                            {
                                c2i3.c = c2i_.SCell;
                                C2I3List.Add(c2i3);
                            }
                        }
                    }
                    else if (match(c2i, c2i_) == MatchType.NS)
                    {
                        foreach (C2IPanel.C2I c2i__ in C2IList)
                        {
                            if (c2i__.PrbABS6 < value)
                                continue;
                            C2IPanel.C2I c2iTemp = new C2IPanel.C2I() { SCell = c2i.NCell, NCell = c2i_.SCell };
                            MatchType type = match(c2i__, c2iTemp);
                            if (type == MatchType.NSBoth || type == MatchType.SNBoth)
                            {
                                c2i3.c = c2i_.SCell;
                                C2I3List.Add(c2i3);
                            }
                        }
                    }
                }
            }

            cmd.CommandText = String.Format(@"
            IF OBJECT_ID(N'tbC2I3',N'U') is not null
	            DROP TABLE tbC2I3
            CREATE TABLE [dbo].[tbC2I3](
	            [aCell] [varchar](50) NULL,
	            [bCell] [varchar](50) NULL,
	            [cCell] [varchar](50) NULL
            )");
            cmd.ExecuteNonQuery();

            for (int i = 0; i < C2I3List.Count; i++)
            {
                for (int j = i+1; j < C2I3List.Count; j++)
                {
                    if (IsSimaliar(C2I3List[i], C2I3List[j]))
                    {
                        C2I3List.RemoveAt(j);
                        j--;
                    }
                }
            }

            foreach (C2I3 c2i3 in C2I3List)
            {
                cmd.CommandText = String.Format(@"
                INSERT INTO [dbo].[tbC2I3]
                           ([aCell]
                           ,[bCell]
                           ,[cCell])
                VALUES('{0}','{1}','{2}')", c2i3.a,c2i3.b,c2i3.c);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = "SELECT * FROM tbC2I3";
            reader = cmd.ExecuteReader();
            ListViewTool.RefreshByDbDataReader(listview, reader);
            reader.Close();
        }
    }
}
