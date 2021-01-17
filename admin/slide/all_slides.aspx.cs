using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Web.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Globalization;

using System.IO;

public partial class slide_all_slides : System.Web.UI.Page
{
    string ct = WebConfigurationManager.ConnectionStrings["all"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        fill_grid();
    }
    DataSet read_data()
    {
        SqlConnection con = new SqlConnection(ct);
        SqlCommand cmd = new SqlCommand("select * from slide", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        try
        {
            con.Open();
            da.Fill(ds);
        }
        //catch { }
        finally
        {
            con.Close();
        }

        return ds;
    }
    void fill_grid()
    {
        DataSet ds0 = read_data();

        if (ds0.Tables[0].Rows.Count == 0)
        {
            grid.InnerHtml = "هیچ داده ای موجود نیست ...";
            return;
        }
        for (int i = 0; i < ds0.Tables[0].Rows.Count; i++)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes["class"] = "items";

            //pic

            HtmlGenericControl li_pic = new HtmlGenericControl("li");
            li_pic.Attributes["class"] = "pic";

            string v = ds0.Tables[0].Rows[i][7].ToString().Length == 0 ?
                "../../images/icons/223.png" : "../../images/uploads/slides/full/" + ds0.Tables[0].Rows[i][7].ToString();
            HtmlImage im = new HtmlImage();
            im.Src = v;
            im.Style["border-radius"] = "100%";
            li_pic.Controls.Add(im);

            //title

            HtmlGenericControl li_title = new HtmlGenericControl("li");
            li_title.InnerHtml = ds0.Tables[0].Rows[i][1].ToString();
            li_title.Attributes["title"] = ds0.Tables[0].Rows[i][1].ToString();

            //start date
            string d = ds0.Tables[0].Rows[i][2].ToString();
            HtmlGenericControl li_start = new HtmlGenericControl("li");
            li_start.Attributes["class"] = "date";
            li_start.InnerHtml = d.Length < 8 ? "" : d.Insert(4, "/").Insert(7, "/");

            //end date

            HtmlGenericControl li_end = new HtmlGenericControl("li");
            li_end.Attributes["class"] = "date";
            li_end.InnerHtml = ds0.Tables[0].Rows[i][3].ToString();
            li_end.InnerHtml = d.Length < 8 ? "" : d.Insert(4, "/").Insert(7, "/");
            //page

            HtmlGenericControl li_page = new HtmlGenericControl("li");
            li_page.InnerHtml = ds0.Tables[0].Rows[i][4].ToString();

            //order

            HtmlGenericControl li_order = new HtmlGenericControl("li");
            li_order.InnerHtml = ds0.Tables[0].Rows[i][5].ToString();

            //show
            bool s = (bool)ds0.Tables[0].Rows[i][6];
            HtmlGenericControl li_show = new HtmlGenericControl("li");
            li_show.InnerHtml = s ? "آری" : "خیر";

            //edit

            HtmlGenericControl li_edit = new HtmlGenericControl("li");
            li_edit.Attributes["class"] = "edit";

            HtmlAnchor anc = new HtmlAnchor();
            anc.HRef = "~/admin/slide/alter_slide.aspx?id=" + ds0.Tables[0].Rows[i][0];
            anc.Attributes["target"] = "_blank";
            anc.Style["display"] = "block";
            anc.Style["height"] = "30px";
            li_edit.Controls.Add(anc);

            //del

            HtmlGenericControl li_del = new HtmlGenericControl("li");
            li_del.Attributes["class"] = "del";
            li_del.ID = ds0.Tables[0].Rows[i][0].ToString();
            Button li_de = new Button();
            li_de.Style["width"] = "100%";
            li_de.Style["height"] = "100%";
            li_de.Style["border"] = "0 none";
            li_de.Style["background"] = "url('../../images/icons/301.png') no-repeat 50%";
            li_de.Style["background-size"] = "100%";
            li_de.Style["cursor"] = "pointer";
            li_del.Controls.Add(li_de);
            li_de.Click += (object sender, EventArgs e) =>
            {
                SqlConnection con = new SqlConnection(ct);
                SqlCommand cmd = new SqlCommand("delete from slide where id =@betoche", con);

                cmd.Parameters.AddWithValue("@betoche", li_del.ID);

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



            ul.Controls.Add(li_pic);
            ul.Controls.Add(li_title);
            ul.Controls.Add(li_start);
            ul.Controls.Add(li_end);
            ul.Controls.Add(li_page);
            ul.Controls.Add(li_show);
            ul.Controls.Add(li_order);
            ul.Controls.Add(li_edit);
            ul.Controls.Add(li_del);
            
            grid.Controls.Add(ul);
        }
    }

}