<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_slide.aspx.cs" Inherits="admin_slide_add_slide" %>

<%@ Register Src="~/controls/WebUserControl.ascx" TagPrefix="uc1" TagName="WebUserControl" %>


<!DOCTYPE html>

<html>
<head>

    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2 panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
    <script src="../../script/jquery.js"></script>
    <script src="../../script/accar.js"></script>
    <link href="../../style/responsive.css" rel="stylesheet" />

    <script>
        function validate_form()
        {
            role1 = /^[\u0600-\u06ff]([\u0600-\u06ff]|\s|\d){2,5}/;
            role2 = /^1(3|4)\d{2}\/\d{2}\/\d{2}$/;
            role3 = /[1-9]|[1-9]\d/;
        
            f = 0;

            error.innerHTML = "";

            if (!role1.test(sli_title.value))
            {
                error.innerHTML += "you have made a mistake in title</br>"
                f = 1;
            }

            if (!role2.test(sli_start.value))
            {
                error.innerHTML += "you have made a mistake in start date</br>"
                f = 1;
            }

            if (!role2.test(sli_end.value))
            {
                error.innerHTML += "you have made a mistake in end dete</br>"
                f = 1;
            }

            if (!role3.test(sli_order.value))
            {
                error.innerHTML += "you have made a mistake in order"; 
            }


            if (f == 1)
            {
                return false;
            }

            else if(f == 0){
                return true;
            }
        }

        $(document).ready(function () {
            accar_tune(0,0);
        });
    </script>

</head>
<body>

<form runat="server" onsubmit="return validate_form()">

    <div id="header">
        <div class="top">

            <div class="holder"></div>

        </div>

    </div>
    <div id="content">

        <div class="holder">

            <div class="right">
                <uc1:WebUserControl runat="server" ID="WebUserControl" />
            </div>

            <div class="center">

                <div id="form" class="form">
                    <h2>افزودن اسلاید </h2>

                    <div id="error" runat="server">      </div>

                    <div class="items">
                        <span class="title">عنوان اسلاید</span>
                        <input type="text" id="sli_title" runat="server" placeholder="فارسی وارد شود . . ." />
                        <span class="error"></span>
                    </div>

                    <div class="items s2">
                        <span class="title">شروع نمایش</span>
                        <input type="text" id="sli_start" runat="server" placeholder="فرمت تاریخ : 1395/05/02 . . ." />
                        <span class="error"></span>
                    </div>

                    <div class="items s2">
                        <span class="title">پایان نمایش</span>
                        <input type="text" id="sli_end" runat="server" placeholder="فرمت تاریخ : 1395/05/02 . . ." />
                        <span class="error"></span>
                    </div>

                    <div class="items">
                        <span class="title">محل نمایش</span>

                        <select id="sli_page" runat="server">
                            <option>صفحه اصلی </option>
                            <option>صفحه اخبار </option>
                            <option>صفحه کالاها </option>
                        </select>

                    </div>

                    <div class="items s1">
                        <span class="title">اولویت</span>
                        <input type="text" id="sli_order" runat="server" placeholder="1-99" />
                        <span class="error"></span>
                    </div>


                    <div class="items no_bg">
                        <span class="title">وضعیت نمایش</span>

                        <input type="radio" id="show" runat="server" checked name="r" />
                        <label for="show">نمایش </label>

                        <input type="radio" id="hide" runat="server" name="r" />
                        <label for="hide">عدم نمایش</label>
                    </div>


                    <div class="items">
                        <span class="title">عکس اسلایدها</span>

                        <input type="file" id="sli_pic" runat="server" />
                        <label for="sli_pic">آپلود </label>
                    </div>

                    <div class="items">
                        <span class="title">توضیحات</span>
                        <textarea id="sli_des" runat="server">    </textarea>
                    </div>

                    <div class="items">
                        <input type="submit" value="افزودن" id="add" runat="server" onserverclick="add_click" />
                        <input type="submit" value="پاک" id="del" runat="server" onserverclick="reset_click" />
                    </div>

                </div>
            </div>
        </div>

    </div>
    <div id="footer"></div>

</form>

</body>
</html>

