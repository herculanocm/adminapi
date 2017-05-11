

using DTO;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISessoesBLL
    { 
        Sessao FindSessao(string token);
        Task<Sessao> FindToken(string token);
        void Remove(Sessao sessao);
        void AdicionaSessao(Sessao sessao);
    }
}
