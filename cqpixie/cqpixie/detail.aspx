<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="cqpixie.detail" %>

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
        <%
            string title = "";
            string content = "";
            string tags = "";
            string imgurl = "";
            string type = Request.Params["type"];
            if (type == "page")
            {
                cqpixie.Model.page p = GetPage(Request.Params["title"]);
                title = p.title;
                content = p.content;
                imgurl = p.imgurl;

            }
            else if(type=="post")
            {
               cqpixie.BLL.Common.PostData pd = GetPost(Convert.ToInt32(Request.Params["id"]));
                title = pd.title;
                content = pd.content;
                tags = pd.tags;
                imgurl = pd.imgurl;
            }
        %>
<td width="13"></td>
      <td valign="top"><table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#c1d3e0" style="border-collapse:collapse">
        <tr>
          <td><div align="center">
              <table width="98%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><div align="left" class="h_zw12">您当前的位置：<a href="index.aspx">首页</a> &gt;&gt; <span class="h_lan12">详情</span></div></td>
                </tr>
              </table>
              <table width="98%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="40" background="images/spbpxc_r12_c25.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="2%">&nbsp;</td>
                        <td width="98%"><div align="left"><span class="h_l14"><%=title %></span></div></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td height="10"></td>
                </tr>
                <tr>
                  <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="2%">&nbsp;</td>
                      <td width="49%" valign="top" id="mainpic">
                          <div align="center">
                              <a href="<%=imgurl %>" target="_blank"><img src="<%=imgurl %>" width="350" height="309" border="1" /></a>
                          </div>
                          <div align="center">
                              <%
                                  string[] tagAry = tags.Split(',');
                                  for(int i = 0; i < tagAry.Length; i++)
                                  {
                              %>
                                    <img src="images/<%=tagAry[i] %>.jpg" />
                              <%
                                  }
                              %>
                          </div>
                      </td>
                        <script>
                            var t = "<%=type%>";
                            if (t == "page") {
                                document.getElementById("mainpic").style.display="none";
                            }
                        </script>
                      <td width="49%" valign="top">
                          <span class="h_lan12">
                            <%=content %>
                          </span>
                        </td>
                    </tr>
                  </table></td>
                </tr>
                <tr>
                  <td height="20">&nbsp;</td>
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
