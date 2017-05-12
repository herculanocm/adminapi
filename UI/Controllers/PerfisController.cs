using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Filters;
using BLL;
using DTO;
using System.Web.Http.Description;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UI.Results;

namespace UI.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/admin/perfis")]
    public class PerfisController : ApiController
    {
        private PerfilBLL _perfilBLL = new PerfilBLL();

        [HttpGet]
        [Route("busca")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllPerfil()
        {
            List<Perfil> perfis = _perfilBLL.BuscaTodos().ToList();

            /*
            JsonConvert.SerializeObject(perfis, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });
                */


            return new RespostaPadrao(Request, HttpStatusCode.OK, "Perfis listado com sucesso", perfis);
        }


        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddPerfil(Perfil perfil)
        {
            try
            {
                _perfilBLL.AdicionaPerfil(perfil);
                return Ok();
            }catch(Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("deleta")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult RemovePerfil(Perfil perfil)
        {
            try
            {
                _perfilBLL.RemovePerfil(perfil);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public HttpResponseMessage Resposta(HttpStatusCode statusCode)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

    }
}
