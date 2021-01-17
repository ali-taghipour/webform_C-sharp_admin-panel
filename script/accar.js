function accar_tune(main,sub)
{
    li = $("#accardion > li").eq(main);
    li.addClass("sel");
    li.find(".content > a").eq(sub).addClass("sel");

}