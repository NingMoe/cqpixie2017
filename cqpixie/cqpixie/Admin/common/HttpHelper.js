var HttpHelper = {
	httpAjax:function(action,param,callback){
		try {
            $.ajax({
                type: "POST",
                // url: 'http://127.0.0.1:9001/1.html?code=' + param.arg,
                //SETURL
                url: "http://localhost:32030/SL/AjaxCallHandler.ashx?action="+action,
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(param),
                success: function (ret) {
                    // console.log(ret);
                    callback(ret);
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
        } catch (e) {
            
        }		
	},
	httpGetValueInUrl:function(url,param){  
        var paraString = url.substring(url.indexOf("?")+1,url.length).split("&");   
        var paraObj = {}   
        for (i=0; j=paraString[i]; i++){   
            paraObj[j.substring(0,j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=")+1,j.length);   
        }   
        var returnValue = paraObj[param.toLowerCase()];   
        if(typeof(returnValue)=="undefined"){   
            return "";   
        }else{   
            return returnValue;   
        }	
	}
};