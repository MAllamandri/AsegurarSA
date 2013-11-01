namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tareas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        TareaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Tipo = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        Domicilio = c.String(),
                        Resuelta = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TareaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tareas", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Tareas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Tareas", new[] { "EmpleadoId" });
            DropIndex("dbo.Tareas", new[] { "ClienteId" });
            DropTable("dbo.Tareas");
        }
    }
}
