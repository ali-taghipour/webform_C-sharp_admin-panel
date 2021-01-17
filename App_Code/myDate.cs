using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for myDate
/// </summary>
public class myDate
{
    public myDate()
    {

    }
    public static int getDate()
    {

        DateTime mil = DateTime.Today;

        PersianCalendar shamsi = new PersianCalendar();

        int y = shamsi.GetYear(mil);
        int m = shamsi.GetMonth(mil);
        int d = shamsi.GetDayOfMonth(mil);

        int sha = y * 10000 + m * 100 + d;

        return sha;
    }

}