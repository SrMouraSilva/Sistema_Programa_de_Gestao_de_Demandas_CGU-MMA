using System;
using PGD.Domain.Entities;
using PGD.Domain.Interfaces.Repository;
using PGD.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using PGD.Domain.Entities.Usuario;
using System.Diagnostics.CodeAnalysis;

namespace PGD.Infra.Data.Repository
{
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
    Justification = "False positive.")]
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(PGDDbContext context)
            : base(context)
        {

        }

        public Usuario ObterPorCPF(string cpf)
        {
            cpf = cpf.PadLeft(11, '0');
            var usuario = DbSet.AsNoTracking().Where(a => a.CPF.Replace("\r", string.Empty).Replace("\n", string.Empty) == cpf).FirstOrDefault();
            if (usuario == null)
            {
                long novocpf;
                if (long.TryParse(cpf, out novocpf))
                {
                    cpf = novocpf.ToString();
                    usuario = DbSet.AsNoTracking().Where(a => a.CPF.Replace("\r", string.Empty).Replace("\n", string.Empty) == cpf).FirstOrDefault();
                }

            }
            return usuario;
        }

        public Usuario ObterPorEmail(string email)
        {
            return DbSet.AsNoTracking().Where(a => a.Email.Replace("\r", string.Empty).Replace("\n", string.Empty) == email).FirstOrDefault();
        }

        public Usuario ObterPorNome(string nome)
        {
           
            return DbSet.AsNoTracking().Where(a => a.Nome.Trim().ToLower().Contains(nome.Trim().ToLower())).FirstOrDefault();
        }

        public override Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

    }
}
