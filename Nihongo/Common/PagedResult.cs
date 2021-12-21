using Newtonsoft.Json;
using System.Collections.Generic;

namespace RoadToDevops.Common
{
    public class PagedResult<T>
    {
        public IList<T> Data { get; set; }
        public int TotalRecord { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
