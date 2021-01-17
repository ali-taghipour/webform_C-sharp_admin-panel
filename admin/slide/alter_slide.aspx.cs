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

using System.Globalization;

using System.IO;
using System.Web.UI.HtmlControls;

public partial class slide_alter_slide : System.Web.UI.Page
{
    string cs = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        string sid = Request.QueryString["id"];

        if(!this.IsPostBack) {
            if (sid != null)
            {
                fill_form();
            }
            else
            {
                form.InnerHtml = "داده ای موجود نمی باشد ...";
                form.Style["font-family"] = "B Nazanin";
                form.Style["font-size"] = "20px";
            }
        }

    }
    DataTable read_data()
    {
        string sid = Request.QueryString["id"].ToString();

        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("select * from slide where id= @id", con);

        cmd.Parameters.AddWithValue("@id", sid);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            da.Fill(dt);
        }
        //catch { }
        finally
        {
            con.Close();
        }

        return dt;
    }

    void fill_form()
    {
        DataTable dt0 = read_data();

        sli_title.Value = dt0.Rows[0][1].ToString();
        sli_start.Value = dt0.Rows[0][2].ToString().Insert(4,"/").Insert(7,"/");
        sli_end.Value = dt0.Rows[0][3].ToString().Insert(4, "/").Insert(7, "/");
        sli_page.Value = dt0.Rows[0][4].ToString();
        sli_order.Value = dt0.Rows[0][5].ToString();

        bool z = (bool)dt0.Rows[0][6];
        show.Checked = z ? true : false;
        hide.Checked = z ? false : true;

        sli_img.Attributes["Src"] = "../../images/uploads/slides/full/" + dt0.Rows[0][7].ToString();
        sli_des.Value = dt0.Rows[0][8].ToString();
    }

    protected void update(object sender, EventArgs e)
    {
        string sid = Request.QueryString["id"].ToString();

        DateTime mil = DateTime.Today;

        PersianCalendar shamsi = new PersianCalendar();

        int y = shamsi.GetYear(mil);
        int m = shamsi.GetMonth(mil);
        int d = shamsi.GetDayOfMonth(mil);

        int sha = y * 10000 + m * 100 + d;

        //pic
        HttpPostedFile file = Request.Files["sli_pic"];

        string fileName = "";
        string fileExt = "";

        if (file != null)
        {
            fileExt = Path.GetExtension(file.FileName).ToLower();
            if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".png")
            {
                fileName = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("~/images/uploads/slides/full/") + fileName);
            }
        }

        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("update slide set title=@p1,startDate=@p2,endDate=@p3,targetPage=@p4,slideOrder=@p5,show=@p6,pic=case when @p7='' then pic else @p7 end,describe=@p8,lastUpdate=@p9 where id=@id", con);

        cmd.Parameters.AddWithValue("@p1", sli_title.Value);
        cmd.Parameters.AddWithValue("@p2", sli_start.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p3", sli_end.Value.Replace("/", ""));
        cmd.Parameters.AddWithValue("@p4", sli_page.Value);
        cmd.Parameters.AddWithValue("@p5", sli_order.Value);
        cmd.Parameters.AddWithValue("@p6", show.Checked);
        cmd.Parameters.AddWithValue("@p7", fileName);
        cmd.Parameters.AddWithValue("@p8", sli_des.Value);
        cmd.Parameters.AddWithValue("@p9", sha);
        cmd.Parameters.AddWithValue("@id", sid);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            error.InnerHtml = "با موفقیت انجام شد";
            Response.Redirect("~/admin/slide/alter_slide.aspx?id="+ sid);
        }
        //catch{}
        finally
        {
            con.Close();
        }

    }

    protected void del_click(object sender, EventArgs e)
    {
        string sid = Request.QueryString["id"].ToString();

        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("delete from slide where id=@id",con);

        cmd.Parameters.AddWithValue("@id", sid);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            form.InnerHtml = "عملیات با موفقیت انجام شد ...";
        }
        //catch { }
        finally
        {
            con.Close();
        }

    }
}


