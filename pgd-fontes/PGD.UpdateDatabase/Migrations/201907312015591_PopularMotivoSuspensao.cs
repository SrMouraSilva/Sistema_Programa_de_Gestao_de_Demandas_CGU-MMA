namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularMotivoSuspensao : DbMigration
    {
        public override void Up()
        {
            Sql("update Pacto set Motivo = 'N�o Informado' where SuspensoAPartirDe is not null and Motivo is null ");
        }
        
        public override void Down()
        {
        }
    }
}
