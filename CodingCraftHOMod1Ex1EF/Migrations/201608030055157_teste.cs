namespace CodingCraftHOMod1Ex1EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovimentacoesClientes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.MovimentacoesClientes", new[] { "ClienteId" });
            AddColumn("dbo.MovimentacoesClientes", "Cliente_ClienteId", c => c.Guid());
            AlterColumn("dbo.MovimentacoesClientes", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovimentacoesClientes", "ClienteId");
            CreateIndex("dbo.MovimentacoesClientes", "Cliente_ClienteId");
            AddForeignKey("dbo.MovimentacoesClientes", "ClienteId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovimentacoesClientes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimentacoesClientes", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.MovimentacoesClientes", "ClienteId", "dbo.AspNetUsers");
            DropIndex("dbo.MovimentacoesClientes", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.MovimentacoesClientes", new[] { "ClienteId" });
            AlterColumn("dbo.MovimentacoesClientes", "ClienteId", c => c.Guid(nullable: false));
            DropColumn("dbo.MovimentacoesClientes", "Cliente_ClienteId");
            CreateIndex("dbo.MovimentacoesClientes", "ClienteId");
            AddForeignKey("dbo.MovimentacoesClientes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
