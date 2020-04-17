namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisualizacaoRestritaPacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacto", "IndVisualizacaoRestrita", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.Pacto", "JustificativaVisualizacaoRestrita", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacto", "JustificativaVisualizacaoRestrita");
            DropColumn("dbo.Pacto", "IndVisualizacaoRestrita");
        }
    }
}
