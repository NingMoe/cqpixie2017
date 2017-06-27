      <td width="5"></td>
      <td width="200" valign="top">
          <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#d6d6d6" style="border-collapse:collapse">
        <tr>
          <td height="44" bgcolor="#f1faff"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="13%">&nbsp;</td>
              <td width="87%"><div align="left" class="h_l14">产品分类</div></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td height="44"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="13%">&nbsp;</td>
              <td width="87%"><div align="left" class="h_l14"><a href="list.aspx?id=11" class="h_ch12">&gt;&gt; 低帮安全防护鞋 </a></div></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td height="44"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="13%">&nbsp;</td>
              <td width="87%"><div align="left" class="h_l14"><a href="list.aspx?id=12" class="h_ch12">&gt;&gt; 高腰安全防护鞋 </a></div></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td height="44"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="13%">&nbsp;</td>
              <td width="87%"><div align="left" class="h_l14"><a href="list.aspx?id=13" class="h_ch12">&gt;&gt; 长筒安全防护鞋</a></div></td>
            </tr>
          </table></td>
        </tr>
      </table>
          <table cellpadding="0" cellspacing="0">
              <tr>
                  <td height="20"></td>
              </tr>
          </table>
<table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#d6d6d6" style="border-collapse:collapse">
        <tr>
          <td height="44" bgcolor="#f1faff"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="13%">&nbsp;</td>
              <td width="87%"><div align="left" class="h_l14">产品搜索</div></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td height="44" align="center">
                    <select name="fun" id="fun" style="width:145px">
                      <option value="">--选择功能--</option>
                      <option value="保护足趾">保护足趾</option>
                      <option value="防刺穿">防刺穿</option>
                      <option value="防静电">防静电</option>
                      <option value="电绝缘">电绝缘</option>
                      <option value="耐油">耐油</option>
                      <option value="耐酸碱">耐酸碱</option>
                      <option value="防寒">防寒</option>
                      <option value="耐高温">耐高温</option>
                      <option value="导电">导电</option>
                    </select>
          </td>
        </tr>
        <tr>
          <td height="44" align="center" valign="middle">
              <input type="text" id="keyword" style="width:90px"/> &nbsp;&nbsp;<input type="button" value="GO" onclick="search()"/>
          </td>
            <script>
                function search() {
                    var fun = document.getElementById("fun");
                    var i = fun.selectedIndex;
                    var v = fun.options[i].value;
                    var keyword = document.getElementById("keyword").value;
                    location.href = "list.aspx?fun=" + v + "&keyword=" + keyword;
                }
            </script>
        </tr>
      </table>        
      </td>