using Newtonsoft.Json;

namespace Valtegy.Api.Models
{
    public class LogErrorModel
    {
        [JsonProperty(propertyName: "appId")]
        public string AppId { get; set; }

        [JsonProperty(propertyName: "traceId")]
        public string TraceId { get; set; }

        [JsonProperty(propertyName: "error")]
        public string Error { get; set; }

        public LogErrorModel(string appId, string traceId, string error)
        {
            AppId = appId;
            TraceId = traceId;
            Error = error;
        }
    }
}
