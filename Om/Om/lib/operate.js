function operateButton()
{
    $.post("", {}, function (data)
    {    var strhtml="";
        if (data.code)
        {
            strhtml+="<span class=\"l\">";
            for (var i = 0; i < data.list.length; i++) {
                strhtml += "<a href=\"javascript:;\" onclick=\"" + data.list[i].event + "\" class=\"btn btn-danger radius\"><i class=\"Hui-iconfont\">" + data.list[i].icon + "</i> 批量删除</a> ";
            }
            strhtml+="</span>";
        }

    },"json"
    )
}
