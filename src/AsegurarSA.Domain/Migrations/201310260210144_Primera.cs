namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
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
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Domicilio = c.String(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.TipoServicios",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarmas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Alarmas", new[] { "ClienteId" });
            DropTable("dbo.TipoServicios");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Alarmas");
        }
    }
}
