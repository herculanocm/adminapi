using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class PerfilBLL : IPerfilBLL
    {
        private PerfilDAL _perfilDAL;

        public PerfilBLL()
        {
            _perfilDAL = new PerfilDAL();
        }

        public void AdicionaPerfil(Perfil perfil)
        {
            _perfilDAL.AdicionaPerfil(perfil);
        }

        public Perfil BuscaPerfil(string role)
        {
            return _perfilDAL.BuscaPerfil(role);
        }

        public IQueryable<Perfil> BuscaTodos()
        {
            return _perfilDAL.BuscaTodos();
        }

        public void RemovePerfil(Perfil perfil)
        {
            _perfilDAL.RemovePerfil(perfil);
        }
    }
}
