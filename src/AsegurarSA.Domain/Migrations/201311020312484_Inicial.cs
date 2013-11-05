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
                        Latitud = c.String(),
                        Longitud = c.String(),
                    })
                .PrimaryKey(t => t.AlarmaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono1 = c.String(nullable: false),
                        Telefono2 = c.String(nullable: false),
                        Domicilio = c.String(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        TipoServicioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.ClienteServicios",
                c => new
                    {
                        ServicioClienteId = c.Int(nullable: false, identity: true),
                        TipoServicioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.ServicioClienteId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoServicios", t => t.TipoServicioId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.TipoServicioId);
            
            CreateTable(
                "dbo.TipoServicios",
                c => new
                    {
                        TipoServicioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoServicioId);
            
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
                "dbo.Empresas",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
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
                "dbo.Tareas",
                c => new
                    {
                        TareaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Tipo = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        Domicilio = c.String(nullable: false),
                        Resuelta = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TareaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpleadoId);
            
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
                .PrimaryKey(t => t.TurnoId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turnos", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Tareas", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Tareas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ClienteServicios", "TipoServicioId", "dbo.TipoServicios");
            DropForeignKey("dbo.ClienteServicios", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Alarmas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Turnos", new[] { "EmpleadoId" });
            DropIndex("dbo.Tareas", new[] { "EmpleadoId" });
            DropIndex("dbo.Tareas", new[] { "ClienteId" });
            DropIndex("dbo.ClienteServicios", new[] { "TipoServicioId" });
            DropIndex("dbo.ClienteServicios", new[] { "ClienteId" });
            DropIndex("dbo.Alarmas", new[] { "ClienteId" });
            DropTable("dbo.Turnos");
            DropTable("dbo.Tareas");
            DropTable("dbo.Eventos");
            DropTable("dbo.Empresas");
            DropTable("dbo.Empleados");
            DropTable("dbo.TipoServicios");
            DropTable("dbo.ClienteServicios");
            DropTable("dbo.Clientes");
            DropTable("dbo.Alarmas");
        }
    }
}
