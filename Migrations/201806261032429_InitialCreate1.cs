namespace Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "CASA.Papeis", newSchema: "dbo");
            MoveTable(name: "CASA.UsuariorPapel", newSchema: "dbo");
            MoveTable(name: "CASA.Usuarios", newSchema: "dbo");
            MoveTable(name: "CASA.Claims", newSchema: "dbo");
            MoveTable(name: "CASA.Logins", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Logins", newSchema: "CASA");
            MoveTable(name: "dbo.Claims", newSchema: "CASA");
            MoveTable(name: "dbo.Usuarios", newSchema: "CASA");
            MoveTable(name: "dbo.UsuariorPapel", newSchema: "CASA");
            MoveTable(name: "dbo.Papeis", newSchema: "CASA");
        }
    }
}
