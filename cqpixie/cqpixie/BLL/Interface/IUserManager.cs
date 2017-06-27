using cqpixie.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqpixie.BLL.Interface
{
    interface IUserManager
    {
        int AddUser(UserData data);
        int UpdateUser(UserData data);
        int DeleteUser(int id);
        UserData GetUser(UserData query);
        ListData GetUsers(UserData query);
    }
}
