namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turnos", "EmpleadoId", "dbo.Empleados");
            DropIndex("dbo.Turnos", new[] { "EmpleadoId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Turnos", "EmpleadoId");
            AddForeignKey("dbo.Turnos", "EmpleadoId", "dbo.Empleados", "EmpleadoId", cascadeDelete: true);
        }
    }
}
