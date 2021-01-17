<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="admin_product_add_product" %>

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
    <div id="content">
        <div class="holder"> 
            <div class="right"> </div>
            <div class="center"> 
                <div class="form">           
                    <h2> افزودن کالاها</h2>
                     <div id="error"> خطا </div>
                    <div class="items">
                        <span class="title"> عنوان کالا </span> 
                        <input type="text" id="pr_title" runat="server" placeholder="فارسی وارد شود ..."/>
                        <span class="error"></span> 
                    </div>
                    <div class="items">
                        <span class="title">  دسته کالا </span> 
                        <select type="text" id="pr_cat" runat="server">
                            <option> دیجیتال </option>
                            <option> صفحه اخبار </option>
                            <option> صفحه کالاها </option>
                        </select>
                    </div>
                    <div class="items s2">
                        <span class="title"> قیمت کالا </span> 
                        <input type="text" id="pr_price" runat="server" placeholder="عدد وارد شود ..."/>
                        <span class="error"></span> 
                    </div>
                    <div class="items">
                        <span class="title">  برند کالا </span> 
                        <select type="text" id="pr_brand" runat="server">
                            <option> موتورلا </option>
                            <option> مارشال </option>
                            <option> بلک بری </option>
                        </select>
                    </div><div class="items no_bg">
                        <span class="title"> وضعیت موجودی </span> 
                        <input type="radio" id="show" runat="server"  checked  name="r"/>
                        <label for="show">موجود</label>
                       <input type="radio" id="hide" runat="server" name="r"/>
                        <label for="hide">ناموجود</label>
                    </div>
                    <div class="items s3">
                        <span class="title"> تعداد موجود در انبار </span> 
                        <input type="text" id="pr_anbar" runat="server" placeholder="عدد وارد شود ..."/>
                        <span class="error"></span> 
                    </div>
                    <div class="items">
                        <span class="title"> عکس کالا </span> 
                        <input type="file" id="pr_pic" runat="server"/>
                        <label for="sli_pic">آپلود</label>
                        <span class="error"></span> 
                    </div>
                    <div class="items">
                        <span class="title"> ویژگی ها </span> 
                        <textarea id="pr_attr"></textarea>
                    </div>
                    <div class="items">
                        <span class="title"> توضیحات </span> 
                        <textarea id="pr_des"></textarea>
                    </div>
                    <div class="items">          
                        <input type="submit" id="add" runat="server" value="افزودن"/>
                        <input type="submit" id="del" runat="server" value="پاک کردن"/>
                </div>
            </div>
        </div>
    </div>
    <div id="footer"> </div>
</body>
</html>
