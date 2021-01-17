<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="controls_WebUserControl" %>

 <ul id="accardion">

                    <li>
                        <input id="ch1" type="checkbox" name="r">
                        <label for="ch1">مدیریت اسلایدها </label>

                        <div class="content">
                            <a runat="server" href="~/admin/slide/add_slide.aspx#form">افزودن آیتم </a>
                            <a runat="server" href="~/admin/slide/all_slides.aspx">مدیریت آیتم ها </a>
                            <a runat="server" href="~/admin/slide/alter_slide.aspx">تغییر و حذف </a>
                        </div>
                    </li>

                    <li>
                        <input id="ch2" type="checkbox" name="r">
                        <label for="ch2">مدیریت محصولات </label>

                        <div class="content">
                            <a href="#">افزودن آیتم </a>
                            <a href="#">مدیریت آیتم ها </a>
                            <a href="#">تغییر و حذف </a>
                        </div>
                    </li>

                    <li>
                        <input id="ch3" type="checkbox" name="r">
                        <label for="ch3">مدیریت اخبار </label>

                        <div class="content">
                            <a href="#">افزودن آیتم </a>
                            <a href="#">مدیریت آیتم ها </a>
                            <a href="#">تغییر و حذف </a>
                        </div>
                    </li>

                    <li>
                        <input id="ch4" type="checkbox" name="r">
                        <label for="ch4">مدیریت تبلیغات </label>

                        <div class="content">
                            <a runat="server" href="~/admin/slide/add_slide.aspx">افزودن آیتم </a>
                            <a href="#">مدیریت آیتم ها </a>
                            <a href="#">تغییر و حذف </a>
                        </div>
                    </li>

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