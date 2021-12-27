using System.ComponentModel.DataAnnotations;

namespace Nihongo.Application.Commands.Kanji
{
    public class UpdateKanjiRequest
    {
        [Required]
        public int Id { get; set; }
        public string Japanese { get; set; }
        public string KanaSpelling { get; set; }
        public string English { get; set; }
        public string Romanization { get; set; }
    }
}
