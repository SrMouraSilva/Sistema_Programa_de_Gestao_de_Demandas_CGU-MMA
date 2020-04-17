namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoCargaHorariaAlterada : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE [dbo].[Pacto] DROP CONSTRAINT DF__Pacto__CargaHora__4222D4EF");
            AlterColumn("dbo.Pacto", "CargaHoraria", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacto", "CargaHoraria", c => c.Int(nullable: false));
        }
    }
}
