#region 
/***
 *  JT.MIT
***/
#endregion 

using System.Data;
using System.Data.Common;
namespace JT.DB.Common {

    #region Execute Query
    public partial interface IDB {
        DataSet ExecuteQuery(string textCommand, params DbParameter[] parameters);
        DataSet ExecuteQuery(DbTransaction transaction, string textCommand, params DbParameter[] parameters);
    }
    #endregion

    #region Execute Non Query
    public partial interface IDB {
        int ExecuteNonQuery(string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters);
        int ExecuteNonQuery(DbTransaction transaction, string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters);
    }
    #endregion

    #region Get Connection
    public partial interface IDB {
        DbConnection GetConnection();
    }
    #endregion

}
