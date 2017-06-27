using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace cqpixie.Common.PlugIn
{
    /// <summary>
    /// Summary description for Uploader
    /// </summary>
    public class Uploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UploadFile(context);
        }
        public void UploadFile(HttpContext context)
        {
            context.Response.CacheControl = "no-cache";

            string Datedir = DateTime.Now.ToString("yy-MM-dd");

            if (context.Request.Files.Count > 0)
            {
                try
                {
                    for (int j = 0; j < context.Request.Files.Count; j++)
                    {
                        HttpPostedFile uploadFile = context.Request.Files[j];      
                        if (uploadFile.ContentLength > 0)
                        {
                            string extname = Path.GetExtension(uploadFile.FileName);
                            string fullname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            string filename = uploadFile.FileName;
                            string filepath = context.Server.MapPath(@"~/Uploads/" + fullname + extname);
                            uploadFile.SaveAs(filepath);
                            context.Response.Write("/Uploads/" + fullname + extname);
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("error");
                }

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