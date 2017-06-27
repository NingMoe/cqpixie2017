using cqpixie.BLL.Common;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqpixie.BLL.Interface
{
    public interface ICategoryManager
    {
        int AddCategory(CategoryData data);
        int UpdateCategory(CategoryData data);
        int DeleteCategory(int id);
        CategoryData GetCategory(CategoryData query);
        ListData GetCategories(CategoryData query);
    }
}
