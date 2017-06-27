<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="cqpixie.list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>重庆沙坪坝皮鞋厂有限公司</title>
    <style type="text/css">
    <!--
    body {
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
    }
    -->
    </style>
    <link href="style/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div align="center">
  <!--#include file="header.aspx" -->
  <table width="1010" border="0" cellspacing="0" cellpadding="0">
    <tr>
       <!--#include file="left.aspx" -->
      <td width="13"></td>
      <td valign="top"><table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#c1d3e0" style="border-collapse:collapse">
        <tr>
          <td><div align="center">
              <table width="98%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><div align="left" class="h_zw12">您当前的位置：<a href="index.aspx">首页</a> &gt;&gt; <span class="h_lan12">产品展示列表</span></div></td>
                </tr>
              </table>
              <table width="98%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="40" background="images/spbpxc_r12_c25.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="2%">&nbsp;</td>
                        <td width="98%"><div align="left"><span class="h_l14">产品列表</span></div></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td height="10"></td>
                </tr>
                <tr>
                  <td>
                      <%
                          string fun = Request.Params["fun"];
                          string keyword = Request.Params["keyword"];
                          int categoryid = Convert.ToInt32(Request.Params["id"]);
                          int pageindex = 0;
                          if (!String.IsNullOrEmpty(Request.Params["pageindex"]))
                          {
                              pageindex = Convert.ToInt32(Request.Params["pageindex"]);
                          }

                           %>
                      <% 
                          cqpixie.PageInfo pi = GetList(categoryid,fun, keyword,pageindex,12);
                          string html = pi.html;
                          decimal pagecount = pi.pagecount;
                          //int pageindex = pi.pageindex;
                      %>
                      <%=html %>
                    <table width="100%" height="30" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><div align="center" class="h_h12">共<%=pagecount %>页 当前<%=pageindex+1 %>页 
                            <a href="list.aspx?id=<%=categoryid %>&pageindex=0&fun=<%=fun%>&keyword=<%=keyword%>">首页</a> 
                            <a href="list.aspx?id=<%=categoryid %>&pageindex=<%=(pageindex>1)?pageindex-1:0 %>&fun=<%=fun%>&keyword=<%=keyword%>">上一页</a> 
                            <a href="list.aspx?id=<%=categoryid %>&pageindex=<%=(pageindex<pagecount-1)?pageindex+1:pagecount-1 %>&fun=<%=fun%>&keyword=<%=keyword%>">下一页</a> 
                            <a href="list.aspx?id=<%=categoryid %>&pageindex=<%=pagecount-1 %>&fun=<%=fun%>&keyword=<%=keyword%>">末页</a> 跳转到 
                          <input name="textfield2" id="textfield2" type="text" size="1" />
                          页 
                          <input type="button" value="Go" onclick="jump()"/>
                        </div></td>
                      </tr>
                    </table>
                      <script>
                          function jump() {
                              
                              var page = parseInt(document.getElementById("textfield2").value);
                              var pagecount = <%=pagecount%>;
                              if(page<=pagecount){
                                  if(page>0){
                                      var index = page -1;
                                      location.href = "list.aspx?id=<%=categoryid%>&pageindex="+index+"&fun=<%=fun%>&keyword=<%=keyword%>";
                                  }
                              }
                              
                          }
                      </script>
                  </td>
                </tr>
                <tr>
                  <td height="20"></td>
                </tr>
              </table>
            </div></td>
        </tr>
      </table></td>
      <td width="5"></td>

    </tr>
  </table>
  <!--#include file="footer.aspx" -->
</div>
    </form>
</body>
</html>
