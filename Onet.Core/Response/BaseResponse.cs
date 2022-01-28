using System.Net;

namespace Onet.Core.Response
{
    public class BaseResponse : IResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Type { get; set; }
        public bool HasMessages
        {
            get
            {
                return (this.Message.Length > 0);
            }
        }
        public BaseResponse()
        {
            this.IsValid = false;
            this.Type = HttpStatusCode.InternalServerError;
            this.Message = string.Empty;
        }
    }
}
