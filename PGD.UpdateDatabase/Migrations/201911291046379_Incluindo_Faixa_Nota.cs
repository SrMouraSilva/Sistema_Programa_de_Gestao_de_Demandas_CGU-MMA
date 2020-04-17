namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incluindo_Faixa_Nota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotaAvaliacao", "LimiteSuperiorFaixa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NotaAvaliacao", "LimiteInferiorFaixa", c => c.Decimal(nullable: false, precision: 18, scale: 2));

            Sql(@"
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 10, LimiteInferiorFaixa = 9.5 WHERE IdNotaAvaliacao = 1
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 9.4, LimiteInferiorFaixa = 8.5 WHERE IdNotaAvaliacao = 2
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 8.4, LimiteInferiorFaixa = 6.5 WHERE IdNotaAvaliacao = 3
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 6.4, LimiteInferiorFaixa = 5 WHERE IdNotaAvaliacao = 4
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 4.9, LimiteInferiorFaixa = 0.0 WHERE IdNotaAvaliacao = 5
                UPDATE dbo.NotaAvaliacao SET LimiteSuperiorFaixa = 0, LimiteInferiorFaixa = 0 WHERE IdNotaAvaliacao = 6
            ");

        }
        
        public override void Down()
        {
            DropColumn("dbo.NotaAvaliacao", "LimiteInferiorFaixa");
            DropColumn("dbo.NotaAvaliacao", "LimiteSuperiorFaixa");
        }
    }
}
