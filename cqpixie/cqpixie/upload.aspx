<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="cqpixie.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="./PlugIn/plupload-2.3.1/js/plupload.full.min.js"></script>
</head>
<body>
    <p>
        <button id="browse">选择文件</button>
        <button id="start_upload">开始上传</button>
    </p>
    <script>
    //实例化一个plupload上传对象
    var uploader = new plupload.Uploader({
        browse_button : 'browse', //触发文件选择对话框的按钮，为那个元素id
        url : '/Common/PlugIn/Uploader.ashx', //服务器端的上传页面地址
        flash_swf_url: './PlugIn/plupload-2.3.1/js/Moxie.swf', //swf文件，当需要使用swf方式进行上传时需要配置该参数
        silverlight_xap_url: './PlugIn/plupload-2.3.1/js/Moxie.xap' //silverlight文件，当需要使用silverlight方式进行上传时需要配置该参数
    });    

    //在实例对象上调用init()方法进行初始化
    uploader.init();

    //绑定各种事件，并在事件监听函数中做你想做的事
    uploader.bind('FileUploaded', function (uploader, file, responseObject) {
        alert(responseObject.response);
    });

    uploader.bind('FilesAdded', function (uploader, files) {
        alert(files[0].name);
    });

    //最后给"开始上传"按钮注册事件
    document.getElementById('start_upload').onclick = function(){
        uploader.start(); //调用实例对象的start()方法开始上传文件，当然你也可以在其他地方调用该方法
    }
    </script>
</body>
</html>
