namespace Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CASA.Papeis",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 256, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "CASA.UsuariorPapel",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 256, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("CASA.Papeis", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("CASA.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "CASA.Usuarios",
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
                "CASA.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 256, unicode: false),
                        ClaimType = c.String(maxLength: 256, unicode: false),
                        ClaimValue = c.String(maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CASA.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "CASA.Logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 256, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 256, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 256, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("CASA.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CASA.UsuariorPapel", "IdentityUser_Id", "CASA.Usuarios");
            DropForeignKey("CASA.Logins", "IdentityUser_Id", "CASA.Usuarios");
            DropForeignKey("CASA.Claims", "IdentityUser_Id", "CASA.Usuarios");
            DropForeignKey("CASA.UsuariorPapel", "RoleId", "CASA.Papeis");
            DropIndex("CASA.Logins", new[] { "IdentityUser_Id" });
            DropIndex("CASA.Claims", new[] { "IdentityUser_Id" });
            DropIndex("CASA.Usuarios", "UserNameIndex");
            DropIndex("CASA.UsuariorPapel", new[] { "IdentityUser_Id" });
            DropIndex("CASA.UsuariorPapel", new[] { "RoleId" });
            DropIndex("CASA.Papeis", "RoleNameIndex");
            DropTable("CASA.Logins");
            DropTable("CASA.Claims");
            DropTable("CASA.Usuarios");
            DropTable("CASA.UsuariorPapel");
            DropTable("CASA.Papeis");
        }
    }
}
