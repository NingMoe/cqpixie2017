using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cqpixie
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public PageInfo GetList(int categoryId, string fun, string keyword, int pageIndex=0, int pageSize=12)
        {
            int? tempId;
            if(categoryId == 0)
            {
                tempId = null;
            }
            else
            {
                tempId = categoryId;
            }
            PostData pd = new PostData()
            {
                categoryid = tempId,
                tags = fun,
                title = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            PostManager pm = new PostManager();
            ListData ld = pm.GetPosts(pd);
            IEnumerable<PostData> list = ld.DataList as IEnumerable<PostData>;
            int count = 0;
            string htmlTotal = "";
            string htmlPics = "";
            string htmlTitles = "";
            foreach (PostData p in list)
            {
                if (count % 4 == 0)
                {
                    htmlTotal += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    htmlPics += "<tr>";
                    htmlTitles += "<tr>";
                }
                htmlPics += "<td width=\"25%\"><div align=\"center\"><a href=\"detail.aspx?type=post&id="+p.id+"\"><img name=\"spbpxc_r20_c11\" src=\""+p.imgurl+"\" width=\"154\" height=\"131\" border=\"0\" id=\"spbpxc_r20_c11\" alt=\"\" /></a></div></td>";
                htmlTitles += "<td height=\"35\" class=\"h_lan12\"><a href=\"detail.aspx?type=post&id=" + p.id + "\"><div align=\"center\">" + p.title+"</div></a></td>";
                if (count % 4 == 3 || count == list.Count()-1)
                {
                    htmlPics += "</tr>";
                    htmlTitles += "</tr>";
                    htmlTotal = htmlTotal + htmlPics + htmlTitles;
                    htmlTotal += "</table>";
                    htmlPics = "";
                    htmlTitles = "";
                }
                count++;
            }

            return new PageInfo {
                html = htmlTotal,
                pageindex = ld.PageIndex + 1,
                pagecount = Math.Ceiling(Convert.ToDecimal(ld.CountTotal) / Convert.ToDecimal(pageSize))
            };
        }
    }

    public class PageInfo
    {
        public string html;
        public decimal pagecount;
        public int pageindex;
    }
}