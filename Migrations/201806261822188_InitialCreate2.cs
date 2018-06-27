namespace Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cavalo", new[] { "Numero" });
            DropIndex("dbo.Cavalo", new[] { "Nome" });
            DropTable("dbo.Cavalo");
        }
    }
}
