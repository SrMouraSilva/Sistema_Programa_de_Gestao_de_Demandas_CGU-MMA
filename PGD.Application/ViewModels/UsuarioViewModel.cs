﻿using PGD.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PGD.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Perfis = new List<Domain.Enums.Perfil>();
        }

        public int IdUsuario { get; set; }

        public string CpfUsuario { get; set; }

        [StringLength(100)]
        [Required]
        public string Matricula { get; set; }

        [Required]
        [StringLength(100)]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public int Unidade { get; set; }

        public int IdUnidade { get; set; }

        public string nomeUnidade { get; set; }

        public bool Administrador { get; set; }

        public bool Inativo { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public List<Perfil> Perfis { get; set; }

        public Perfil? PerfilSelecionado { get; set; }

        public int? IdUnidadeSelecionada { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public string DescricaoPerfil => $"{Perfis.FirstOrDefault().ToString()}{(Administrador ? " / Administrador" : "")}";

        public bool IsDirigente => PerfilSelecionado.HasValue && PerfilSelecionado == Perfil.Dirigente;

        public void AlterarPerfilSelecionado(Perfil perfil)
        {
            PerfilSelecionado = perfil;
        }

        public void AlterarUnidadeSelecionada(int idUnidade)
        {
            IdUnidadeSelecionada = idUnidade;
        }

        public void SelecionarUnidadePadrao()
        {
            IdUnidadeSelecionada = 0;
        }
    }


}
