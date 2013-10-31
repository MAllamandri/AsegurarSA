namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        TurnoId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        FechaDia = c.DateTime(nullable: false),
                        Dia = c.Int(nullable: false),
                        Semana = c.Int(nullable: false),
                        TipoTurno = c.Int(nullable: false),
                        Franco = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TurnoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Turnos");
        }
    }
}
