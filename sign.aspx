<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="sign" %>

<!DOCTYPE html>

<html>
<head>
    <link href="style/fonts.css" rel="stylesheet" />
    <link href="style/base.css" rel="stylesheet" />
    <link href="style/2 panel.css" rel="stylesheet" />
    <link href="style/form.css" rel="stylesheet" />
    <link href="style/accardion.css" rel="stylesheet" />
    <link href="style/sign.css" rel="stylesheet" />

</head>
<body>

    <form runat="server">

        <div id="header"></div>

        <div id="content">

            <div class="holder">

                <div class="center">

                    <div class="form">

                        <h2>ثبت نام  </h2>

                        <img class="logo" src="images/icons/275o.png" />

                        <div id="error" runat="server"></div>

                        <div class="items">
                            <span class="title">نام کاربری</span>
                            <input type="text" id="sign_uname" runat="server" placeholder="انگلیسی وارد شود . . ." />
                            <span class="error"></span>
                        </div>

                        <div class="items">
                            <span class="title">رمز ورود</span>
                            <input type="password" id="sign_pass" runat="server" placeholder="حداقل به طول 8 . . ." />
                            <span class="error"></span>
                        </div>

                        <div class="items">
                            <span class="title">تکرار رمز</span>
                            <input type="password" id="sign_repass" runat="server" placeholder="حداقل به طول 8 . . ." />
                            <span class="error"></span>
                        </div>


                        <div class="items">
                            <input type="submit" value="ثبت نام" runat="server" onserverclick="sign_click" />
                        </div>

                        <a href="log.aspx">ورود </a>

                    </div>

                </div>
            </div>

        </div>

        <div id="footer"></div>

    </form>

</body>

</html>
