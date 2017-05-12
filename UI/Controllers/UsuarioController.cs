using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Filters;

namespace UI.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/admin/usuarios")]
    public class UsuarioController : ApiController
    {
        private UsuarioBLL _usuarioBLL = new UsuarioBLL();

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddUsuario(Usuario usuario)
        {

            try
            {
                _usuarioBLL.Salva(usuario);
                return Ok();
            }catch(Exception e)
            {
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("list")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult ListUsuario(Usuario usuario)
        {

            return Ok(_usuarioBLL.Lista());

        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteUsuario(Usuario usuario)
        {
            
                _usuarioBLL.Remove(usuario);
            return Ok();


}
    }
}
