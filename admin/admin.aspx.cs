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

public partial class admin_admin : System.Web.UI.Page
{
    string cs = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usid"] == null)
        {
            Response.Redirect("~/log.aspx");
        }
        else
        {
            show_info();
        }
    }
    void show_info()
    {
        string uid = Session["usid"].ToString();

        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("select fname,lname,uname,sex,pic from account where id=@uid",con);

        cmd.Parameters.AddWithValue("@uid",uid);

        SqlDataReader reader;

        try {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            string user_sex = "";

            if (reader["sex"].ToString() == "NULL")
            {
               user_sex = "";
            }
            else
            {
                user_sex = (bool)reader["sex"] ? "آقای" : "خانم";
            }

            string full_name = reader["fname"] + " " + reader["lname"] + " " + "(" + reader["uname"] + ")";

            wel.InnerHtml = user_sex + " " + full_name;
        }
        //catch { }
        finally {
            con.Close();
        }
    }
}