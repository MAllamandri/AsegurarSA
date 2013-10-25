namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eventos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EventoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Eventoes");
        }
    }
}
