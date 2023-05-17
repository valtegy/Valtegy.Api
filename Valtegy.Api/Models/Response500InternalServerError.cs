using Newtonsoft.Json;
using System.Diagnostics;

namespace Valtegy.Api.Models
{
    public class Response500InternalServerError : ResponseHttpBase
    {
        private readonly int _status = 500;

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }

        public Response500InternalServerError(string traceId, string title) : base(traceId)
        {
            Status = _status;
            Title = title;
        }
    }
}
