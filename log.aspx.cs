using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.IO;

public partial class log : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void log_click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("account_varify", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@uname", log_uname.Value);
        cmd.Parameters.AddWithValue("@upass", myFile.hash(log_pass.Value));

        cmd.Parameters.Add("@retvalue", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@utype", SqlDbType.NVarChar,50).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@uid", SqlDbType.Int).Direction = ParameterDirection.Output;

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            int retvalue = (int)cmd.Parameters["@retvalue"].Value;

            if (retvalue == 1)
            {
                error.InnerHtml = "the username or password is incorrect";
            }
            else if (retvalue == 0)
            {
                int uid = (int)cmd.Parameters["@uid"].Value;
                string utype = cmd.Parameters["@utype"].Value.ToString();

                Session["userid"] = uid;

                if(utype == "user")
                {
                    Response.Redirect("~/admin/admin.aspx");
                }

                else
                {
                    Response.Redirect("~/admin/admin.aspx");
                }
            }
        }
        //catch (Exception) { }
        finally
        {
            con.Close();
        }
    }
}