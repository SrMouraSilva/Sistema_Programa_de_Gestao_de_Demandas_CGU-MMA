using PGD.Domain.Entities;
using PGD.Domain.Interfaces.Repository;
using PGD.Infra.Data.Context;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PGD.Infra.Data.Repository
{
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
    Justification = "False positive.")]
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {

        public OrdemServicoRepository(PGDDbContext context)
            : base(context)
        {

        }

        public void DeletarGrupos(OrdemServico ordemservico)
        {
            Db.OS_GrupoAtividade.RemoveRange(ordemservico.Grupos);
        }

        //public override OrdemServico ObterPorId(int id)
        //{
        //    return DbSet.AsNoTracking().Where(a => a.IdOrdemServico == id).FirstOrDefault();
        //}
    }
}
