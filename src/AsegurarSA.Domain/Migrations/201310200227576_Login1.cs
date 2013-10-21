namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Empleadoes", newName: "Empleados");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Empleados", newName: "Empleadoes");
        }
    }
}
