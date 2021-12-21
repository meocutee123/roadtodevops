using System;
using System.Collections.Generic;

#nullable disable

namespace Nihongo.Entites.Models
{
    public partial class Kanji
    {
        public int Id { get; set; }
        public string Japanese { get; set; }
        public string KanaSpelling { get; set; }
        public string English { get; set; }
        public string Romanization { get; set; }
    }
}
