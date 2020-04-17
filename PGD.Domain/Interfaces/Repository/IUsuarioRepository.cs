using PGD.Domain.Entities;
using PGD.Domain.Entities.Usuario;

namespace PGD.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorNome(string nome);
        Usuario ObterPorCPF(string cpf);
        Usuario ObterPorEmail(string email);
    }
}
