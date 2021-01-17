using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for myFile
/// </summary>
public class myFile
{
    public myFile()
    {

    }

    public static string getFile(string inp,string folder)
    {
        //pic
        HttpPostedFile file = HttpContext.Current.Request.Files[inp];

        string fileName = "";
        string fileExt = "";

        if (file != null)
        {
            fileExt = Path.GetExtension(file.FileName).ToLower();
            if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".png")
            {
                fileName = Path.GetFileName(file.FileName);
                Random r = new Random();
                int ra = r.Next(0,100000);

                fileName = ra + fileName;
                file.SaveAs(HttpContext.Current.Server.MapPath("~/images/uploads/" + folder + "/full/") + fileName);
            }
        }
        return fileName;
    }
}