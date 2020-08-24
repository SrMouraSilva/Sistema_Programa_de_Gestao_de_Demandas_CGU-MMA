using PGD.Domain.Filtros.Base;

namespace PGD.Domain.Filtros
{
    public class UsuarioFiltro : BaseFiltro
    {
        public UsuarioFiltro()
        {
            OrdenarPor = "Nome";
        }

        public string Nome { get; set; }
        public string Matricula { get; set; }
        public int? IdUnidade { get; set; }
        public bool IncludeUnidadesPerfis { get; set; }
    }
}