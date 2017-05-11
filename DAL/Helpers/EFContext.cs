using System.Data.Entity;
using DTO;

namespace DAL
{
    public class EFContext: DbContext
    { 
        public EFContext() : base("WebApi") {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
    }
}

//Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());