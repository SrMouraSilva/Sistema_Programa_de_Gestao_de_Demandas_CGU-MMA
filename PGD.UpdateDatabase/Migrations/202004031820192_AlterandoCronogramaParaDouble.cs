namespace PGD.DatabaseUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoCronogramaParaDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OS_TipoAtividade", "DuracaoFaixa", c => c.Double(nullable: false));
            AlterColumn("dbo.OS_TipoAtividade", "DuracaoFaixaPresencial", c => c.Double(nullable: false));
            AlterColumn("dbo.TipoAtividade", "DuracaoFaixa", c => c.Double(nullable: false));
            AlterColumn("dbo.TipoAtividade", "DuracaoFaixaPresencial", c => c.Double(nullable: false));
            AlterColumn("dbo.Cronograma", "HorasCronograma", c => c.Double(nullable: false));
            AlterColumn("dbo.Cronograma", "DuracaoFeriado", c => c.Double());
            AlterColumn("dbo.Pacto", "CargaHorariaTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Produto", "CargaHorariaProduto", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "CargaHorariaProduto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Pacto", "CargaHorariaTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Cronograma", "DuracaoFeriado", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Cronograma", "HorasCronograma", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TipoAtividade", "DuracaoFaixaPresencial", c => c.Decimal(nullable: false, precision: 6, scale: 2));
            AlterColumn("dbo.TipoAtividade", "DuracaoFaixa", c => c.Decimal(nullable: false, precision: 6, scale: 2));
            AlterColumn("dbo.OS_TipoAtividade", "DuracaoFaixaPresencial", c => c.Decimal(nullable: false, precision: 6, scale: 2));
            AlterColumn("dbo.OS_TipoAtividade", "DuracaoFaixa", c => c.Decimal(nullable: false, precision: 6, scale: 2));
        }
    }
}
