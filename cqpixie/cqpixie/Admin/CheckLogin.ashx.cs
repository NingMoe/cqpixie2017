using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cqpixie.Admin
{
    /// <summary>
    /// Summary description for CheckLogin
    /// </summary>
    public class CheckLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string username = context.Request["username"];
            if(username !="")
            {
                context.Response.Write("OK");
            }
            else
            {
                context.Response.Write("ERROR");

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}