namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipoServicios", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.TipoServicios", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoServicios", "Descripcion", c => c.String());
            AlterColumn("dbo.TipoServicios", "Nombre", c => c.String());
        }
    }
}
