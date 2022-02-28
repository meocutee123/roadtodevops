using System.ComponentModel.DataAnnotations;

namespace Nihongo.Shared.Utils.Paging
{
    public class PagingRequestBase
    {
        const int MAX_PAGE_SIZE = 50;
        private int _pageSize = 10;
        public int PageIndex { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }
    }
}
