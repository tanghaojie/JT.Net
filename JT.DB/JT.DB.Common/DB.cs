#region 
/***
 *  JT.MIT
***/
#endregion 

using System;
using System.Data;
using System.Data.Common;
namespace JT.DB.Common {
    public partial class DB {
        public static void OpenConnection(DbConnection connection) {
            if (connection == null) { throw new ArgumentNullException(); }
            if (connection.State != ConnectionState.Open) { connection.Open(); }
        }
    }
}
