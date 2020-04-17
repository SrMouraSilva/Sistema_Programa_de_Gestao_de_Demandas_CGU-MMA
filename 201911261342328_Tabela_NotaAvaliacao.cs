namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_NotaAvaliacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaAvaliacao",
                c => new
                    {
                        IdNotaAvaliacao = c.Int(nullable: false, identity: false),
                        DescNotaAvaliacao = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.IdNotaAvaliacao);

            Sql(@"
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (1, 'Excelente')
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (2, 'Muito Bom')
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (3, 'Bom')
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (4, 'Regular')
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (5, 'Insatisfatório')
                INSERT INTO [dbo].[NotaAvaliacao] ([IdNotaAvaliacao], [DescNotaAvaliacao]) VALUES (6, 'Não Entregue')
            ");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotaAvaliacao");
        }
    }
}
