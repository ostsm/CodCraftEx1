namespace CodingCraftHOMod1Ex1EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        Setor = c.String(nullable: false),
                        MovimentacaoCliente_MovimentacaoClienteId = c.Guid(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.MovimentacoesClientes", t => t.MovimentacaoCliente_MovimentacaoClienteId)
                .Index(t => t.MovimentacaoCliente_MovimentacaoClienteId);
            
            CreateTable(
                "dbo.MovimentacoesClientes",
                c => new
                    {
                        MovimentacaoClienteId = c.Guid(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataSaida = c.DateTime(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovimentacaoClienteId);
            
            CreateTable(
                "dbo.MovimentacoesFornecedores",
                c => new
                    {
                        MovimentacaoFornecedorId = c.Guid(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovimentacaoFornecedorId);
            
            AddColumn("dbo.Fornecedores", "MovimentacaoFornecedor_MovimentacaoFornecedorId", c => c.Guid());
            AddColumn("dbo.Produtos", "MovimentacaoCliente_MovimentacaoClienteId", c => c.Guid());
            AddColumn("dbo.Produtos", "MovimentacaoFornecedor_MovimentacaoFornecedorId", c => c.Guid());
            CreateIndex("dbo.Fornecedores", "MovimentacaoFornecedor_MovimentacaoFornecedorId");
            CreateIndex("dbo.Produtos", "MovimentacaoCliente_MovimentacaoClienteId");
            CreateIndex("dbo.Produtos", "MovimentacaoFornecedor_MovimentacaoFornecedorId");
            AddForeignKey("dbo.Produtos", "MovimentacaoCliente_MovimentacaoClienteId", "dbo.MovimentacoesClientes", "MovimentacaoClienteId");
            AddForeignKey("dbo.Fornecedores", "MovimentacaoFornecedor_MovimentacaoFornecedorId", "dbo.MovimentacoesFornecedores", "MovimentacaoFornecedorId");
            AddForeignKey("dbo.Produtos", "MovimentacaoFornecedor_MovimentacaoFornecedorId", "dbo.MovimentacoesFornecedores", "MovimentacaoFornecedorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "MovimentacaoFornecedor_MovimentacaoFornecedorId", "dbo.MovimentacoesFornecedores");
            DropForeignKey("dbo.Fornecedores", "MovimentacaoFornecedor_MovimentacaoFornecedorId", "dbo.MovimentacoesFornecedores");
            DropForeignKey("dbo.Produtos", "MovimentacaoCliente_MovimentacaoClienteId", "dbo.MovimentacoesClientes");
            DropForeignKey("dbo.Clientes", "MovimentacaoCliente_MovimentacaoClienteId", "dbo.MovimentacoesClientes");
            DropIndex("dbo.Produtos", new[] { "MovimentacaoFornecedor_MovimentacaoFornecedorId" });
            DropIndex("dbo.Produtos", new[] { "MovimentacaoCliente_MovimentacaoClienteId" });
            DropIndex("dbo.Fornecedores", new[] { "MovimentacaoFornecedor_MovimentacaoFornecedorId" });
            DropIndex("dbo.Clientes", new[] { "MovimentacaoCliente_MovimentacaoClienteId" });
            DropColumn("dbo.Produtos", "MovimentacaoFornecedor_MovimentacaoFornecedorId");
            DropColumn("dbo.Produtos", "MovimentacaoCliente_MovimentacaoClienteId");
            DropColumn("dbo.Fornecedores", "MovimentacaoFornecedor_MovimentacaoFornecedorId");
            DropTable("dbo.MovimentacoesFornecedores");
            DropTable("dbo.MovimentacoesClientes");
            DropTable("dbo.Clientes");
        }
    }
}
