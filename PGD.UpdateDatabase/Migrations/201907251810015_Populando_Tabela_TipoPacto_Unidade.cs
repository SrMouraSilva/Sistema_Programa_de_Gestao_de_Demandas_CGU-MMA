namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populando_Tabela_TipoPacto_Unidade : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO [dbo].[Unidade_TipoPacto]
               ([IdUnidade]
               ,[IdTipoPacto]
               ,[IndPermitePactoExterior])
                SELECT DISTINCT id_unidade, 1, 0
                FROM  [dbo].[Unidade]

            ");
        }
        
        public override void Down()
        {            
        }
    }
}
