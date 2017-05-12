using DTO;
using System.Linq;

namespace DAL
{
   public interface IPerfilDAL
    {
        void AdicionaPerfil(Perfil perfil);
        void RemovePerfil(Perfil perfil);
        Perfil BuscaPerfil(string role);
        IQueryable<Perfil> BuscaTodos();
    }
}
