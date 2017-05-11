using System;
using System.Threading.Tasks;
using System.Linq;
using DTO;
using System.Data.Entity;

namespace DAL
{
    public class SessaoDAL : ISessaoDAL
    {
        private EFContext _efContext;

        public SessaoDAL()
        {
            _efContext = new EFContext();
        }

        public void AdicionaSessao(Sessao sessao)
        {
            _efContext.Sessoes.Add(sessao);
            _efContext.SaveChanges();
        }

        public Sessao FindSessao(string token)
        {
            return _efContext.Sessoes.Include(s => s.Usuario).SingleOrDefault(x => x.Chave == token);
        }

        public Task<Sessao> FindToken(string token)
        {
            return _efContext.Sessoes.FindAsync(token);
        }

        public void Remove(Sessao sessao)
        {
            _efContext.Sessoes.Remove(sessao);
            _efContext.SaveChanges();
        }
    }
}
