using DTO;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUsuarioDAL
    {
        void salva(Usuario usuario);
        IQueryable<Usuario> Lista();
        Usuario Busca(string Login);
    }
}
