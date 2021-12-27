using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Dtos
{
    public class KanjiDto
    {
        public int Id { get; set; }
        public string Japanese { get; set; }
        public string KanaSpelling { get; set; }
        public string English { get; set; }
        public string Romanization { get; set; }
        public string Message { get; set; }
    }
}
