using PGD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PGD.Infra.Data.EntityConfig
{
    public class OS_GrupoAtividadeConfig : EntityTypeConfiguration<OS_GrupoAtividade>
    {

        public OS_GrupoAtividadeConfig()
        {
            HasKey(x => x.IdGrupoAtividade);
            Property(x => x.NomGrupoAtividade).IsRequired().HasMaxLength(500);

            Ignore(c => c.ValidationResult);
        }
    }
}
