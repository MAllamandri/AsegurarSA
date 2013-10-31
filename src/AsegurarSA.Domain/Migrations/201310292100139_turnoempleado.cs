namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turnoempleado : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Turnos", "EmpleadoId");
            AddForeignKey("dbo.Turnos", "EmpleadoId", "dbo.Empleados", "EmpleadoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turnos", "EmpleadoId", "dbo.Empleados");
            DropIndex("dbo.Turnos", new[] { "EmpleadoId" });
        }
    }
}
