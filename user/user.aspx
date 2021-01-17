<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user_user" %>


<!DOCTYPE html>

<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <link href="../../style/header.css" rel="stylesheet" />
    <link href="../style/dash.css" rel="stylesheet" />
</head>
<body>
    <div id="header">
        <div class="top">
            <div class="holder">
                <a href="admin.aspx" class="home">
                    <img src="../images/icons/308g.png" /></a>
                <img src="../images/icons/275g.png" id="user_img" runat="server" />
                <h2>پنل کاربر</h2>
                <h2 class="wel">خوش آمدید <span id="wel" runat="server">حامد</span></h2>
            </div>
        </div>
    </div>
    <div id="content">
        <div class="holder">
            <div class="right">
                <ul id="accardion">


                    <li>
                        <input id="ch5" type="checkbox" name="r">
                        <label for="ch5">مدیریت پیام ها </label>

                        <div class="content">
                            <a href="#">افزودن آیتم </a>
                            <a href="#">مدیریت آیتم ها </a>
                            <a href="#">تغییر و حذف </a>
                        </div>
                    </li>



                </ul>
            </div>
            <div class="center">
                <div class="form">
                    <h2>داشبورد</h2>
                    <div class="dash">



                        <div class="items">
                            <div class="header">
                                <span class="pic"></span>
                                <h2>کالاها</h2>
                                <a href="#">افزودن کالا</a>
                                <a href="#">مشاهده کالاها</a>
                            </div>
                        </div>


                    </div>


                </div>
            </div>
        </div>
    </div>
    <div id="footer"></div>
</body>
</html>

