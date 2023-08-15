using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.common
{
    public static class Pagination
    {
        public static IEnumerable<Tsource> ToPaged<Tsource>(this IEnumerable<Tsource> source,int page,int pagesize,out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pagesize).Take(pagesize);
        }

    }
}
