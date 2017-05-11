using System.Security.Principal;
using DTO;


namespace UI.Filters
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(Usuario u, string AuthenticationType)
        { 
            Name = u.Login;
            this.AuthenticationType = AuthenticationType;
            IsAuthenticated = true;
            Usuario = u;
        }

        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public Usuario Usuario { get; set; }
    }
}
