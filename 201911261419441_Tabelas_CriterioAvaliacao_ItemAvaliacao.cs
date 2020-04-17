namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas_CriterioAvaliacao_ItemAvaliacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriterioAvaliacao",
                c => new
                    {
                        IdCriterioAvaliacao = c.Int(nullable: false, identity: true),
                        DescCriterioAvaliacao = c.String(nullable: false, maxLength: 100, unicode: false),
                        StrTextoExplicativo = c.String(nullable: false, maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.IdCriterioAvaliacao);
            
            CreateTable(
                "dbo.ItemAvaliacao",
                c => new
                    {
                        IdItemAvaliacao = c.Int(nullable: false, identity: true),
                        DescItemAvaliacao = c.String(nullable: false, maxLength: 100, unicode: false),
                        ImpactoNota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdNotaMaxima = c.Int(nullable: false),
                        IdCriterioAvaliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdItemAvaliacao)
                .ForeignKey("dbo.CriterioAvaliacao", t => t.IdCriterioAvaliacao)
                .ForeignKey("dbo.NotaAvaliacao", t => t.IdNotaMaxima)
                .Index(t => t.IdNotaMaxima)
                .Index(t => t.IdCriterioAvaliacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemAvaliacao", "IdNotaMaxima", "dbo.NotaAvaliacao");
            DropForeignKey("dbo.ItemAvaliacao", "IdCriterioAvaliacao", "dbo.CriterioAvaliacao");
            DropIndex("dbo.ItemAvaliacao", new[] { "IdCriterioAvaliacao" });
            DropIndex("dbo.ItemAvaliacao", new[] { "IdNotaMaxima" });
            DropTable("dbo.ItemAvaliacao");
            DropTable("dbo.CriterioAvaliacao");
        }
    }
}
