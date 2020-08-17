using PGD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorId(int id);
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel Remover(UsuarioViewModel usuarioViewModel);

        UsuarioViewModel ObterPorNome(string nome);
        UsuarioViewModel ObterPorEmail(string email);
        UsuarioViewModel ObterPorCPF(string cpf);
        IEnumerable<UsuarioViewModel> ObterTodos(int idUnidade, bool incluirSubordinados = false);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel TornarRemoverAdministrador(UsuarioViewModel usuario, bool admin);

        List<PGD.Domain.Enums.Perfil> ObterPerfis(UsuarioViewModel usuario);
        IEnumerable<UsuarioViewModel> ObterTodosAdministradores();

        bool PodeSelecionarPerfil(UsuarioViewModel usuario);
        bool PodeSelecionarUnidade(UsuarioViewModel usuario);
    }
}
