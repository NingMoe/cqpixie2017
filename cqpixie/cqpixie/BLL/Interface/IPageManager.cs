using cqpixie.BLL.Common;
using cqpixie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqpixie.BLL.Interface
{
    public interface IPageManager
    {
        int AddPage(PageData data);
        int UpdatePage(PageData data);
        int DeletePage(int id);
        page GetPage(PageData query);
        ListData GetPages(PageData query);

    }
}
