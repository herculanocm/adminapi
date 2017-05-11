using System;
using System.Linq;
using System.Threading.Tasks;
using DTO;
 
namespace DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private EFContext _efContext;

        public UsuarioDAL()
        {
            _efContext = new EFContext();
        }

        public Usuario Busca(string Login)
        {
            return _efContext.Usuarios.Find(Login);
        }

        public IQueryable<Usuario> Lista()
        {
            return _efContext.Usuarios.OrderBy(c => c.Login);
        }

        public void salva(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
