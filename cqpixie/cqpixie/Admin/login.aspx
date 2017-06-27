<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="cqpixie.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .input-group{
        margin:10px 0px;//输入框上下外边距为10px,左右为0px
        }
        h3{
        padding:5px;
        border-bottom:1px solid #ddd;//h3字体下边框
        }
        li{
        list-style-type:square;//列表项图标为小正方形
        margin:10px 0;//上下外边距是10px
        }
        em{//强调的样式
        color:#c7254e;
        font-style: inherit;
        background-color: #f9f2f4;
        }
    </style>
        <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
        <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
        <script src="bootstrap/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="margin-top:30px;">
             <div class="col-md-4"></div>
             <div class="col-md-4">
                <div class="well col-md-10">
                <h4>重庆皮鞋后台 - 用户登录</h4>
                <div class="input-group input-group-md">
                <span class="input-group-addon" id="sizing-addon1"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                <input runat="server" type="text" id="username" class="form-control" placeholder="用户名" aria-describedby="sizing-addon1">
                </div>
                <div class="input-group input-group-md">
                <span class="input-group-addon" id="sizing-addon1"><i class="glyphicon glyphicon-lock"></i></span>
                <input runat="server" type="password" id="password" class="form-control" placeholder="密码" aria-describedby="sizing-addon1">
                </div>
                <button type="submit" class="btn btn-success btn-block">
                登录
                </button>
                </div>
             </div>
             <div class="col-md-4"></div>
        </div>
    </form>
</body>
</html>
