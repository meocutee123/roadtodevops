
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nihongo.Shared.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
