using PGD.Domain.Entities.RH;
using System.Data.Entity.ModelConfiguration;

namespace PGD.Infra.Data.EntityConfig
{
    class RecursosHumanosConfig : EntityTypeConfiguration<RecursosHumanos>
    {
        public RecursosHumanosConfig()
        {
            HasKey(x => x.IdRecursosHumanos);
            Property(x => x.IdUnidade).IsOptional();
            Property(x => x.IdPerfil).IsOptional();
        }
    }
}
