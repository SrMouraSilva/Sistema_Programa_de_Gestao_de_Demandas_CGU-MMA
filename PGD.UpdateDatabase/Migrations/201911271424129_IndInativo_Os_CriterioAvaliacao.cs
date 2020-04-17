namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndInativo_Os_CriterioAvaliacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OS_CriterioAvaliacao", "Inativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OS_CriterioAvaliacao", "Inativo");
        }
    }
}
