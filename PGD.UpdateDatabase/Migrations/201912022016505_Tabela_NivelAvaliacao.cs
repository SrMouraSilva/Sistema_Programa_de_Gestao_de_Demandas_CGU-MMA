namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_NivelAvaliacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NivelAvaliacao",
                c => new
                    {
                        IdNivelAvaliacao = c.Int(nullable: false, identity: false),
                        DescNivelAvaliacao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdNivelAvaliacao);

            Sql(@"
                    INSERT INTO dbo.NivelAvaliacao (IdNivelAvaliacao, DescNivelAvaliacao) VALUES (1, 'Simplificada')
                    INSERT INTO dbo.NivelAvaliacao (IdNivelAvaliacao, DescNivelAvaliacao) VALUES (2, 'Detalhada')
                ");
           
        }
        
        public override void Down()
        {   
            DropTable("dbo.NivelAvaliacao");
        }
    }
}
