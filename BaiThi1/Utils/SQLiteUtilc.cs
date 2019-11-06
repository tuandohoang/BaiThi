using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThi1.Utils
{
    public class SQLiteUtilc
    {
        private const string DatabaseName = "baithi.db";

        private static SQLiteUtilc _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtilc GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtilc();
            }
            return _instance;
        }

        private SQLiteUtilc()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Note (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Title VARCHAR( 140 ),Content VARCHAR( 140 ), CreatedAt DateTime, UpdatedAt DateTime);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
