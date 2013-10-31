namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menosempresa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "EmpresaId", "dbo.Empresas");
            DropIndex("dbo.Clientes", new[] { "EmpresaId" });
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Telefono1", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Telefono2", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Domicilio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Domicilio", c => c.String());
            AlterColumn("dbo.Clientes", "Telefono2", c => c.String());
            AlterColumn("dbo.Clientes", "Telefono1", c => c.String());
            AlterColumn("dbo.Clientes", "Apellido", c => c.String());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
            CreateIndex("dbo.Clientes", "EmpresaId");
            AddForeignKey("dbo.Clientes", "EmpresaId", "dbo.Empresas", "EmpresaId", cascadeDelete: true);
        }
    }
}
