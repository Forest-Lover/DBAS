using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAS.Classes
{
    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public enum RegistryResult { OK,NAME_EXISTED,PWD_FORMATE_WRONG}

        public bool Authenticated(DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = String.Format(@"SELECT COUNT(*) FROM Account 
            WHERE Name='{0}' AND Password='{1}' AND Type={2}", Name, Password, Type);
            if ((int)cmd.ExecuteScalar() != 0)
                return true;
            else
                return false;
        }

        public RegistryResult Registe(DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();

            cmd.CommandText = String.Format(@"SELECT COUNT(*) FROM Account 
            where Name='{0}' AND Type={1}", Name, Type);
            if ((int)cmd.ExecuteScalar() != 0)
                return RegistryResult.NAME_EXISTED;
            if (Password.Length < 5)
                return RegistryResult.PWD_FORMATE_WRONG;
            cmd.CommandText = String.Format(@"INSERT INTO Account(Name,Password,Type) 
            VALUES('{0}','{1}',{2})", Name, Password, Type);
            cmd.ExecuteNonQuery();
            return RegistryResult.OK;
        }
    }
}
