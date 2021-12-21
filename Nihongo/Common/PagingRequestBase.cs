using System.ComponentModel.DataAnnotations;

namespace Nihongo.Api.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
