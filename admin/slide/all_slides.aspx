<%@ Page Language="C#" AutoEventWireup="true" CodeFile="all_slides.aspx.cs" Inherits="admin_slide_all_slides" %>

<%@ Register Src="~/controls/WebUserControl.ascx" TagPrefix="uc1" TagName="WebUserControl" %>


<!DOCTYPE html>

<html>
<head>

    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2 panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <link href="../../style/row grid.css" rel="stylesheet" />
    <link href="../../style/responsive.css" rel="stylesheet" />
    <script src="../../script/jquery.js"></script>
    <script src="../../script/accar.js"></script>

    <script>
        $(document).ready(function () {
            accar_tune(0,1)
        })
    </script>

</head>
<body>
    <form runat="server">

    <div id="header"></div>

    <div id="content">

        <div class="holder">
            <div class="right">
                <uc1:WebUserControl runat="server" ID="WebUserControl" />
            </div>
            <div class="center">

                <div class="grid" id="grid" runat="server">

                    <h2>مشاهده اسلایدها  </h2>

                    <ul class="items header">
                        <li>عنوان</li>
                        <li class="date">شروع</li>
                        <li class="date">پایان</li>
                        <li>صفحه</li>
                        <li>وضعیت</li>
                        <li>اولویت</li>

                        <li>ویرایش </li>
                    </ul>

                  <%--  <ul class="items">
                        <li class="pic">
                            <img src="../../images/icons/223.png" />
                        </li>
                        <li>فروش بهاره</li>
                        <li class="date">1395/07/02</li>
                        <li class="date">1395/07/02</li>
                        <li>اصلی</li>
                        <li>آری</li>
                        <li>20</li>

                        <li class="edit"></li>
                        <li class="del"></li>

                    </ul>
                      
                      --%>

                </div>

            </div>
        </div>

    </div>

    <div id="footer"></div>
    </form>
</body>
</html>
