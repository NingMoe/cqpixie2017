using cqpixie.BLL.Common;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqpixie.BLL.Interface
{
   public interface IPostManager
    {
        int AddPost(PostData data);
        int UpdatePost(PostData data);
        int DeletePost(int id);
        PostData GetPost(PostData query);
        ListData GetPosts(PostData query);
    }
}
