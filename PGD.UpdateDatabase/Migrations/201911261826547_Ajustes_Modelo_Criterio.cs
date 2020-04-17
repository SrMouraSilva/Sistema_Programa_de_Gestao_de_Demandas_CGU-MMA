namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes_Modelo_Criterio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotaAvaliacao", "IndAtivoAvaliacaoSimplificada", c => c.Boolean(nullable: false));
            AddColumn("dbo.NotaAvaliacao", "IndAtivoAvaliacaoDetalhada", c => c.Boolean(nullable: false));
            AddColumn("dbo.CriterioAvaliacao", "Inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.ItemAvaliacao", "Inativo", c => c.Boolean(nullable: false));

            Sql(@"
                    update dbo.NotaAvaliacao set IndAtivoAvaliacaoDetalhada = 1 where IdNotaAvaliacao <= 5
                    update dbo.NotaAvaliacao set IndAtivoAvaliacaoSimplificada = 1
                ");

        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemAvaliacao", "Inativo");
            DropColumn("dbo.CriterioAvaliacao", "Inativo");
            DropColumn("dbo.NotaAvaliacao", "IndAtivoAvaliacaoDetalhada");
            DropColumn("dbo.NotaAvaliacao", "IndAtivoAvaliacaoSimplificada");
        }
    }
}
