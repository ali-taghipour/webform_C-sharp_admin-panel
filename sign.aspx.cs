using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.IO;
using System.Globalization;

public partial class sign : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sign_click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("account_insert", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@uname", sign_uname.Value);
        cmd.Parameters.AddWithValue("@upass", myFile.hash(sign_pass.Value));

        cmd.Parameters.Add("@retvalue", SqlDbType.Int).Direction = ParameterDirection.Output;

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            int retvalue = (int)cmd.Parameters["@retvalue"].Value;

            if (retvalue == 1)
            {
                error.InnerHtml = "submit seccessfully";
            }
            else if (retvalue == 0)
            {
                error.InnerHtml = "the username is exist";
            }
        }
        //catch (Exception) { }
        finally
        {
            con.Close();
        }
    }
}