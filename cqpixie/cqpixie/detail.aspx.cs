using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cqpixie
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public page GetPage(string title)
        {

            PageData pd = new PageData()
            {
                title = title
            };
            PageManager pm = new PageManager();
            page p = pm.GetPage(pd);
            return p;
 
        }
        public PostData GetPost(int id)
        {

            PostData pd = new PostData()
            {
                id = id
            };
            PostManager pm = new PostManager();
            PostData p = pm.GetPost(pd);
            return p;

        }
    }
}