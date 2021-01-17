<%@ Page Language="C#" AutoEventWireup="true" CodeFile="all_slides.aspx.cs" Inherits="slide_all_slides" %>

<%@ Register Src="~/controls/admin_accar.ascx" TagPrefix="uc1" TagName="admin_accar" %>


<!DOCTYPE html>

<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <link href="../../style/row grid.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server">
    <div id="header"> 
        <div class="top">
            <div class="holder"> </div>
        </div>
    </div>
    <div id="content">
        <div class="holder"> 
            <div class="right"> 
                <uc1:admin_accar runat="server" ID="admin_accar" />
            </div>
            <div class="center"> 
                <div class="grid" id="grid" runat="server">           
                    <h2> مشاهده  اسلایدها</h2>
                    <ul class="items header">
                        <li> عنوان </li>
                        <li class="date"> شروع </li>
                        <li class="date"> پایان </li>
                        <li> صفحه </li>
                        <li> وضعیت </li>
                        <li> اولویت </li>
                        <li> ویرایش </li>
                    </ul>
                    <%--<ul class="items">
                        <li class="pic"> <img src="../../images/icons/223.png" /> </li>
                        <li> فروش بهاره </li>
                        <li class="date"> 1397/06/10 </li>
                        <li class="date"> 1397/06/11 </li>
                        <li> اصلی </li>
                        <li> آری </li>
                        <li> 16 </li>

                        <li class="edit">  </li>
                        <li class="del">  </li>
                    </ul>--%>
                </div>
            </div>
        </div>
    </div>
    <div id="footer"> </div> 
    </form>
</body>
</html>
