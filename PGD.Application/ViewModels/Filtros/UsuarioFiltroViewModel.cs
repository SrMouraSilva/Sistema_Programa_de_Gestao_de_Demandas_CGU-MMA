using PGD.Application.ViewModels.Filtros.Base;

namespace PGD.Application.ViewModels.Filtros
{
    public class UsuarioFiltroViewModel : BaseFiltroViewModel
    {
        public UsuarioFiltroViewModel()
        {
            OrdenarPor = "Nome";
        }

        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public int? IdUnidade { get; set; }
        public bool IncludeUnidadesPerfis { get; set; }

    }
}