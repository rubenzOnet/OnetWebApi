using System.Net;

namespace Onet.Core.Response
{
    public class Response : BaseResponse, IResponseObject
    {
        public object Data { get; set; }
        public Response() { }
        public Response(object Data, bool IsValid, string Message, HttpStatusCode Type)
        {
            this.Data = Data;
            this.IsValid = IsValid;
            this.Message = Message;
            this.Type = Type;
        }
    }


}
