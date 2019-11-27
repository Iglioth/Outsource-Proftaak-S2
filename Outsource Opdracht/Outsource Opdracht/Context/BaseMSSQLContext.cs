using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OutsourceOpdracht.Context
{
    public class BaseMSSQLContext
    {
        string connectionString = "Server=mssql.fhict.local;Database=dbi390337_outpdfmail;User Id=dbi390337_outpdfmail;Password=outpdfmail;";
        public DataSet ExecuteSql(string sql, List<KeyValuePair<object, object>> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();

                foreach (KeyValuePair<object, object> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@" + kvp.Key;
                    param.Value = kvp.Value;
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = sql;
                da.SelectCommand = cmd;

                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}