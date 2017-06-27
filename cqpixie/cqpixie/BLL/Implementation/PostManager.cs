using cqpixie.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cqpixie.BLL.Common;
using cqpixie.Model;
using cqpixie.DAL.Interface;
using cqpixie.Common;
using cqpixie.DAL.Implementation;

namespace cqpixie.BLL.Implementation
{
    public class PostManager : IPostManager
    {
        private IRepository<post> _repository;

        public PostManager()
        {
            _repository = new Repository<post>();
        }
        public int AddPost(PostData data)
        {
            try
            {
                post p = new post();
                p.title = data.title;
                p.content = data.content;
                p.imgurl = data.imgurl;
                p.categoryid = (int)data.categoryid;
                p.tags = data.tags;
                p.editdate = DateTime.Now;
                
                p.editor = "admin";
                _repository.Insert(p);
                return p.id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeletePost(int id)
        {
            try
            {
                _repository.Delete(id);
                return id;
            }
            catch
            {
                return id;
            }
        }

        public PostData GetPost(PostData query)
        {
            var queryBuilder = QueryBuilder.Create<post>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
            }
            if (!string.IsNullOrEmpty(query.title))
            {
                queryBuilder = queryBuilder.Like(m => m.title, query.title);
            }
            if (!string.IsNullOrEmpty(query.editor))
            {
                queryBuilder = queryBuilder.Equals(m => m.editor, query.editor);
            }
            post p= _repository.Get(queryBuilder.Expression);
            PostData pd = new PostData()
            {
                title = p.title,
                content = p.content,
                imgurl =  p.imgurl,
                editor = p.editor,
                editdate = (DateTime)p.editdate,
                categoryid = p.categoryid,
                id = p.id,
                tags = p.tags
            };
            return pd;
        }

        public ListData GetPosts(PostData query)
        {
            var queryBuilder = QueryBuilder.Create<post>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
            }
            if (!string.IsNullOrEmpty(query.title))
            {
                queryBuilder = queryBuilder.Like(m => m.title, query.title);
            }
            if (!string.IsNullOrEmpty(query.editor))
            {
                queryBuilder = queryBuilder.Equals(m => m.editor, query.editor);
            }
            if (query.categoryid != null)
            {
                queryBuilder = queryBuilder.Equals(m=>m.categoryid, query.categoryid);
            }
            if (!string.IsNullOrEmpty(query.tags))
            {
                queryBuilder = queryBuilder.Like(m => m.tags, query.tags);
            }

            var data = _repository.GetList(queryBuilder.Expression, o => o.OrderByDescending(m => m.editdate));
            int countTotal = data.Count();
            int countFiltered = 0;
            if (countTotal > 0 && query.PageSize > 0)
            {
                data = _repository.GetList(queryBuilder.Expression)
                     .OrderByDescending(a => a.editdate)
                     .Skip(query.PageIndex * query.PageSize)
                     .Take(query.PageSize);
            }
            countFiltered = data.Count();
            List<PostData> pd = new List<PostData>();
            foreach (post p in data)
            {
                pd.Add(new PostData
                {
                    title = p.title,
                    content = p.content,
                    imgurl = p.imgurl,
                    editor = p.editor,
                    editdate = (DateTime)p.editdate,
                    categoryid = p.categoryid,
                    id = p.id,
                    tags = p.tags
                });
            }
            return new ListData
            {
                PageIndex = query.PageIndex,
                CountTotal = countTotal,
                CountFiltered = countFiltered,
                DataList = pd
            };
        }

        public int UpdatePost(PostData data)
        {
            post p = new post();
            p.title = data.title;
            p.content = data.content;
            p.imgurl = data.imgurl;
            p.tags = data.tags;
            p.editdate = DateTime.Now;
            p.editor = "admin";
            p.id = (int)data.id;
            p.categoryid = (int) data.categoryid;
            try
            {
                _repository.Update(p);
                return p.id;
            }
            catch
            {
                return -1;
            }
        }
    }
}