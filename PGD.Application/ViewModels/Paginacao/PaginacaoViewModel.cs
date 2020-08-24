using System.Collections.Generic;

namespace PGD.Application.ViewModels.Paginacao
{
    public class PaginacaoViewModel<T>
    {
        public int QtRegistros { get; set; }
        public IEnumerable<T> Lista { get; set; }
    }
}