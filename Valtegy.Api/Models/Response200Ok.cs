using Newtonsoft.Json;

namespace Valtegy.Api.Models
{
    public class Response200Ok : ResponseHttpBase
    {
        private readonly int _status = 200;

        [JsonProperty(propertyName: "data")]
        public object Data { get; set; }

        public Response200Ok(object data)
        {
            Status = _status;
            Data = data;
        }
    }
}
