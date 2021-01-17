<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alter_slide.aspx.cs" Inherits="admin_slide_alter_slide" %>

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

     <script>
        $(document).ready(function () {
            accar_tune(0,2)
        })
    </script>

</head>
<body>

    <form runat="server">

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
                <div class="form" id="form" runat="server">
                    <h2>ویرایش اسلاید </h2>

                    <div id="error" runat="server">خطا  </div>

                    <div class="items">
                        <img  id="sli_img" runat="server" src="../../images/uploads/slides/full/0.jpg" /> 

                    </div>


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
                        <input type="submit" value="بروزرسانی" id="add" runat="server" onserverclick="update_click" />
                        <input type="submit" value="حذف" id="del" runat="server" onserverclick="del_click" />
                    </div>

                </div>
            </div>
        </div>

    </div>
    <div id="footer"></div>

</form>

</body>
</html>