using Newtonsoft.Json;
using System.Collections.Generic;

namespace Valtegy.Api.Models
{
    public class Response400BadRequest : ResponseHttpBase
    {
        private readonly int _status = 400;

        [JsonProperty(propertyName: "errors")]
        public List<ErrorModel> Errors { get; set; }

        public Response400BadRequest(List<ErrorModel> errors)
        {
            Status = _status;
            Errors = errors;
        }
    }

    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
