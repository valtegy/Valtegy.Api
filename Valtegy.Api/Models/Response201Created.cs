using Newtonsoft.Json;

namespace Valtegy.Api.Models
{
    public class Response201Created : ResponseHttpBase
    {
        private readonly int _status = 201;

        [JsonProperty(propertyName: "data")]
        public object Data { get; set; }

        public Response201Created(object data)
        {
            Status = _status;
            Data = data;
        }
    }
}
