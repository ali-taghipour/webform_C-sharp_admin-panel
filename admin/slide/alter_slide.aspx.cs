using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Web.Configuration;

using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

using System.IO;
using System.Globalization;

public partial class admin_slide_alter_slide : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if(!this.IsPostBack)
        {
            if(id != null)
            {
                fill();
            }
            else
            {
                form.InnerHtml = "no data";
            }
        }
    }

    DataTable data()
    {
        string id = Request.QueryString["id"].ToString();

        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("select * from slide where id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);

        DataTable ta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        try
        {
            con.Open();
            da.Fill(ta);
        }
        //catch (Exception) { }
        finally
        {
            con.Close();
        }

        return ta;
    }
    void fill()
    {
        DataTable dt0 = data();

        sli_title.Value = dt0.Rows[0][1].ToString();
        string st = dt0.Rows[0][2].ToString();
        sli_start.Value = st.Length < 8 ? "no" : dt0.Rows[0][2].ToString().Insert(4,"/").Insert(7,"/");
        string en = dt0.Rows[0][3].ToString();
        sli_end.Value = en.Length < 8 ? "no" : dt0.Rows[0][3].ToString().Insert(4, "/").Insert(7, "/");
        sli_page.Value = dt0.Rows[0][4].ToString();
        sli_order.Value = dt0.Rows[0][5].ToString();
        bool sh = (bool)dt0.Rows[0][6];
        if (sh)
        {
            show.Checked = true;
        }
        else
        {
            hide.Checked = true;
        }

        string pi = dt0.Rows[0][7].ToString();
        sli_img.Src = pi.Length > 3 ? "~/images/uploads/slides/full/" + dt0.Rows[0][7].ToString() : "~/images/icons/01.png";

        sli_des.Value = dt0.Rows[0][8].ToString();
    }

    protected void update_click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();

        // file pic

        string fileExt = "";
        string fileName = "";

        HttpPostedFile picf = Request.Files["sli_pic"];

        if (picf != null)
        {
            fileExt = Path.GetExtension(picf.FileName).ToLower();

            if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".png")
            {
                fileName = Path.GetFileName(picf.FileName);

                Random ra = new Random();

                int ran = ra.Next(0, 100000);
                fileName = ra + fileName;

                picf.SaveAs(Server.MapPath("~/images/uploads/slides/full/" + fileName));

            }
        }


        // calender

        DateTime mil = DateTime.Today;

        PersianCalendar shamsi = new PersianCalendar();

        int year = shamsi.GetYear(mil);
        int month = shamsi.GetMonth(mil);
        int day = shamsi.GetDayOfMonth(mil);

        int sham = year * 10000 + month * 100 + day;

        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("update slide set title=@p1,startDate=@p2,endDate=@p3,sliPage=@p4,sliOrder=@p5,show=@p6,  pic=case when @p7='' then pic else @p7 end,describe=@p8,lastUpdate=@p9 where id = @id", con);

        cmd.Parameters.AddWithValue("@p1", sli_title.Value);
        cmd.Parameters.AddWithValue("@p2", sli_start.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p3", sli_end.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p4", sli_page.Value);
        cmd.Parameters.AddWithValue("@p5", sli_order.Value);
        cmd.Parameters.AddWithValue("@p6", show.Checked);
        cmd.Parameters.AddWithValue("@p7", fileName);
        cmd.Parameters.AddWithValue("@p8", sli_des.Value);
        cmd.Parameters.AddWithValue("@p9", sham);
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("~/admin/slide/alter_slide.aspx?id=" + id);
            error.InnerHtml = "update successful";
        }
        //catch () { }
        finally
        {
            con.Close();
        }
    }

    protected void del_click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();

        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("delete from slide where id = @id", con);

        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            form.InnerHtml = "deleted successfully";
        }
        //catch () { }
        finally
        {
            con.Close();
        }
    }
}