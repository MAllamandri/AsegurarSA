namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empleadoeliminado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleadoes", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleadoes", "Eliminado");
        }
    }
}
