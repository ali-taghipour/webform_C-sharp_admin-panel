<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alter_slide.aspx.cs" Inherits="slide_alter_slide" %>

<%@ Register Src="~/controls/admin_accar.ascx" TagPrefix="uc1" TagName="admin_accar" %>


<!DOCTYPE html>


<html>
<head>
    <link href="../../style/fonts.css" rel="stylesheet" />
    <link href="../../style/base.css" rel="stylesheet" />
    <link href="../../style/2%20panel.css" rel="stylesheet" />
    <link href="../../style/form.css" rel="stylesheet" />
    <link href="../../style/accardion.css" rel="stylesheet" />
</head>
<body>
    
    <div id="header"> 
        <div class="top">
            <div class="holder"> </div>
        </div>
    </div>
    <form id="bang" runat="server">
    <div id="content">
        <div class="holder"> 
            <div class="right"> 
                <uc1:admin_accar runat="server" ID="admin_accar" />
            </div>
            <div class="center"> 
                <div class="form" id="form" runat="server">           
                    <h2> ویرایش اسلایدها</h2>

                    <div id="error" runat="server"> خطا </div>
                    <div class="items"> <img id="sli_img" runat="server" src="../../images/uploads/slides/full/4545.jpg" /> </div>
                     
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
                        <input type="submit" id="add" runat="server" value="بروز رسانی" onserverclick="update"/>
                        <input type="submit" id="del" runat="server" value="پاک کردن" onserverclick="del_click"/>
                </div>
            </div>
        </div>
    </div>
   </div>
    </form>
    <div id="footer"> </div>
</body>
</html>

