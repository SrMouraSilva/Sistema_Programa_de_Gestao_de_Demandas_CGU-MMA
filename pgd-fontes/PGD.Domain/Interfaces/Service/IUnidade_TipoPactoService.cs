using PGD.Domain.Entities;
using System.Collections.Generic;

namespace PGD.Domain.Interfaces.Service
{
    public interface IUnidade_TipoPactoService : IService<Unidade_TipoPacto>
    {
        IEnumerable<Unidade_TipoPacto> ObterTodosPorTipoPacto(int idTipoPacto);
        Unidade_TipoPacto BuscarPorIdUnidadeTipoPacto(int idUnidade, int idTipoPacto);
    }
}
