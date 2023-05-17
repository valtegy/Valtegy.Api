
namespace Valtegy.Domain.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseModel(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ResponseModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseModel(bool success, object data = null)
        {
            Success = success;
            Data = data;
        }
    }
}
