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
    string cs = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void log_click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("account_verify", con);
        cmd.CommandType =  CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@uname", log_uname.Value);
        cmd.Parameters.AddWithValue("@pass", log_pass.Value);

        cmd.Parameters.Add("@retvalue", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@uid", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@utype", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            int result = (int)cmd.Parameters["@retvalue"].Value;

            if (result == 1)
            {
                string user_type = cmd.Parameters["@utype"].Value.ToString();
                int user_id = (int)cmd.Parameters["@uid"].Value;

                Session["usid"] = user_id;

                if (user_type == "user")
                {
                    Response.Redirect("~/user/user.aspx");
                }
                else if (user_type == "admin")
                {
                    Response.Redirect("~/admin/admin.aspx");
                }
            }
            else if (result == 0)
            {
                error.InnerHtml = " در بووور";
            }
        }
        //catch { }
        finally
        {
            con.Close();
        }
    }
}