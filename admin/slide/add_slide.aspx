<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_slide.aspx.cs" Inherits="slide_add_slide" %>

<%@ Register Src="~/controls/admin_accar.ascx" TagPrefix="uc1" TagName="admin_accar" %>


<!DOCTYPE html>

<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />

    <script>
        function validate_form() {

            //rules

            r1 = /^[\u0600-\u06ff]([\u0600-\u06ff]|\s|\d){3,20}$/;
            r2 = /^1(3|4)\d{2}\/\d{2}\/\d{2}$/;
            r3 = /^([1-9]|[1-9]\d)$/;

            f = 0;
            error.innerHTML = "";

            //  title

            if (!r1.test(sli_title.value)) {
                sli_title.parentNode.className = "items er";
                error.innerHTML = "عنوان نادرست است ..." + "</br>";
                f = 1;
            }
            else {
                sli_title.parentNode.className = "items ok";
            }
            // start 

            if (!r2.test(sli_start.value)) {
                sli_start.parentNode.className = "items er";
                error.innerHTML += "تاریخ شروع نادرست است . . ." + "</br>";
                f = 1;
            }
            else {
                sli_start.parentNode.className = "items ok";
            }

            // end 

            if (!r2.test(sli_end.value)) {
                sli_end.parentNode.className = "items er";
                error.innerHTML += "تاریخ پایان نادرست است . . ." + "</br>";
                f = 1;
            }
            else {
                sli_end.parentNode.className = "items ok";
            }

            // order 

            if (!r3.test(sli_order.value)) {
                sli_order.parentNode.className = "items s2 er";
                error.innerHTML += "اولویت نادرست است . . ." + "</br>";
                f = 1;
            }
            else {
                sli_order.parentNode.className = "items s2 ok";
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
                <div class="form">           
                    <h2> افزودن اسلایدها</h2>
                     <div id="error" runat="server"> </div>
                    <div class="items">
                        <span class="title"> عنوان اسلاید </span> 
                        <input type="text" id="sli_title" runat="server" placeholder="فارسی وارد شود ..."/>
                        <span class="error"></span> 
                    </div>
                    <div class="items s2">
                        <span class="title"> شروع نمایش </span> 
                        <input type="text" id="sli_start" runat="server" placeholder="فرمت تاریخ : 1397/06/10"/>
                        <span class="error"></span> 
                    </div>
                    <div class="items s2">
                        <span class="title"> پایان نمایش </span> 
                        <input type="text" id="sli_end" runat="server" placeholder="فرمت تاریخ : 1397/06/10"/>
                        <span class="error"></span> 
                    </div>
                    <div class="items">
                        <span class="title">  محل نمایش </span> 
                        <select type="text" id="sli_page" runat="server">
                            <option> صفحه اصلی </option>
                            <option> صفحه اخبار </option>
                            <option> صفحه کالاها </option>
                        </select>
                    </div>
                     <div class="items s1">
                        <span class="title"> اولویت </span> 
                        <input type="text" id="sli_order" runat="server" placeholder="1-99"/>
                        <span class="error"></span> 
                    </div>
                    <div class="items no_bg">
                        <span class="title"> وضعیت نمایش </span> 
                        <input type="radio" id="show" runat="server"  checked  name="r"/>
                        <label for="show">نمایش</label>
                       <input type="radio" id="hide" runat="server" name="r"/>
                        <label for="hide">عدم نمایش</label>
                    </div>
                    <div class="items">
                        <span class="title"> عکس اسلاید </span> 
                        <input type="file" id="sli_pic" runat="server"/>
                        <label for="sli_pic">آپلود</label>
                        <span class="error"></span> 
                </div>
                    <div class="items">
                        <span class="title"> توضیحات </span> 
                        <textarea id="sli_des" runat="server"></textarea>
                    </div>
                    <div class="items">          
                        <input type="submit" id="add" runat="server" value="افزودن" onserverclick="add_click"/>
                        <input type="submit" id="del" runat="server" value="پاک کردن"/>
                </div>
            </div>
        </div>
    </div>
</div>
    <div id="footer"> </div>
    </form>
</body>
</html>
