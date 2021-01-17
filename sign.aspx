<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="sign" %>

<!DOCTYPE html>

<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <link href="style/sign.css" rel="stylesheet" />

    <script>
        function validate_form() {
            //rules

            r1 = /^.{8,}$/;
            r2 = /[A-Z]/;
            r3 = /\d/;

            f = 0;
            error.innerHTML = "";

            if (!r1.test(sign_pass.value) || !r2.test(sign_pass.value) || !r3.test(sign_pass.value)) {
                sign_pass.parentNode.className = "items er";
                error.innerHTML += "فرمت نادرست است ..." + "</br>";
                f = 1;
            }
            else {
                sign_pass.parentNode.className = "items ok";
            }

            if (sign_pass.value != sign_repass.value) {
                sign_repass.parentNode.className = "items er";
                error.innerHTML += "به هم نمی خورند ...";
                f = 1;
            }
            else {
                sign_repass.parentNode.className = "items ok";
            }
            if (f == 0) {
                return true;
            }
            else if (f == 1) {
                return false;
            }

        }
    </script>

</head>
<body>

    <form runat="server" onsubmit="return validate_form()">

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
