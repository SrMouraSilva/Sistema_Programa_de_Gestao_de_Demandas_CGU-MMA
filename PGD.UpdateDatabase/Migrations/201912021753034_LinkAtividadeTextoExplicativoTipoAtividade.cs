namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkAtividadeTextoExplicativoTipoAtividade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atividade", "DescLinkAtividade", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.TipoAtividade", "DescTextoExplicativo", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoAtividade", "DescTextoExplicativo");
            DropColumn("dbo.Atividade", "DescLinkAtividade");
        }
    }
}
