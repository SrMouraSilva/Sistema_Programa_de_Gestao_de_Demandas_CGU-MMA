using PGD.Domain.Enums;
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
            PerfisUnidades = new List<UsuarioPerfilUnidadeViewModel>();
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

        public bool Administrador => PerfilSelecionado.HasValue && PerfilSelecionado == Perfil.Administrador;

        public bool Inativo { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public List<Perfil> Perfis { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public ICollection<UsuarioPerfilUnidadeViewModel> PerfisUnidades { get; set; }

        public string DescricaoPerfil => $"{PerfilSelecionado.ToString()}{(Administrador ? " / Administrador" : "")}";

        public bool IsDirigente => PerfilSelecionado.HasValue && PerfilSelecionado == Perfil.Dirigente;


        public Perfil? PerfilSelecionado { get; private set; }
        public int? IdPerfilSelecionado => PerfilSelecionado?.GetHashCode();
        public int? IdUnidadeSelecionada { get; private set; }
        public string NomeUnidadeSelecionada { get; private set; }
        public string SiglaUnidadeSelecionada { get; private set; }

        public void AlterarPerfilSelecionado(Perfil perfil)
        {
            PerfilSelecionado = perfil;
        }

        public void AlterarUnidadeSelecionada(int idUnidade)
        {
            var unidade = PerfisUnidades.FirstOrDefault(x => x.IdUnidade == idUnidade);

            if (unidade != null)
            {
                IdUnidadeSelecionada = unidade.IdUnidade;
                NomeUnidadeSelecionada = unidade.NomeUnidade;
                SiglaUnidadeSelecionada = unidade.SiglaUnidade;
            }
        }

        public void SelecionarUnidadePerfil()
        {
            if (IdPerfilSelecionado.HasValue)
            {
                var unidade = PerfisUnidades.FirstOrDefault(x => x.IdPerfil == IdPerfilSelecionado);

                if (unidade != null)
                    AlterarUnidadeSelecionada(unidade.IdUnidade);
            }
        }
    }


}
