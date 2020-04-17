namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Campo_NivelAvaliacao_Em_AvaliacaoProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvaliacaoProduto", "IdNivelAvaliacao", c => c.Int(nullable: true));            
            AddForeignKey("dbo.AvaliacaoProduto", "IdNivelAvaliacao", "dbo.NivelAvaliacao", "IdNivelAvaliacao");
            Sql(@"update dbo.AvaliacaoProduto SET IdNivelAvaliacao = 1 WHERE IdNivelAvaliacao IS NULL");
            AlterColumn("dbo.AvaliacaoProduto", "IdNivelAvaliacao", c => c.Int(nullable: false));
            CreateIndex("dbo.AvaliacaoProduto", "IdNivelAvaliacao");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvaliacaoProduto", "IdNivelAvaliacao", "dbo.NivelAvaliacao");
            DropIndex("dbo.AvaliacaoProduto", new[] { "IdNivelAvaliacao" });
            DropColumn("dbo.AvaliacaoProduto", "IdNivelAvaliacao");
        }
    }
}
