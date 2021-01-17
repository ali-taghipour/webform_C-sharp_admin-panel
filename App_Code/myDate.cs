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

    public static int get_date()
    {
        // calender

        DateTime mil = DateTime.Today;

        PersianCalendar shamsi = new PersianCalendar();

        int year = shamsi.GetYear(mil);
        int month = shamsi.GetMonth(mil);
        int day = shamsi.GetDayOfMonth(mil);

        int sham = year * 10000 + month * 100 + day;

        return sham;
    }
}