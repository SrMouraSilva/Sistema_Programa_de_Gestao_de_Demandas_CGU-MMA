namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteTamanhoTextoExplicativo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Atividade", "DescLinkAtividade", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.TipoAtividade", "DescTextoExplicativo", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Atividade", "DescLinkAtividade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.TipoAtividade", "DescTextoExplicativo", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
