namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleadoes", "UserName", c => c.String());
            AddColumn("dbo.Empleadoes", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleadoes", "Password");
            DropColumn("dbo.Empleadoes", "UserName");
        }
    }
}
