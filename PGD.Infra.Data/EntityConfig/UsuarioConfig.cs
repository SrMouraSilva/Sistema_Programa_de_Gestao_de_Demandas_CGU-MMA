using PGD.Domain.Entities.Usuario;
using System.Data.Entity.ModelConfiguration;

namespace PGD.Infra.Data.EntityConfig
{
    class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(x => x.IdUsuario);
            Property(x => x.Matricula).IsOptional();
            Property(x => x.CPF).IsOptional();
            Property(x => x.Nome).IsOptional();
            Property(x => x.Email).IsOptional();
            Property(x => x.Unidade).IsOptional();
            Property(x => x.NomeUnidade).IsOptional();
            Property(x => x.Administrador).IsOptional();
            Property(x => x.Inativo).IsOptional();
        }
    }
}
