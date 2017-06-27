using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using cqpixie.DAL;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cqpixie
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PageManager p = new PageManager();
            PageData data = new PageData();
            data.title = TextBox2.Text;
            data.content = TextBox3.Text;
            data.imgurl = "sfsdf";
            int id = p.AddPage(data);
            TextBox1.Text = id.ToString() ;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PageManager p = new PageManager();
            PageData data = new PageData();
            data.id = Convert.ToInt32(TextBox1.Text);
            data.title = TextBox2.Text;
            data.content = TextBox3.Text;
            p.UpdatePage(data);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PageManager p = new PageManager();
            p.DeletePage(Convert.ToInt32(TextBox1.Text));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PageManager p = new PageManager();
            PageData data = new PageData();
            data.title = "tit";
            data.PageIndex = 1;
            data.PageSize = 2;
            data.imgurl = "xxx";
            ListData list = p.GetPages(data);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            PageManager p = new PageManager();
            PageData data = new PageData();
            data.id = Convert.ToInt32(TextBox4.Text);

            page list = p.GetPage(data);
            Response.Write(list.title);
        }
    }
}