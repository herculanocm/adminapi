using DTO;
using System.Linq;


namespace BLL
{
    public interface IUsuarioBLL
    {
        void Remove(Usuario usuario);
        void Salva(Usuario usuario); 
        IQueryable<Usuario> Lista();
        Usuario Busca(string Login);
    }
}
