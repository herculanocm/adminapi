using DTO;
using System.Web.Http;
using System.Web.Http.Description;
using UI.Filters;

namespace UI.Controllers
{
    [AuthenticationFilter]
    public class TesteController : ApiController
    {
        [HttpGet]
        [Route("api/teste")]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUser()
        {
            Usuario u = ((CustomIdentity)User.Identity).Usuario;
            return Ok(new { Login = u.Login });
        }
    }
}
