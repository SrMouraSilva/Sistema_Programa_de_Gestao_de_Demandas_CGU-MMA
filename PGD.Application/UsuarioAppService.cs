﻿using AutoMapper;
using PGD.Application.Interfaces;
using PGD.Application.ViewModels;
using PGD.Domain.Entities;
using PGD.Domain.Entities.Usuario;
using PGD.Domain.Interfaces.Service;
using PGD.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGD.Application
{
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogService _logService;
        private readonly IAdministradorService _admService;
        private readonly IPerfilService _perfilService;

        public UsuarioAppService(IUsuarioService usuarioService, IUnitOfWork uow, ILogService logService, IPerfilService perfilService, IAdministradorService admService)
            : base(uow)
        {
            _usuarioService = usuarioService;
            _logService = logService;
            _perfilService = perfilService;
            _admService = admService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel ObterPorNome(string nome)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.ObterPorNome(nome));
        }

        public UsuarioViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.ObterPorEmail(email));
        }

        public UsuarioViewModel ObterPorCPF(string cpf)
        {
            var eAdm = new Administrador();
            var user = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.ObterPorCPF(cpf));
            if (cpf.Length < 11)
                eAdm = _admService.ObterTodosAdm().FirstOrDefault(a => a.CPF.Replace("\r", string.Empty).Replace("\n", string.Empty) == cpf.PadLeft(11, '0'));
            else
            {
                eAdm = _admService.ObterTodosAdm().Where(a => a.CPF.Replace("\r", string.Empty).Replace("\n", string.Empty) == cpf).FirstOrDefault();
            }
            if (eAdm != null)
                user.Administrador = true;

            return user;
        }

        public UsuarioViewModel ObterUsuarioComPerfilPorCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return null;

            cpf = cpf.Replace(".", "").Replace("-", "");
            var usuario = _usuarioService.ObterPorCPF(cpf);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            usuarioViewModel.PerfisUnidades = usuario.UsuariosPerfisUnidades.Where(x => !x.Excluido).Select(x => new UsuarioPerfilUnidadeViewModel
            {
                Id = x.Id,
                IdPerfil = x.IdPerfil,
                IdUnidade = x.IdUnidade,
                NomePerfil = x.Perfil.Nome,
                NomeUnidade = x.Unidade.Nome,
                SiglaUnidade = x.Unidade.Sigla,
                IdUsuario = x.IdUsuario
            }).ToList();

            return usuarioViewModel;
        }

        public UsuarioViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioViewModel> ObterTodos(int idUnidade, bool incluirSubordinados = false)
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodosPorUnidade(idUnidade, incluirSubordinados));
        }
        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodosDaBase());
        }

        public UsuarioViewModel Remover(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Enums.Perfil> ObterPerfis(UsuarioViewModel usuario)
        {
            return new List<Domain.Enums.Perfil>();
        }

        public UsuarioViewModel TornarRemoverAdministrador(UsuarioViewModel usuario, bool admin)
        {
            usuario.Administrador = admin;
            if (usuario.ValidationResult.IsValid)
                if (admin)
                {
                    var adm = new Administrador();
                    adm.CPF = usuario.CPF;
                    BeginTransaction();
                    _admService.Adicionar(adm);
                    Commit();
                    usuario.ValidationResult.Message = PGD.Domain.Constantes.Mensagens.MS_001;
                }
                else
                {
                    var obj = new Administrador();
                    obj = _admService.ObterTodosAdm().FirstOrDefault(a => a.CPF.Equals(usuario.CPF));
                    BeginTransaction();
                    _admService.Remover(obj);
                    Commit();
                    usuario.ValidationResult.Message = PGD.Domain.Constantes.Mensagens.MS_002;
                }
            return usuario;
        }

        public IEnumerable<UsuarioViewModel> ObterTodosAdministradores()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodosAdministradores());
        }

        public bool PodeSelecionarPerfil(UsuarioViewModel usuario)
        {
            return usuario.PerfisUnidades.Select(x => x.PerfilEnum).Distinct().ToList().Count > 1;
        }

        public bool PodeSelecionarUnidade(UsuarioViewModel usuario)
        {
            // RNG007 se o perfil for Dirigente ou Administrador e possuir mais de uma unidade, selecionar unidade
            if (usuario.PerfilSelecionado == Domain.Enums.Perfil.Administrador || usuario.PerfilSelecionado == Domain.Enums.Perfil.Dirigente)
            {
                var idPerfilSelecionado = usuario.IdPerfilSelecionado;
                return usuario.PerfisUnidades.Where(x => x.IdPerfil == idPerfilSelecionado).Count() > 1;
            }

            return false;
        }

        List<Domain.Enums.Perfil> IUsuarioAppService.ObterPerfis(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
