using System;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private EFContext _efContext;

        public UsuarioDAL()
        {
            _efContext = new EFContext();
        }

        public Usuario Busca(string Login)
        {
            return _efContext.Usuarios.Find(Login);
        }

        public IQueryable<Usuario> Lista()
        {
            return _efContext.Usuarios.OrderBy(c => c.Login);
        }

        public void Remove(Usuario usuario)
        {

            Usuario u = Busca(usuario);
            List<Sessao> _sessoes = u.Sessoes.ToList();

           foreach (Sessao _s in _sessoes)
            {
                _efContext.Sessoes.Remove(_s);   
            }


      


            _efContext.Usuarios.Remove(u);
            _efContext.SaveChanges();
        }

        public void Salva(Usuario usuario)
        {
            _efContext.Usuarios.Add(usuario);
            _efContext.SaveChanges();
        }

        public Usuario Busca(Usuario usuario)
        {
            return _efContext.Usuarios.Find(usuario.Login);
        }
    }
}
