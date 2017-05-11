
using System;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL 
{
    public class SessaoBLL : ISessoesBLL
    {
        private SessaoDAL _sessaoDAL;

        public SessaoBLL()
        {
            _sessaoDAL = new SessaoDAL();
        }

        public void AdicionaSessao(Sessao sessao)
        {
            _sessaoDAL.AdicionaSessao(sessao);
        }

        public Sessao FindSessao(string token)
        {
            return _sessaoDAL.FindSessao(token);
        }

        public Task<Sessao> FindToken(string token)
        {
            return _sessaoDAL.FindToken(token);
        }

        public void Remove(Sessao sessao)
        {
            _sessaoDAL.Remove(sessao);
        }
    }
}
