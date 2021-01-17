using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class myData
{
    string cs;
    int er = 0;
    public myData()
    {
        cs = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    }

    public void execuNonQuery(string commandType,string commandText,Dictionary<string,object> param)
    {
        var con = new SqlConnection(cs);
        var cmd = new SqlCommand(commandText,con);

        cmd.CommandType = commandType == "stored" ? CommandType.StoredProcedure : CommandType.Text;

        foreach(var i in param)
        {
            cmd.Parameters.AddWithValue(i.Key,i.Value);
        }

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            er = 1;
        }

        //catch (Exception) { }
        finally
        {
            con.Close();
        }
    }

    public DataSet execuQuery(string commandType, string commandText, Dictionary<string, object> param)
    {
        var con = new SqlConnection(cs);
        var cmd = new SqlCommand(commandText, con);

        cmd.CommandType = commandType == "stored" ? CommandType.StoredProcedure : CommandType.Text;

        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();

        foreach (var i in param)
        {
            cmd.Parameters.AddWithValue(i.Key, i.Value);
        }

        try
        {
            con.Open();
            da.Fill(ds);
            er = 1;
        }

        //catch (Exception) { }
        finally
        {
            con.Close();
        }

        return ds;

    }

}