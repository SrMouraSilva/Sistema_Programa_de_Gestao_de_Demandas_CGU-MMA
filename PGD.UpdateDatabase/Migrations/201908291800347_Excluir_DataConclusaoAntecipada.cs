namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Excluir_DataConclusaoAntecipada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AvaliacaoProduto", "DataConclusaoAntecipada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AvaliacaoProduto", "DataConclusaoAntecipada", c => c.DateTime());
        }
    }
}
