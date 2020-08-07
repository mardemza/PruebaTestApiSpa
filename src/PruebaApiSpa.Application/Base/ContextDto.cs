using System.Collections.Generic;
using X.PagedList;

namespace PruebaApiSpa.Base
{
    public class ContextDto<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public IPagedList MetaData { get; set; }
    }
}
