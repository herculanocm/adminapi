using BLL;
using DTO;
using System;
using System.Text;
using System.Web.Http;

namespace UI.Controllers
{
    public class AutenticacaoController : ApiController
    {
        private UsuarioBLL _usuarioBLL = new UsuarioBLL();
        private SessaoBLL _sessaoBLL = new SessaoBLL();

        [HttpPost] 
        [Route("api/Autentica")]
        [AllowAnonymous]
        public IHttpActionResult Login(DTO.Usuario usuario)
        {
            if (usuario == null || usuario.Login == null || usuario.Senha == null) return BadRequest();

  
            Usuario user = _usuarioBLL.Busca(usuario.Login);

            if (user == null) return Unauthorized();
            if (user.Senha != usuario.Senha) return Unauthorized();

            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(usuario.Login + ":" + usuario.Senha));

            //Verifica se já existe a sessão. Se sim, aumenta a data de expiração, caso contrário, cria uma nova sessão
            Sessao s = _sessaoBLL.FindSessao(token);
            if (s == null)
                _sessaoBLL.AdicionaSessao(new Sessao { Chave = token, LoginUsuario = user.Login, Inicio = DateTime.Now, Fim = DateTime.Now.AddHours(1.0), Login =user.Login });
            else
                s.Fim = DateTime.Now.AddHours(1.0);

 

            return Ok(token);
        }

    }
}
