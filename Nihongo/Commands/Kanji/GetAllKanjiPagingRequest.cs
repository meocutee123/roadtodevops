using Nihongo.Api.Common;
using System.ComponentModel.DataAnnotations;

namespace Nihongo.Api.Commands.Kanji
{
    public class GetAllKanjiPagingRequest : PagingRequestBase
    {
        [Required]
        public string Plannet { get; set; }
    }
}
