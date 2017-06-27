using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cqpixie
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }

        }

        public string getlatest()
        {
            PostData pd = new PostData()
            {
                PageIndex = 0,
                PageSize = 3
            };
            PostManager pm = new PostManager();
            ListData ld = pm.GetPosts(pd);
            IEnumerable<PostData> posts = ld.DataList as IEnumerable<PostData>;
            string htmlPics = "<tr>";
            string htmlNames = "<tr>";
            int count = 0;
            foreach(PostData p in posts)
            {
                htmlPics += "<td width=\"154\"><a href=\"detail.aspx?type=post&id=" + p.id + "\"><img src=\"" + p.imgurl + "\" width=\"154\" height=\"131\" border=\"0\"/></a></td>";
                htmlNames += "<td height=\"25\"><a href=\"detail.aspx?type=post&id="+p.id+"\"><div align=\"center\" class=\"h_h12\">"+p.title+"</div></a></td>";
                if (count == posts.Count() - 1)
                {
                    htmlPics += "</tr>";
                    htmlNames += "</tr>";
                }
                count++;
            }
           
            return htmlPics+htmlNames;
        }

        public string getcertificates()
        {
            string htmlPics = "<tr>";
            string htmlNames = "<tr>";
            string titles = ConfigurationManager.AppSettings["certificatesforhomepage"];
            string[] arytitle = titles.Split(',');
            PageData pd;
            PageManager pm = new PageManager();
            for(int i = 0; i < arytitle.Length; i++)
            {
                pd = new PageData()
                {
                    title = arytitle[i]
                };
                page p = pm.GetPage(pd);
                htmlPics += "<td width=\"154\"><a href=\"detail.aspx?type=page&id="+p.id+"\"><img src=\"" + p.imgurl + "\" width=\"154\" height=\"188\" border=\"0\"/></a></td>";
                htmlNames += "<td height=\"25\"><a href=\"detail.aspx?type=page&id="+p.id+"\"><div align=\"center\" class=\"h_h12\">" + p.title + "</div></a></td>";

            }
            htmlPics += "</tr>";
            htmlNames += "</tr>";
            return htmlPics + htmlNames;
        }
    }
}