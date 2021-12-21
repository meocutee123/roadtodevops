using System.ComponentModel.DataAnnotations;

namespace Nihongo.Api.Commands.Kanji
{
    public class AddKanjiRequest
    {
        [Required]
        public string Japanese { get; set; }
        [Required]
        public string KanaSpelling { get; set; }
        public string English { get; set; }
        public string Romanization { get; set; }
    }
}
