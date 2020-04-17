namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkTextoExplicativoOS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OS_Atividade", "DescLinkAtividade", c => c.String(maxLength: 300, unicode: false));
            AddColumn("dbo.OS_TipoAtividade", "DescTextoExplicativo", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OS_TipoAtividade", "DescTextoExplicativo");
            DropColumn("dbo.OS_Atividade", "DescLinkAtividade");
        }
    }
}
