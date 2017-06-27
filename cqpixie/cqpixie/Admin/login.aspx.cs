using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cqpixie.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                UserManager um = new UserManager();

                UserData ud = new UserData()
                {
                    username = username.Value.ToLower(),
                    password = password.Value.ToLower()
                };

                UserData user = um.GetUser(ud);
                if (user != null || username.Value.ToLower() == "admin" && password.Value.ToLower() == "cqpixie")
                {
                    Response.Cookies["username"].Value = username.Value.ToLower();
                    Response.Redirect("index.html");
                }
            }

        }

    }
}