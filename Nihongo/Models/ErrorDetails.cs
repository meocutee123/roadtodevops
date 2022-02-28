
using Newtonsoft.Json;

namespace Nihongo.Api.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
