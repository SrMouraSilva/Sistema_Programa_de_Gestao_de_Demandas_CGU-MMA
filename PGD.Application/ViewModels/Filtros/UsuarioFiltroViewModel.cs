using PGD.Application.ViewModels.Filtros.Base;

namespace PGD.Application.ViewModels.Filtros
{
    public class UsuarioFiltroViewModel : BaseFiltroViewModel
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public int? IdUnidade { get; set; }
        public bool IncludeUnidadesPerfis { get; set; }

    }
}