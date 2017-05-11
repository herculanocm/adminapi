

using System;
using System.Linq;
using DTO;
using DAL; 

namespace BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private UsuarioDAL _usuarioDAL;

        public UsuarioBLL()
        {
            _usuarioDAL = new UsuarioDAL();
        }

        public Usuario Busca(string Login)
        {
            return _usuarioDAL.Busca(Login);
        }

        public IQueryable<Usuario> Lista()
        {
            return _usuarioDAL.Lista();
        }

        public void salva(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
