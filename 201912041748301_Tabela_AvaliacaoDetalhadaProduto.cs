namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_AvaliacaoDetalhadaProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvaliacaoDetalhadaProduto",
                c => new
                    {
                        IdAvaliacaoDetalhadaProduto = c.Int(nullable: false, identity: true),
                        IdAvaliacaoProduto = c.Int(nullable: false),
                        IdOS_ItemAvaliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAvaliacaoDetalhadaProduto)
                .ForeignKey("dbo.AvaliacaoProduto", t => t.IdAvaliacaoProduto)
                .ForeignKey("dbo.OS_ItemAvaliacao", t => t.IdOS_ItemAvaliacao)
                .Index(t => t.IdAvaliacaoProduto)
                .Index(t => t.IdOS_ItemAvaliacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvaliacaoDetalhadaProduto", "IdOS_ItemAvaliacao", "dbo.OS_ItemAvaliacao");
            DropForeignKey("dbo.AvaliacaoDetalhadaProduto", "IdAvaliacaoProduto", "dbo.AvaliacaoProduto");
            DropIndex("dbo.AvaliacaoDetalhadaProduto", new[] { "IdOS_ItemAvaliacao" });
            DropIndex("dbo.AvaliacaoDetalhadaProduto", new[] { "IdAvaliacaoProduto" });
            DropTable("dbo.AvaliacaoDetalhadaProduto");
        }
    }
}
