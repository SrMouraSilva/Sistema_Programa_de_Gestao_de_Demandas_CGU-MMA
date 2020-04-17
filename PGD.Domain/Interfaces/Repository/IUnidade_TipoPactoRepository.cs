using PGD.Domain.Entities;

namespace PGD.Domain.Interfaces.Repository
{
    public interface IUnidade_TipoPactoRepository : IRepository<Unidade_TipoPacto>
    {
        Unidade_TipoPacto AdicionarSave(Unidade_TipoPacto obj);        
    }
}
