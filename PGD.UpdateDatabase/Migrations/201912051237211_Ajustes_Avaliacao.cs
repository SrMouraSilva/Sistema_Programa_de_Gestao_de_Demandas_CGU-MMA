namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes_Avaliacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotaAvaliacao", "Conceito", c => c.Int());

            Sql(@"
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 1 WHERE IdNotaAvaliacao = 5
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 2 WHERE IdNotaAvaliacao = 4
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 3 WHERE IdNotaAvaliacao = 3
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 4 WHERE IdNotaAvaliacao = 2
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 5 WHERE IdNotaAvaliacao = 1
                   update [PGD].[dbo].[NotaAvaliacao] SET Conceito = 6 WHERE IdNotaAvaliacao = 6

            ");

            AlterColumn("dbo.NotaAvaliacao", "Conceito", c => c.Int(nullable: false));

            AddColumn("dbo.AvaliacaoProduto", "NotaFinalAvaliacaoDetalhada", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AvaliacaoProduto", "NotaFinalAvaliacaoDetalhada");
            DropColumn("dbo.NotaAvaliacao", "Conceito");
        }
    }
}
