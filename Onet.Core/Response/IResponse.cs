using System.Net;

namespace Onet.Core.Response
{
    public interface IResponse
    {
        bool IsValid { get; set; }
        string Message { get; set; }
        HttpStatusCode Type { get; set; }
        bool HasMessages { get; }
    }

    public interface IResponseObject : IResponse
    {
        object Data { get; set; }
    }
    public interface IResponseGeneric<T> : IResponse
    {
        T Data { get; set; }
    }

    public interface IResponseReporte : IResponse
    {
        int ResultadoReporteID { get; set; }
    }
}
