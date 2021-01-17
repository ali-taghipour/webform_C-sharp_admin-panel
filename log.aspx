<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log.aspx.cs" Inherits="log" %>

<!DOCTYPE html>

<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <link href="style/sign.css" rel="stylesheet" />
</head>
<body>

    <form runat="server">

        <div id="header"></div>

        <div id="content">

            <div class="holder">

                <div class="center">

                    <div class="form">

                        <h2>ورود</h2>

                        <img class="logo" src="images/icons/314o.png" />

                        <div id="error" runat="server"></div>

                        <div class="items">
                            <span class="title">نام کاربری</span>
                            <input type="text" id="log_uname" runat="server" placeholder="انگلیسی وارد شود . . ." />
                            <span class="error"></span>
                        </div>

                        <div class="items">
                            <span class="title">رمز ورود</span>
                            <input type="password" id="log_pass" runat="server" placeholder="حداقل به طول 8 . . ." />
                            <span class="error"></span>
                        </div>

                        <div class="items">
                            <input type="submit" value="ورود" runat="server" onserverclick="log_click" />
                        </div>

                        <a href="sign.aspx">ثبت نام </a>
                    </div>

                </div>
            </div>

        </div>

        <div id="footer"></div>

    </form>
</body>
</html>
