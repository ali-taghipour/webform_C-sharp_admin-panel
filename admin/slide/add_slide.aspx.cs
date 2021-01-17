using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Text.RegularExpressions;


public partial class admin_slide_add_slide : System.Web.UI.Page
{
    myData md = new myData();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void add_click(object sender, EventArgs e)
    {
        string role1 = @"^[\u0600-\u06ff]([\u0600-\u06ff]|\s|\d){2,5}";
        string role2 = @"^1(3|4)\d{2}\/\d{2}\/\d{2}$";
        string role3 = @"[1-9]|[1-9]\d";

        Match m1 = Regex.Match(sli_title.Value,role1);
        Match m2 = Regex.Match(sli_start.Value, role2);
        Match m3 = Regex.Match(sli_end.Value, role2);
        Match m4 = Regex.Match(sli_order.Value, role3);

        error.InnerHtml = "";

        int m = 0;

        if(!m1.Success)
        {
            error.InnerHtml += "you have made a mistake in title :) </b>";
            m = 1;
        }

        if (!m2.Success)
        {
            error.InnerHtml += "you have made a mistake in start date :) </b>";
            m = 1;
        }

        if (!m3.Success)
        {
            error.InnerHtml += "you have made a mistake in end date :) </b>";
            m = 1;
        }

        if (!m4.Success)
        {
            error.InnerHtml += "you have made a mistake in order :) </b>";
            m = 1;
        }

        if(m == 1)
        {
            return;
        }

        Dictionary<string, object> dic = new Dictionary<string, object>();

        dic.Add("@p1", sli_title.Value);
        dic.Add("@p2", sli_start.Value.Replace("/",""));
        dic.Add("@p3", sli_end.Value.Replace("/", ""));
        dic.Add("@p4", sli_page.Value);
        dic.Add("@p5", sli_order.Value);
        dic.Add("@p6", show.Checked);
        dic.Add("@p7", myFile.my_file("sli_pic","slides"));
        dic.Add("@p8", sli_des.Value);
        dic.Add("@p9", myDate.get_date());
        dic.Add("@p10", myDate.get_date());

        md.execuNonQuery("string","insert into slide values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", dic);

    }

    protected void reset_click(object sender, EventArgs e)
    {

    }
}