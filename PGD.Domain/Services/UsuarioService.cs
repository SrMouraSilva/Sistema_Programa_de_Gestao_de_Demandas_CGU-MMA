using System;
using System.Collections.Generic;
using PGD.Domain.Interfaces.Service;
using PGD.Domain.Entities.Usuario;
using System.Net;
using PGD.Domain.Interfaces.Repository;
using System.Linq;

namespace PGD.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AdministradorService _administradorService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(AdministradorService classRepository, IUsuarioRepository usuarioRepository)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            _administradorService = classRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObterTodosAdministradores()
        {
            var listaUser = new List<Usuario>();
            var listaAm = _administradorService.ObterTodosAdm();
            foreach (var item in listaAm)
            {
                var user = new Usuario();
                var cpf_user = item.CPF;
                if (item.CPF.Length < 11)
                    cpf_user = item.CPF.PadLeft(11, '0');
                user = ObterPorCPF(cpf_user);
                listaUser.Add(user);
            }
            return listaUser;
        }
        public Usuario ObterPorNome(string nome)
        {
            var user = _usuarioRepository.ObterPorNome(nome);

            return user;
        }

        public Usuario ObterPorCPF(string cpf)
        {
            var user = _usuarioRepository.ObterTodos().FirstOrDefault(usuario => usuario.CPF.Equals(cpf));

            return user;
        }

        public IEnumerable<Usuario> ObterTodosPorUnidade(int IdUnidade, bool incluirSubordinados = false)
        {

            var lista = _usuarioRepository.ObterTodos();

            return lista;

        }
        public IEnumerable<Usuario> ObterTodosDaBase()
        {
            var lista = _usuarioRepository.ObterTodos();

            return lista;

        }

        public string RetornaCpfCorrigido(string cpf)
        {
            var CpfCorrigido = string.Empty;
            if (!String.IsNullOrEmpty(cpf))
            {
                if (cpf.Length < 11)
                    CpfCorrigido = cpf.PadLeft(11, '0');
                else

                    CpfCorrigido = cpf;
            }
            return CpfCorrigido;
        }

        //Não tem implementação da API
        public IEnumerable<Usuario> ObterDirigentesUnidade(int idUnidadePai)
        {
            var lista = _usuarioRepository.ObterTodos();

            return lista;
        }

        public Usuario ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
