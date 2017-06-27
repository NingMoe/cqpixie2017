using cqpixie.BLL.Common;
using cqpixie.BLL.Implementation;
using cqpixie.Common.JSON;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace cqpixie.SL
{
    /// <summary>
    /// </summary>
    public class AjaxCallHandler : IHttpHandler
    {
        private CategoryManager _categoryManager;
        private PageManager _pageManager;
        private PostManager _postManager;
        private UserManager _userManager;

        public AjaxCallHandler()
        {
            _categoryManager = new CategoryManager();
            _pageManager = new PageManager();
            _postManager = new PostManager();
            _userManager = new UserManager();
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            //http://localhost:32030/SL/AjaxCallHandler.ashx?action= action is one of the below conditions in switch
            //e.g.http://localhost:32030/SL/AjaxCallHandler.ashx?action=getcategories

            string action = request.Params["action"];
            StreamReader sr = new StreamReader(request.InputStream);
            string jsonString = sr.ReadToEnd();
            string responseJson="";
            IEnumerable<CategoryData> cd;
            switch (action.ToLower())
            {
                case "getcategories":
                    #region getcategories
                    /*
                    post json
                    {
                        "PageSize":"10",
                        "PageIndex":"0"
                    }
                    */
                    responseJson = JSONHelper.ToJsonString(_categoryManager.GetCategories(JSONHelper.ToObject<CategoryData>(jsonString)));
                    break;
                #endregion
                case "getcategory":
                    #region getcategory
                    responseJson = JSONHelper.ToJsonString(_categoryManager.GetCategory(JSONHelper.ToObject<CategoryData>(jsonString)));
                    #endregion
                    break;
                case "addcategory":
                    #region addcategory
                    /*
                    post json
                    {
                        "categoryname":"xxxx",
                        "description":"aaaa"
                    }                       
                    */
                    #endregion
                    responseJson =JSONHelper.ToJsonString( _categoryManager.AddCategory(JSONHelper.ToObject<CategoryData>(jsonString)));
                    break;
                case "updatecategory":
                    #region updatecategory
                    responseJson = JSONHelper.ToJsonString(_categoryManager.UpdateCategory(JSONHelper.ToObject<CategoryData>(jsonString)));
                    #endregion
                    break;
                case "deletecategory":
                    #region deletecategory
                    responseJson = JSONHelper.ToJsonString(_categoryManager.DeleteCategory((int)JSONHelper.ToObject<CategoryData>(jsonString).id)); 
                    #endregion
                    break;
                case "getposts":
                    #region getposts
                    var postsTemp = _postManager.GetPosts(JSONHelper.ToObject<PostData>(jsonString));
                    cd = _categoryManager.GetCategories(new CategoryData()).DataList as IEnumerable<CategoryData>;
                    IEnumerable<PostData> posts = postsTemp.DataList as IEnumerable<PostData>;
                    foreach(PostData p in posts)
                    {
                        foreach(CategoryData c in cd)
                        {
                            if(p.categoryid == c.id)
                            {
                                p.categoryname = c.categoryname;
                            }
                        }
                    }
                    responseJson = JSONHelper.ToJsonString(postsTemp);
                    #endregion
                    break;
                case "getpost":
                    #region getpost
                    var post = _postManager.GetPost(JSONHelper.ToObject<PostData>(jsonString));
                    cd = _categoryManager.GetCategories(new CategoryData()).DataList as IEnumerable<CategoryData>;
                    foreach (CategoryData c in cd)
                    {
                        if(c.id == post.categoryid)
                        {
                            post.categoryname = c.categoryname;
                        }
                    }
                    responseJson = JSONHelper.ToJsonString(post);
                    #endregion
                    break;
                case "deletepost":
                    #region deletepost
                    responseJson = JSONHelper.ToJsonString(_postManager.DeletePost((int)JSONHelper.ToObject<PostData>(jsonString).id));
                    #endregion
                    break;
                case "updatepost":
                    #region updatepost
                    responseJson = JSONHelper.ToJsonString(_postManager.UpdatePost(JSONHelper.ToObject<PostData>(jsonString)));
                    #endregion
                    break;
                case "addpost":
                    #region addpost
                    responseJson = JSONHelper.ToJsonString(_postManager.AddPost(JSONHelper.ToObject<PostData>(jsonString)));
                    #endregion
                    break;
                case "getpages":
                    #region getpages
                    responseJson = JSONHelper.ToJsonString(_pageManager.GetPages(JSONHelper.ToObject<PageData>(jsonString)));
                    #endregion
                    break;
                case "getpage":
                    #region getpage
                    responseJson = JSONHelper.ToJsonString(_pageManager.GetPage(JSONHelper.ToObject<PageData>(jsonString)));
                    #endregion
                    break;
                case "deletepage":
                    #region deletepage
                    responseJson = JSONHelper.ToJsonString(_pageManager.DeletePage((int)JSONHelper.ToObject<PageData>(jsonString).id));
                    #endregion
                    break;
                case "updatepage":
                    #region updatepost
                    responseJson = JSONHelper.ToJsonString(_pageManager.UpdatePage(JSONHelper.ToObject<PageData>(jsonString)));
                    #endregion
                    break;
                case "addpage":
                    #region addpost
                    responseJson = JSONHelper.ToJsonString(_pageManager.AddPage(JSONHelper.ToObject<PageData>(jsonString)));
                    #endregion
                    break;
                case "adduser":
                    #region adduser
                    responseJson = JSONHelper.ToJsonString(_userManager.AddUser(JSONHelper.ToObject<UserData>(jsonString)));
                    #endregion
                    break;
                case "updateuser":
                    #region updateuser
                    responseJson = JSONHelper.ToJsonString(_userManager.UpdateUser(JSONHelper.ToObject<UserData>(jsonString)));
                    #endregion
                    break;
                case "getuser":
                    #region getuser
                    responseJson = JSONHelper.ToJsonString(_userManager.GetUser(JSONHelper.ToObject<UserData>(jsonString)));
                    #endregion
                    break;
                case "getusers":
                    #region getusers
                    responseJson = JSONHelper.ToJsonString(_userManager.GetUsers(JSONHelper.ToObject<UserData>(jsonString)));
                    #endregion
                    break;
                case "deleteuser":
                    #region deleteuser
                    responseJson = JSONHelper.ToJsonString(_userManager.DeleteUser((int)JSONHelper.ToObject<UserData>(jsonString).id));
                    #endregion
                    break;
            }
            context.Response.Write(responseJson);
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