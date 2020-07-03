using PGD.Domain.Entities.RH;
using PGD.Domain.Interfaces.Repository;
using PGD.Infra.Data.Context;

namespace PGD.Infra.Data.Repository
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(PGDDbContext context)
            : base(context)
        {

        }

    }
}
