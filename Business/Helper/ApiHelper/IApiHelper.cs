using Entities.InterjectionDTO;

using RestSharp;

namespace Business.Helper.ApiHelper
{
    public interface IApiHelper
    {
        ResultDTO<T> GetObjectResponseFromApi<T>(Method _method, string _url, object _body = null, string _token = "", bool _stringify = false) where T : new();
    }
}
