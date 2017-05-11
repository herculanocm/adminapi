using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace UI.Filters
{  
    internal class AuthenticationFailureResult : IHttpActionResult
    {
        private HttpRequestMessage request;
        private string reason;

        public AuthenticationFailureResult(string reason, HttpRequestMessage request)
        {
            this.reason = reason;
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = request;
            response.ReasonPhrase = reason;
            return response;
        }
    }
}