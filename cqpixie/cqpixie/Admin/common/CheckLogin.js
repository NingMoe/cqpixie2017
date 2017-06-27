function getCookie(name)
{
  var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
  if(arr=document.cookie.match(reg))
    return unescape(arr[2]);
  else
    return null;
}

var checkLogin = function (){
    var username = getCookie("username");
    $.ajax({
        type: "POST",
        // url: 'http://127.0.0.1:9001/1.html?code=' + param.arg,
        //SETURL
        url: "http://localhost:32030/Admin/CheckLogin.ashx",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({"username":username}),
        success: function (ret) {
            if(ret=="ERROR"){
                location.href = "/Admin/login.aspx";
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            var Error = {
                xhr: xhr,
                ajaxOptions: ajaxOptions,
                thrownError: thrownError
            };
            callback(Error, null);
        },
        complete: function () {
            
        }
    });   
}

