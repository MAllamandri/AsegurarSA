namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleados", "Style", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleados", "Style");
        }
    }
}
