using cqpixie.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cqpixie.BLL.Common;
using cqpixie.Model;
using cqpixie.DAL.Interface;
using cqpixie.DAL.Implementation;
using cqpixie.Common;

namespace cqpixie.BLL.Implementation
{
    public class CategoryManager : ICategoryManager
    {

        private IRepository<category> _repository;

        public CategoryManager()
        {
            _repository = new Repository<category>();
        }
        public int AddCategory(CategoryData data)
        {
            try
            {
                category p = new category();
                p.categoryname = data.categoryname;
                p.editdate = DateTime.Now;
                p.description = data.description;
                p.editor = "admin";
                _repository.Insert(p);
                return p.id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteCategory(int id)
        {
            try
            {
                _repository.Delete(id);
                return id;
            }
            catch
            {
                return -1;
            }
        }

        public ListData GetCategories(CategoryData query)
        {
            var queryBuilder = QueryBuilder.Create<category>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
            }
            if (!string.IsNullOrEmpty(query.categoryname))
            {
                queryBuilder = queryBuilder.Like(m => m.categoryname, query.categoryname);
            }
            if (!string.IsNullOrEmpty(query.editor))
            {
                queryBuilder = queryBuilder.Equals(m => m.editor, query.editor);
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
            List<CategoryData> cd = new List<CategoryData>();
            foreach(category c in data)
            {
                cd.Add(new CategoryData
                {
                    id = c.id,
                    categoryname = c.categoryname,
                    description = c.description,
                    editdate = (DateTime)c.editdate,
                    editor = c.editor
                });
            }
            return new ListData
            {
                PageIndex = query.PageIndex,
                CountTotal = countTotal,
                CountFiltered = countFiltered,
                DataList = cd
            };
        }

        public CategoryData GetCategory(CategoryData query)
        {
            var queryBuilder = QueryBuilder.Create<category>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
            }
            if (!string.IsNullOrEmpty(query.categoryname))
            {
                queryBuilder = queryBuilder.Like(m => m.categoryname, query.categoryname);
            }
            if (!string.IsNullOrEmpty(query.editor))
            {
                queryBuilder = queryBuilder.Equals(m => m.editor, query.editor);
            }
            category cat = _repository.Get(queryBuilder.Expression);
            CategoryData cd = new CategoryData()
            {
                id = cat.id,
                categoryname = cat.categoryname,
                description = cat.description,
                editdate = (DateTime) cat.editdate,
                editor = cat.editor
            };
            return cd;
        }

        public int UpdateCategory(CategoryData data)
        {
            category p = new category();
            p.categoryname = data.categoryname;
            p.description = data.description;
            p.editdate = DateTime.Now;
            p.editor = "admin";
            p.id = (int)data.id;
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