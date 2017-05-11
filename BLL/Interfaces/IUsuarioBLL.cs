using DTO;
using System.Linq;


namespace BLL
{
    public interface IUsuarioBLL
    {
        void salva(Usuario usuario); 
        IQueryable<Usuario> Lista();
        Usuario Busca(string Login);
    }
}
