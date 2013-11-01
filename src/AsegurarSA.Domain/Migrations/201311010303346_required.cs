namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tareas", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Tareas", "Domicilio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tareas", "Domicilio", c => c.String());
            AlterColumn("dbo.Tareas", "Descripcion", c => c.String());
        }
    }
}
