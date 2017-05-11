
using DTO;
using System.Threading.Tasks;

namespace DAL
{
  public interface ISessaoDAL
    {
        Sessao FindSessao(string token);
        Task<Sessao> FindToken(string token);
        void Remove(Sessao sessao);
        void AdicionaSessao(Sessao sessao);
    }
}
