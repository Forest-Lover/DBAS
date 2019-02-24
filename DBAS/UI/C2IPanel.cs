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
    public partial class C2IPanel : Form
    {
        DbConnection conn;
        DbCommand cmd;
        DbDataReader reader;
        ListView listview;
        public struct C2I
        {
            public string SCell;
            public string NCell;
            public double C2I_mean;
            public double C2I_std;
            public double PrbC2I9;
            public double PrbABS6;
        }
        
        public C2IPanel(MainWindow mainwindow)
        {
            InitializeComponent();
            this.conn = mainwindow.conn;
            this.cmd = conn.CreateCommand();
            this.listview = mainwindow.listView1;
        }

        public void Init()
        {
            cmd.CommandText = String.Format(@"
            IF OBJECT_ID(N'tempdb..#C2ITemp',N'U') is not null
	            DROP TABLE #C2ITemp;
            WITH 
            temAll AS
            (
	            SELECT ServingSector AS SCell,InterferingSector AS NCell,
		            CAST(LteScRSRP AS int)-CAST(LteNcRSRP AS int) AS C2I
	            FROM tbMROData
            ),
            temAvg AS 
            (
	            SELECT ServingSector AS SCell,InterferingSector AS NCell,
		            AVG(CAST(LteScRSRP AS int)-CAST(LteNcRSRP AS int)) AS C2I_mean
	            FROM tbMROData 
	            GROUP BY ServingSector,InterferingSector
            )
            SELECT temAll.SCell,temAll.Ncell,C2I_mean,COUNT(*) AS count, 
	            ROUND(SQRT(AVG(SQUARE(C2I-C2I_mean))),2) AS C2I_std 
            INTO #C2ITemp
            FROM temAll left join temAvg ON temAll.NCell=temAvg.NCell and temAll.SCell=temAvg.SCell
            GROUP BY temAll.SCell,temAll.Ncell,C2I_mean");
            cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            cmd.CommandText = String.Format(@"
            IF OBJECT_ID(N'tbC2Inew',N'U') is not null
	            DROP TABLE tbC2Inew
            CREATE TABLE [dbo].[tbC2Inew]
            (
	            [SCell] [varchar](50) NULL,
	            [Ncell] [varchar](50) NULL,
	            [C2I_mean] [float] NULL,
	            [C2I_std] [float] NULL,
	            [PrbC2I9] [float] NULL,
	            [PrbABS6] [float] NULL
            )");
            cmd.ExecuteNonQuery();

            cmd.CommandText = String.Format("SELECT * FROM #C2ITemp WHERE count>={0}", value);
            reader = cmd.ExecuteReader();
            List<C2I> C2IList = new List<C2I>();
            while (reader.Read())
            {
                C2I c2i = new C2I();
                c2i.SCell = reader["SCell"].ToString();
                c2i.NCell = reader["NCell"].ToString();
                c2i.C2I_mean = double.Parse(reader["C2I_mean"].ToString());
                c2i.C2I_std = double.Parse(reader["C2I_std"].ToString());
                if (c2i.C2I_std == 0)
                    c2i.PrbC2I9 = c2i.C2I_mean < 9 ? 1 : 0;
                else
                {
                    if (c2i.C2I_mean <= 9)
                        c2i.PrbC2I9 = Prb.getProbability(c2i.C2I_mean, 9, c2i.C2I_mean, c2i.C2I_std) + 0.5;
                    else
                        c2i.PrbC2I9 = 0.5 - Prb.getProbability(9, c2i.C2I_mean, c2i.C2I_mean, c2i.C2I_std);
                    c2i.PrbABS6 = Prb.getProbability(-6, 6, c2i.C2I_mean, c2i.C2I_std);
                }  
                C2IList.Add(c2i);
            }
            reader.Close();

            foreach (C2I c2i in C2IList)
            {
                cmd.CommandText = String.Format(@"
                INSERT INTO [dbo].[tbC2Inew]
                           ([SCell]
                           ,[Ncell]
                           ,[C2I_mean]
                           ,[C2I_std]
                           ,[PrbC2I9]
                           ,[PrbABS6])
                     VALUES
                           ('{0}','{1}',{2},{3},{4},{5})
                ", c2i.SCell, c2i.NCell, c2i.C2I_mean, c2i.C2I_std, c2i.PrbC2I9, c2i.PrbABS6);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = "SELECT * FROM tbC2Inew";
            reader = cmd.ExecuteReader();
            ListViewTool.RefreshByDbDataReader(listview, reader);
            reader.Close();
        }
    }
}
