using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAS.Classes
{
    public static class NavTreeTool
    {
        public static void RefreshByDbConnection(TreeView treeview, ContextMenuStrip cms, DbConnection conn)
        {
            treeview.Nodes.Clear();
            TreeNode topnode = new TreeNode(conn.Database);
            treeview.Nodes.Add(topnode);

            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM sys.tables";
            DbDataReader reader = cmd.ExecuteReader();

            treeview.BeginUpdate();
            topnode.Nodes.Clear();
            while (reader.Read())
            {
                TreeNode node = new TreeNode((string)reader["name"]);
                node.ContextMenuStrip = cms;
                topnode.Nodes.Add(node);
            }
            treeview.EndUpdate();

            reader.Close();
            treeview.MouseDown += (object sender, MouseEventArgs e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    TreeNode tn = treeview.GetNodeAt(e.X, e.Y);
                    if (tn != null)
                        treeview.SelectedNode = tn;
                }
            };
            treeview.TopNode.Expand();
        }
    }
}
