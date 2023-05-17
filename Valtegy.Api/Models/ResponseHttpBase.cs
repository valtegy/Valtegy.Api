using Newtonsoft.Json;
using System;

namespace Valtegy.Api.Models
{
    public class ResponseHttpBase
    {
        [JsonProperty(propertyName: "status")]
        public int Status { get; set; }

        [JsonProperty(propertyName: "traceId")]
        public string TraceId { get; set; }

        public ResponseHttpBase()
        {
            TraceId = Guid.NewGuid().ToString();
        }

        public ResponseHttpBase(string traceId)
        {
            TraceId = traceId;
        }
    }
}
