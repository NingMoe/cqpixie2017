using cqpixie.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cqpixie.BLL.Common;
using cqpixie.DAL.Interface;
using cqpixie.Model;
using cqpixie.DAL.Implementation;
using cqpixie.Common;

namespace cqpixie.BLL.Implementation
{
    public class UserManager : IUserManager
    {
        IRepository<user> _repository;
        public UserManager()
        {
            _repository = new Repository<user>();
        }
        public int AddUser(UserData data)
        {
            try
            {
                user p = new user();
                p.username= data.username;
                p.editdate = DateTime.Now;
                p.password= data.password;
                p.editor = "admin";
                _repository.Insert(p);
                return p.id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteUser(int id)
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

        public UserData GetUser(UserData query)
        {
            var queryBuilder = QueryBuilder.Create<user>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
            }
            if (!string.IsNullOrEmpty(query.username))
            {
                queryBuilder = queryBuilder.Like(m => m.username, query.username);
            }
            if (query.password != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.password, query.password);
            }
            if (!string.IsNullOrEmpty(query.editor))
            {
                queryBuilder = queryBuilder.Equals(m => m.editor, query.editor);
            }
            user u = _repository.Get(queryBuilder.Expression);
            if (u != null)
            {
                UserData ud = new UserData()
                {
                    id = u.id,
                    username = u.username,
                    password = u.password,
                    editdate = (DateTime)u.editdate,
                    editor = u.editor
                };
                return ud;
            }
            else
            {
                return null;
            }

        }

        public ListData GetUsers(UserData query)
        {
            var queryBuilder = QueryBuilder.Create<user>();
            if (query.id != null)
            {
                queryBuilder = queryBuilder.Equals(m => m.id, query.id);
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
            List<UserData> ud = new List<UserData>();
            foreach (user u in data)
            {
                ud.Add(new UserData
                {
                    id = u.id,
                    username = u.username,
                    password = u.password,
                    editdate = (DateTime)u.editdate,
                    editor = u.editor
                });
            }
            return new ListData
            {
                PageIndex = query.PageIndex,
                CountTotal = countTotal,
                CountFiltered = countFiltered,
                DataList = ud
            };
        }

        public int UpdateUser(UserData data)
        {
            user p = new user();
            p.username = data.username;
            p.password= data.password;
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