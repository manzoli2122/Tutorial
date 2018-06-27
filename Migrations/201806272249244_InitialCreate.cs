namespace Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cavalo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256, unicode: false),
                        Nascimento = c.DateTime(nullable: false),
                        Numero = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Nome, unique: true)
                .Index(t => t.Numero, unique: true);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 256, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UsuariorPerfil",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 256, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Perfil", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 256, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 256, unicode: false),
                        SecurityStamp = c.String(maxLength: 256, unicode: false),
                        PhoneNumber = c.String(maxLength: 256, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 256, unicode: false),
                        ClaimType = c.String(maxLength: 256, unicode: false),
                        ClaimValue = c.String(maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 256, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 256, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariorPerfil", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariorPerfil", "RoleId", "dbo.Perfil");
            DropIndex("dbo.Logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.UsuariorPerfil", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UsuariorPerfil", new[] { "RoleId" });
            DropIndex("dbo.Perfil", "RoleNameIndex");
            DropIndex("dbo.Cavalo", new[] { "Numero" });
            DropIndex("dbo.Cavalo", new[] { "Nome" });
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Usuarios");
            DropTable("dbo.UsuariorPerfil");
            DropTable("dbo.Perfil");
            DropTable("dbo.Cavalo");
        }
    }
}
