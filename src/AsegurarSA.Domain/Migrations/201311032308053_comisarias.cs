namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comisarias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comisarias",
                c => new
                    {
                        ComisariaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Latitud = c.String(),
                        Longitud = c.String(),
                    })
                .PrimaryKey(t => t.ComisariaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comisarias");
        }
    }
}
