using DTO;
using System.Linq;

namespace BLL
{
    public interface IPerfilBLL
    {
        void AdicionaPerfil(Perfil perfil);
        void RemovePerfil(Perfil perfil);
        Perfil BuscaPerfil(string role);
        IQueryable<Perfil> BuscaTodos();
    }
}
