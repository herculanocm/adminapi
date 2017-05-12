using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;

namespace DAL
{
    public class PerfilDAL : IPerfilDAL
    {
        private EFContext _efContext;

        public PerfilDAL()
        {
            _efContext = new EFContext();
        }

        private Perfil VerificaPerfil(Perfil perfil)
        {
            Perfil _perfilBusca = _efContext.Perfis.Find(perfil.Role);
            return _perfilBusca;
        }

        public void AdicionaPerfil(Perfil perfil)
        {
            Perfil p = VerificaPerfil(perfil);
            if (p == null)
            {
                _efContext.Perfis.Add(perfil);
            }
            else
            {
                p.Descricao = perfil.Descricao;
                _efContext.Entry(p).State = EntityState.Modified;
            }

            _efContext.SaveChanges();
        }

        public Perfil BuscaPerfil(string role)
        {
            return _efContext.Perfis.Find(role);
        }

        public void RemovePerfil(Perfil perfil)
        {
            _efContext.Perfis.Attach(perfil);
            _efContext.Perfis.Remove(perfil);
            _efContext.SaveChanges();
        }

        public IQueryable<Perfil> BuscaTodos()
        {
            return _efContext.Perfis.OrderBy(p => p.Role);
        }
    }
}
