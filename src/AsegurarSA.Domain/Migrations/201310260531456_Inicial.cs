namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Password = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.TipoServicios",
                c => new
                    {
                        TipoServicioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoServicioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarmas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "EmpresaId", "dbo.Empresas");
            DropIndex("dbo.Alarmas", new[] { "ClienteId" });
            DropIndex("dbo.Clientes", new[] { "EmpresaId" });
            DropTable("dbo.TipoServicios");
            DropTable("dbo.Eventos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Empresas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Alarmas");
        }
    }
}
