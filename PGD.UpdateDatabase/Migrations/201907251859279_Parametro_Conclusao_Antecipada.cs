namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parametro_Conclusao_Antecipada : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                SET IDENTITY_INSERT [dbo].[ParametroSistema] ON; 

                INSERT INTO [dbo].[ParametroSistema]
                           ([IdParametroSistema]
		                   ,[DescParametroSistema]
                           ,[Valor])
                     VALUES
                           (9
		                   ,'Quantidades de dias para cálculo de data mínima para conclusão antecipada'
                           ,30)

                SET IDENTITY_INSERT [dbo].[ParametroSistema] OFF; 

            ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[ParametroSistema] Where IdParametroSistema = 9");  
        }
    }
}
