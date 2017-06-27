using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cqpixie.BLL.Common
{
    public class PageData:BaseData
    {
        public int? id;
        public string title;
        public string content;
        public string imgurl;
        public string editor;
        public DateTime editdate;

    }

    public class PostData : BaseData
    {
        public int? id;
        public string title;
        public string content;
        public string imgurl;
        public string editor;
        public DateTime editdate;
        public int? categoryid;
        public string categoryname;
        public string tags;
    }

    public class CategoryData : BaseData
    {
        public int? id;
        public string categoryname;
        public string description;
        public string editor;
        public DateTime editdate;
    }

    public class UserData : BaseData
    {
        public int? id;
        public string username;
        public string password;
        public string editor;
        public DateTime editdate;
    }
    public class BaseData
    {
        public int PageSize;
        public int PageIndex;

    }

    public class ListData
    {
        public int PageIndex { get; set; }
        public int CountTotal { get; set; }
        public int CountFiltered { get; set; }
        public object DataList { get; set; }
    }
}