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

        public List<Domain.Enums.Perfil> Perfis { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public string DescricaoPerfil => $"{Perfis.FirstOrDefault().ToString()}{(Administrador ? " / Administrador" : "")}";

        public bool IsDirigente => Perfis.Any(x => x == Domain.Enums.Perfil.Dirigente);
    }


}
