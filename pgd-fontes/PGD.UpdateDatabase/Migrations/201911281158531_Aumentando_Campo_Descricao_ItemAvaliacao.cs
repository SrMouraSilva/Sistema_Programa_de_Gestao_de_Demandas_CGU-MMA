namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aumentando_Campo_Descricao_ItemAvaliacao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemAvaliacao", "DescItemAvaliacao", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemAvaliacao", "DescItemAvaliacao", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
    }
}
