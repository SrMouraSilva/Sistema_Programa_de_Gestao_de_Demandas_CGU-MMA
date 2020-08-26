using PGD.Domain.Entities;
using PGD.Domain.Filtros;
using PGD.Domain.Interfaces.Repository;
using PGD.Domain.Paginacao;
using PGD.Infra.Data.Context;
using PGD.Infra.Data.Util;
using System.Data.Entity;
using System.Linq;

namespace PGD.Infra.Data.Repository
{
    public class UsuarioPerfilUnidadeRepository : Repository<UsuarioPerfilUnidade>, IUsuarioPerfilUnidadeRepository
    {
        public UsuarioPerfilUnidadeRepository(PGDDbContext context)
            : base(context)
        {

        }

        public Paginacao<UsuarioPerfilUnidade> Buscar(UsuarioPerfilUnidadeFiltro filtro)
        {
            var retorno = new Paginacao<UsuarioPerfilUnidade>();
            var query = DbSet.AsQueryable();

            if (filtro.IncludeUsuario)
                query.Include("Usuario");            
            
            if (filtro.IncludePerfil)
                query.Include("Perfil");            
            
            if (filtro.IncludeUnidade)
                query.Include("Unidade");

            if (filtro.IdUsuarioPerfilUnidade.HasValue)
                query = query.Where(x => x.Id == filtro.IdUsuarioPerfilUnidade);

            if (filtro.IdUsuario.HasValue)
                query = query.Where(x => x.IdUsuario == filtro.IdUsuario);

            if (filtro.SomenteNaoExcluidos)
                query = query.Where(x => !x.Excluido);

            retorno.QtRegistros = query.Count();

            if (filtro.Skip.HasValue && filtro.Take.HasValue)
            {
                retorno.Lista = filtro.OrdenarDescendente
                    ? query.OrderByDescending(filtro.OrdenarPor).Skip(filtro.Skip.Value).Take(filtro.Take.Value).ToList()
                    : query.OrderBy(filtro.OrdenarPor).Skip(filtro.Skip.Value).Take(filtro.Take.Value).ToList();
            }
            else
                retorno.Lista = query.ToList();

            return retorno;
        }
    }
}
