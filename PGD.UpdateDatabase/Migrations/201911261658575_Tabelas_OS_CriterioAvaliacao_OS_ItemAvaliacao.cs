namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas_OS_CriterioAvaliacao_OS_ItemAvaliacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OS_CriterioAvaliacao",
                c => new
                    {
                        IdCriterioAvaliacao = c.Int(nullable: false, identity: true),
                        IdCriterioAvaliacaoOriginal = c.Int(nullable: false),
                        DescCriterioAvaliacao = c.String(nullable: false, maxLength: 100, unicode: false),
                        StrTextoExplicativo = c.String(nullable: false, maxLength: 1000, unicode: false),
                        IdOrdemServico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCriterioAvaliacao)
                .ForeignKey("dbo.OrdemServico", t => t.IdOrdemServico)
                .Index(t => t.IdOrdemServico);
            
            CreateTable(
                "dbo.OS_ItemAvaliacao",
                c => new
                    {
                        IdItemAvaliacao = c.Int(nullable: false, identity: true),
                        DescItemAvaliacao = c.String(nullable: false, maxLength: 100, unicode: false),
                        ImpactoNota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdNotaMaxima = c.Int(nullable: false),
                        IdCriterioAvaliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdItemAvaliacao)
                .ForeignKey("dbo.OS_CriterioAvaliacao", t => t.IdCriterioAvaliacao)
                .ForeignKey("dbo.NotaAvaliacao", t => t.IdNotaMaxima)
                .Index(t => t.IdNotaMaxima)
                .Index(t => t.IdCriterioAvaliacao);
        }
        
        public override void Down()
        {            
            DropForeignKey("dbo.OS_CriterioAvaliacao", "IdOrdemServico", "dbo.OrdemServico");
            DropForeignKey("dbo.OS_ItemAvaliacao", "IdNotaMaxima", "dbo.NotaAvaliacao");
            DropForeignKey("dbo.OS_ItemAvaliacao", "IdCriterioAvaliacao", "dbo.OS_CriterioAvaliacao");
            DropIndex("dbo.OS_ItemAvaliacao", new[] { "IdCriterioAvaliacao" });
            DropIndex("dbo.OS_ItemAvaliacao", new[] { "IdNotaMaxima" });
            DropIndex("dbo.OS_CriterioAvaliacao", new[] { "IdOrdemServico" });         
            DropTable("dbo.OS_ItemAvaliacao");
            DropTable("dbo.OS_CriterioAvaliacao");
        }
    }
}
