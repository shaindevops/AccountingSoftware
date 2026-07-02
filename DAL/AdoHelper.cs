using BE.Logging;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Shared helper for the raw ADO.NET reads that live alongside EF6 in
    /// this codebase (grid-fill queries and stored-procedure searches).
    /// Centralizes the SqlConnection/SqlDataAdapter boilerplate that was
    /// previously copy-pasted in nearly every DAL class, each with its own
    /// hardcoded connection string and an unused SqlCommandBuilder.
    ///
    /// Exceptions are caught, logged, and result in a null return - this
    /// matches the existing behavior of the call sites being migrated to
    /// use this helper, so it does not change what callers observe.
    /// </summary>
    internal static class AdoHelper
    {
        public static DataTable ExecuteStoredProcedure(string context, string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var cmd = new SqlCommand(procedureName, con) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var ds = new DataSet();
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError(context, e);
                return null;
            }
        }

        public static DataTable ExecuteQuery(string context, string sql)
        {
            try
            {
                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var adapter = new SqlDataAdapter(sql, con))
                {
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError(context, e);
                return null;
            }
        }
    }
}
