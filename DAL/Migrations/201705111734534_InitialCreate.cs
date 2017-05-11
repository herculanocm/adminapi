namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfis",
                c => new
                    {
                        Role = c.String(nullable: false, maxLength: 128),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Role);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.Sessoes",
                c => new
                    {
                        Chave = c.String(nullable: false, maxLength: 128),
                        LoginUsuario = c.String(),
                        Inicio = c.DateTime(),
                        Fim = c.DateTime(),
                        Login = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Chave)
                .ForeignKey("dbo.Usuarios", t => t.Login)
                .Index(t => t.Login);
            
            CreateTable(
                "dbo.UsuarioPerfils",
                c => new
                    {
                        Usuario_Login = c.String(nullable: false, maxLength: 128),
                        Perfil_Role = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Usuario_Login, t.Perfil_Role })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Login, cascadeDelete: true)
                .ForeignKey("dbo.Perfis", t => t.Perfil_Role, cascadeDelete: true)
                .Index(t => t.Usuario_Login)
                .Index(t => t.Perfil_Role);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessoes", "Login", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioPerfils", "Perfil_Role", "dbo.Perfis");
            DropForeignKey("dbo.UsuarioPerfils", "Usuario_Login", "dbo.Usuarios");
            DropIndex("dbo.UsuarioPerfils", new[] { "Perfil_Role" });
            DropIndex("dbo.UsuarioPerfils", new[] { "Usuario_Login" });
            DropIndex("dbo.Sessoes", new[] { "Login" });
            DropTable("dbo.UsuarioPerfils");
            DropTable("dbo.Sessoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Perfis");
        }
    }
}
