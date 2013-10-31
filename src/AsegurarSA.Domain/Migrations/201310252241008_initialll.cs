namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialll : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Turnoes", newName: "Turnos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Turnos", newName: "Turnoes");
        }
    }
}
