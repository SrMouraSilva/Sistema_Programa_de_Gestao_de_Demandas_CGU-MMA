using PGD.Domain.Entities.RH;
using System.Data.Entity.ModelConfiguration;

namespace PGD.Infra.Data.EntityConfig
{
    public class UnidadeConfig : EntityTypeConfiguration<Unidade>
    {       
        public UnidadeConfig()
        {
            HasKey(x => x.IdUnidade);
            Property(x => x.Nome).IsOptional();
            Property(x => x.Codigo).IsOptional();
        }
    }
}
