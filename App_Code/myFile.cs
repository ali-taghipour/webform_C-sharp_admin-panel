using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

using System.Drawing;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for myFile
/// </summary>
public class myFile
{
    public myFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public static string my_file(string inp,string folder)
    {
        // file pic

        string fileExt = "";
        string fileName = "";

        HttpPostedFile picf = HttpContext.Current.Request.Files[inp];

        if (picf != null)
        {
            fileExt = Path.GetExtension(picf.FileName).ToLower();

            if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".png")
            {
                fileName = Path.GetFileName(picf.FileName);

                Random ra = new Random();

                int ran = ra.Next(0, 100000);
                fileName = ra + fileName;

                picf.SaveAs(HttpContext.Current.Server.MapPath("~/images/uploads/" + folder + "/full/" + fileName));

                Image im = Image.FromStream(picf.InputStream);

                float asp = (float)im.Size.Width / (float)im.Size.Height;

                int new_width = 150;
                int new_height = Convert.ToInt32(new_width / asp);

                Bitmap bm = my_resizeIm(im,new_width,new_height);
                bm.Save(HttpContext.Current.Server.MapPath("~/images/uploads/" + folder + "/thumbs/" + fileName));
            }
        }

        return fileName;
    }

    static Bitmap my_resizeIm(Image im,int new_width,int new_height)
    {
        Bitmap bm = new Bitmap(new_width, new_height);
        Graphics gr = Graphics.FromImage(bm);
        gr.DrawImage(im,0,0,new_width,new_height);

        return bm;
    }

    public static string hash(string ha)
    {
        MD5CryptoServiceProvider v = new MD5CryptoServiceProvider();
        byte[] m = Encoding.ASCII.GetBytes(ha);

        m = v.ComputeHash(m);

        string h = Encoding.ASCII.GetString(m);

        return h;
    }

}