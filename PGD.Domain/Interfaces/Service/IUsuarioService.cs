using PGD.Domain.Entities;
using PGD.Domain.Entities.Usuario;
using System.Collections.Generic;

namespace PGD.Domain.Interfaces.Service
{
    public interface IUsuarioService 
    {
        IEnumerable<Usuario> ObterTodosAdministradores();
        Usuario ObterPorNome(string nome);
        Usuario ObterPorCPF(string cpf);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterTodosPorUnidade(int idUnidade, bool incluirSubordinados = false);
        IEnumerable<Usuario> ObterTodosDaBase();
    }
}
