using Newtonsoft.Json;

namespace Valtegy.Api.Models
{
    public class Response409Conflict : ResponseHttpBase
    {
        private readonly int _status = 409;

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }

        public Response409Conflict(string title)
        {
            Status = _status;
            Title = title;
        }
    }
}
