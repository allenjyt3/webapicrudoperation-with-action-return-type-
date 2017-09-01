using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApiCRUDOperations.App_Start
{
    public class CustomResult : IHttpActionResult
    {
        string _value;
        string _value2;
        HttpRequestMessage _request;
        HttpStatusCode _code;


        public CustomResult(string value,string value2,HttpRequestMessage request,HttpStatusCode code)
        {
            _value = value;
            _value2 = value2;
            _request = request;
            _code = code;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value +" "+_value2), 
                RequestMessage = _request,
                StatusCode = _code
            };
            return Task.FromResult(response);
        }
    }
}