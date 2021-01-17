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

public partial class admin_slide_all_slides : System.Web.UI.Page
{
     string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    myData md = new myData();
    Dictionary<string, object> dic = new Dictionary<string, object>();

    protected void Page_Load(object sender, EventArgs e)
    {
        fillg();
    }

    //DataSet read()
    //{
    //    DataSet ds = new DataSet();
    //    SqlConnection con = new SqlConnection(ct);
    //    SqlCommand cmd = new SqlCommand("select *from slide",con);

    //    SqlDataAdapter da = new SqlDataAdapter(cmd);


    //    try
    //    {
    //        con.Open();
    //        da.Fill(ds);
    //    }
    //    //catch(Exception) { }
    //    finally
    //    {
    //        con.Close();
    //    }

    //    return ds;
    //}

    void fillg()
    {
        DataSet ds1 = md.execuQuery("string", "select *from slide order by sliOrder",dic);

        if(ds1.Tables[0].Rows.Count == 0)
        {
            grid.InnerHtml = "no data";
            return;
        }

        for(int i=0;i< ds1.Tables[0].Rows.Count; i++)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes["class"] = "items";

            // pic
            HtmlGenericControl sli_pic = new HtmlGenericControl("li");
            sli_pic.Attributes["class"] = "pic";
            HtmlImage pic = new HtmlImage();
            string pi = ds1.Tables[0].Rows[i][7].ToString();
            pic.Attributes["Src"] = pi.Length > 3 ? "~/images/uploads/slides/full/" + ds1.Tables[0].Rows[i][7].ToString() : "~/images/icons/01.png";
            pic.Style["border-radius"] = "100%";

            // title
            HtmlGenericControl title = new HtmlGenericControl("li");
            string tit = ds1.Tables[0].Rows[i][1].ToString();
            title.InnerHtml = tit.Length > 5 ? ds1.Tables[0].Rows[i][1].ToString().Substring(0,5) + " ..." : ds1.Tables[0].Rows[i][1].ToString();
            title.Attributes["title"] = ds1.Tables[0].Rows[i][1].ToString();

            //start
            HtmlGenericControl start = new HtmlGenericControl("li");
            string st = ds1.Tables[0].Rows[i][2].ToString();
            start.InnerHtml = st.Length < 8 ? "no" : ds1.Tables[0].Rows[i][2].ToString().Insert(4,"/").Insert(7,"/");

            //end
            HtmlGenericControl end = new HtmlGenericControl("li");
            string en = ds1.Tables[0].Rows[i][3].ToString();
            end.InnerHtml = en.Length < 8 ? "no" : ds1.Tables[0].Rows[i][3].ToString().Insert(4, "/").Insert(7, "/");


            //page
            HtmlGenericControl page = new HtmlGenericControl("li");
            page.InnerHtml = ds1.Tables[0].Rows[i][4].ToString();

            //situation
            HtmlGenericControl situ = new HtmlGenericControl("li");
            bool sit = (bool)ds1.Tables[0].Rows[i][6];
            situ.InnerHtml = sit ? "آری" : "خیر";

            //order
            HtmlGenericControl order = new HtmlGenericControl("li");
            order.InnerHtml = ds1.Tables[0].Rows[i][5].ToString();

            //edit
            HtmlGenericControl edit = new HtmlGenericControl("li");
            edit.Attributes["class"] = "edit";

            HtmlAnchor anc = new HtmlAnchor();
            edit.Controls.Add(anc);
            anc.HRef = "~/admin/slide/alter_slide.aspx?id=" + ds1.Tables[0].Rows[i][0].ToString();
            anc.Style["display"] = "block";
            anc.Style["height"] = "30px";
            anc.Attributes["target"] = "_blank";

            //delete
            HtmlGenericControl del = new HtmlGenericControl("li");
            del.Attributes["class"] = "del";
            Button delc = new Button();
            delc.ID = ds1.Tables[0].Rows[i][0].ToString();
            del.Controls.Add(delc);
            delc.Style["width"] = "100%";
            delc.Style["height"] = "100%";
            delc.Style["border"] = "0 none";
            delc.Style["background"] = "url('../../images/icons/301.png') no-repeat 50%";
            delc.Style["background-size"] = "100%";
            delc.Style["cursor"] = "pointer";
            delc.Click += (object sender, EventArgs e) =>
            {
                SqlConnection con = new SqlConnection(ct);
                SqlCommand cmd = new SqlCommand("delete from slide where id =@betoche", con);

                cmd.Parameters.AddWithValue("@betoche", delc.ID);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                //catch { }
                finally
                {
                    con.Close();
                }
            };

            sli_pic.Controls.Add(pic);
            ul.Controls.Add(sli_pic);

            ul.Controls.Add(title);

            ul.Controls.Add(start);

            ul.Controls.Add(end);

            ul.Controls.Add(page);

            ul.Controls.Add(situ);

            ul.Controls.Add(order);

            ul.Controls.Add(edit);

            ul.Controls.Add(del);

            grid.Controls.Add(ul);
        }
    }

    protected void del_click(object sender, EventArgs e)
    {
        grid.InnerHtml = "hello";
    }
}