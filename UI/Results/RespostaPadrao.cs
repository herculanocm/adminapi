using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace UI.Results
{
    public class RespostaPadrao : IHttpActionResult
    {
        string _msg;
        object _obj;
        List<object> _lObj;
        HttpRequestMessage _request;
        HttpStatusCode _code;
        int tipo = 1;
        Type _type;
        MediaTypeFormatter _mediaType;

        public RespostaPadrao(HttpRequestMessage request, HttpStatusCode code, string msg)
        {
            this._request = request;
            this._code = code;
            this._msg = msg;
            this.tipo = 1;
        }

        public RespostaPadrao(HttpRequestMessage request, HttpStatusCode code, string msg, object obj)
        {
            this._request = request;
            this._code = code;
            this._msg = msg;
            this._obj = obj;
            this.tipo = 2;

        }
        /*
        public RespostaPadrao(HttpRequestMessage request, HttpStatusCode code, string msg, List<object> lObj, Type type, MediaTypeFormatter mediaType)
        {
            this._request = request;
            this._code = code;
            this._msg = msg;
            this._lObj = lObj;
            this.tipo = 3;
            this._type = type;
            this._mediaType = mediaType;
        }
        */



        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
          

            return Task.FromResult(Execute());
        }


        private HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage();

            response.RequestMessage = _request;
            response.StatusCode = _code;
            response.ReasonPhrase = _msg;
           

            //JsonMediaTypeFormatter.DefaultMediaType.MediaType

            if(this.tipo != 1)
            {

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };



                string jsonresp = JsonConvert.SerializeObject(_obj, settings);

                response.Content = new StringContent(jsonresp, System.Text.Encoding.UTF8, "application/json");

            }

           

            return response;
        }
    }
}