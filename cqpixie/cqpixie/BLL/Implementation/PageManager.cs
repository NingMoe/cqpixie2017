using cqpixie.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cqpixie.DAL.Interface;
using cqpixie.DAL.Implementation;
using cqpixie.Model;
using cqpixie.BLL.Common;
using System.Linq.Expressions;
using cqpixie.Common;

namespace cqpixie.BLL.Implementation
{
    public class PageManager : IPageManager
    {
        private IRepository<page> _repository;

        public PageManager()
        {
            _repository = new Repository<page>();
        }
        public int AddPage(PageData data)
        {
            try
            {
                page p = new page();
                p.title = data.title;
                p.content = data.content;
                p.editdate = DateTime.Now;
                p.editor = "admin";
                p.imgurl = data.imgurl;
                _repository.Insert(p);
                return p.id;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int DeletePage(int id)
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

        public page GetPage(PageData query)
        {
            var queryBuilder = QueryBuilder.Create<page>();
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
            return _repository.Get(queryBuilder.Expression);
        }

        public ListData GetPages(PageData query)
        {
            var queryBuilder = QueryBuilder.Create<page>();
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

            var data = _repository.GetList(queryBuilder.Expression, o => o.OrderByDescending(m => m.editdate));
            int countTotal = data.Count();
            int countFiltered = 0;
            if(countTotal>0 && query.PageSize > 0)
            {
                data = _repository.GetList(queryBuilder.Expression)
                     .OrderByDescending(a => a.editdate)
                     .Skip(query.PageIndex * query.PageSize)
                     .Take(query.PageSize);
            }
            countFiltered = data.Count();
            return new ListData
            {
                PageIndex = query.PageIndex,
                CountTotal = countTotal,
                CountFiltered = countFiltered,
                DataList = data.ToList()
            };
        }

        public int UpdatePage(PageData data)
        {
            page p = new page();
            p.title = data.title;
            p.content = data.content;
            p.imgurl = data.imgurl;
            p.editdate = DateTime.Now;
            p.editor = "admin";
            p.id = (int) data.id;
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