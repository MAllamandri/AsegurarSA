namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alarma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarmas",
                c => new
                    {
                        AlarmaId = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        ClienteId = c.Int(nullable: false),
                        FechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.AlarmaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarmas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Alarmas", new[] { "ClienteId" });
            DropTable("dbo.Alarmas");
        }
    }
}
