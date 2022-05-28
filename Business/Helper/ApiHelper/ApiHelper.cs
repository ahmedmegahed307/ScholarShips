using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.ApiHelper
{
    public class ApiHelper : IApiHelper
    {
        readonly IRestClient _client;
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _config;

        public ApiHelper(IRestClient client, IConfiguration config, IHttpContextAccessor accessor)
        {
            _config = config;
            _accessor = accessor;
            _client = client;
            client.BaseUrl = new Uri(config.GetValue<string>("ApiSettings:Host"));

        }


        public ResultDTO<T> GetObjectResponseFromApi<T>(Method method, string url, object body = null, string token = "", bool _stringify = false) where T : new()

        {
            try
            {
                var request = new RestRequest(url, method);

                if (!string.IsNullOrEmpty(token))
                {
                    request.AddHeader("Authorization", "Bearer " + token);
                }
                //request.RequestFormat = DataFormat.Json;
                request.OnBeforeDeserialization = resp => { resp.ContentType = ",/json"; };
                request.AddHeader("Accept-Language", "en-us");
                request.AddHeader("Content-Type", "application/json");

                request.UseDefaultCredentials = true;

                request.AddParameter("application\\json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

                request.AddJsonBody(body);
                IRestResponse response = _client.Execute(request);

                if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        _accessor.HttpContext.Response.Redirect("/Security/Logoff");
                    }
                    return new ResultDTO<T>
                    {
                        Success = false,
                        Message = response.ErrorMessage
                    };
                }

                var resultData = default(ResultDTO<T>);

                resultData = JsonConvert.DeserializeObject<ResultDTO<T>>(response.Content, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                if (_stringify)
                {
                    if (typeof(BaseDTO).IsAssignableFrom(typeof(T)))
                    {
                        BaseDTO baseDTO = resultData.Data as BaseDTO;
                        //  baseDTO.OriginalDTO = JsonConvert.SerializeObject(resultData.Data);
                    }
                }

                return resultData;
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
            }
            return default(ResultDTO<T>);
        }


    }
}

