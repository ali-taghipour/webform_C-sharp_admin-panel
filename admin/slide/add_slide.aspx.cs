using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Text.RegularExpressions;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Globalization;

using System.IO;
public partial class slide_add_slide : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void add_click(object sender, EventArgs e)
    {
        //string r1 = @"/^[\u0600-\u06ff]([\u0600-\u06ff]|\s|\d){3,20}$/";
        //string r2 = @"/^1(3|4)\d{2}\/\d{2}\/\d{2}$/";
        //string r3 = @"/^([1-9]|[1-9]\d)$/";
        ////validate

        //if (!Regex.IsMatch(sli_title.Value, @"/^[\u0600-\u06ff]([\u0600-\u06ff]|\s|\d){3,20}$/"))
        //{
        //    error.InnerHtml = "عنوان نادرست است ...";
        //    return;
        //}

        //if (!Regex.IsMatch(sli_start.Value, r2))
        //{
        //    error.InnerHtml = "تاریخ شروع نادرست است ...";
        //    return;
        //}

        //if (!Regex.IsMatch(sli_end.Value, r2))
        //{
        //    error.InnerHtml = "تاریخ پایان نادرست است ...";
        //    return;
        //}

        //if (!Regex.IsMatch(sli_order.Value, r3))
        //{
        //    error.InnerHtml = "اولویت نادرست است ...";
        //    return;
        //}

        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("insert into slide values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", con);

        cmd.Parameters.AddWithValue("@p1", sli_title.Value);
        cmd.Parameters.AddWithValue("@p2", sli_start.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p3", sli_end.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p4", sli_page.Value);
        cmd.Parameters.AddWithValue("@p5", sli_order.Value);
        cmd.Parameters.AddWithValue("@p6", show.Checked);
        cmd.Parameters.AddWithValue("@p7", myFile.getFile("sli_pic","slides"));
        cmd.Parameters.AddWithValue("@p8", sli_des.Value);
        cmd.Parameters.AddWithValue("@p9", myDate.getDate());
        cmd.Parameters.AddWithValue("@p10", myDate.getDate());

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            error.InnerHtml = "با موفقیت انجام شد";
        }
        //catch
        //{
        //    error.InnerHtml = "ریدی گلم!!!";
        //}
        finally
        {
            con.Close();
        }
    }

}