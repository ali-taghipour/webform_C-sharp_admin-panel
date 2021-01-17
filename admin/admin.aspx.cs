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
using System.Globalization;

public partial class admin_admin : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("~/log.aspx");
        }
        else
        {
            show();
        }
    }

    void show()
    {
        string uid = Session["userid"].ToString();

    

        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("select fname,lname,uname,sex,pic from account where id=@uid",con);
        cmd.Parameters.AddWithValue("@uid", uid);
  
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            string sex = "";

            if (reader["sex"].ToString() == "NULL")
            {
                sex = "";
            }

            else {
                sex = "آقای";
            }

            string full_name = reader["fname"] + " " + reader["lname"] + " ( " + reader["uname"] + " ) ";

            wel.InnerHtml = sex + full_name;
        }

        ////catch(Exception) { }

        finally
        {
            con.Close();
        }
    }
}