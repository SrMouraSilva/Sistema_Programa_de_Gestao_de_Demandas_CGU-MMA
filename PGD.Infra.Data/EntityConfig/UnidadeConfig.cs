using PGD.Domain.Entities.RH;
using System.Data.Entity.ModelConfiguration;

namespace PGD.Infra.Data.EntityConfig
{
    public class UnidadeConfig : EntityTypeConfiguration<Unidade>
    {       
        public UnidadeConfig()
        {
            HasKey(x => x.IdUnidade);
            Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);
            Property(x => x.Codigo).IsRequired();
            Property(x => x.Sigla).IsOptional()
                .HasColumnType("varchar")
                .HasMaxLength(25);
            Property(x => x.Excluido).IsOptional();
        }
    }
}
