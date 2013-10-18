namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleadoes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Empleadoes", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Empleadoes", "Telefono", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleadoes", "Telefono", c => c.String());
            AlterColumn("dbo.Empleadoes", "Apellido", c => c.String());
            AlterColumn("dbo.Empleadoes", "Nombre", c => c.String());
        }
    }
}
