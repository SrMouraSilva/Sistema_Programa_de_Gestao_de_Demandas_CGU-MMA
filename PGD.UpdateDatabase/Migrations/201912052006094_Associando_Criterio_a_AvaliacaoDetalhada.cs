namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Associando_Criterio_a_AvaliacaoDetalhada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvaliacaoDetalhadaProduto", "IdOS_CriterioAvaliacao", c => c.Int(nullable: false));
            CreateIndex("dbo.AvaliacaoDetalhadaProduto", "IdOS_CriterioAvaliacao");
            AddForeignKey("dbo.AvaliacaoDetalhadaProduto", "IdOS_CriterioAvaliacao", "dbo.OS_CriterioAvaliacao", "IdCriterioAvaliacao");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvaliacaoDetalhadaProduto", "IdOS_CriterioAvaliacao", "dbo.OS_CriterioAvaliacao");
            DropIndex("dbo.AvaliacaoDetalhadaProduto", new[] { "IdOS_CriterioAvaliacao" });
            DropColumn("dbo.AvaliacaoDetalhadaProduto", "IdOS_CriterioAvaliacao");
        }
    }
}
