using PGD.Domain.Entities;
using PGD.Domain.Interfaces.Repository;
using PGD.Infra.Data.Context;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using RefactorThis.GraphDiff;
using PGD.Domain.Services;

namespace PGD.Infra.Data.Repository
{
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
    Justification = "False positive.")]
    public class PactoRepository : Repository<Pacto>, IPactoRepository
    {
        UnidadeService _unidadeService;
        IIniciativaPlanoOperacionalRepository _iniciativaPORepository;

        public PactoRepository(PGDDbContext context, UnidadeService unidadeService, IIniciativaPlanoOperacionalRepository iniciativaPORepository)
            : base(context)
        {
            this._unidadeService = unidadeService;
            this._iniciativaPORepository = iniciativaPORepository;
        }

        public Pacto BuscarPorId(int id)
        {
            return   DbSet.AsNoTracking().Include("Produtos")
                .Include("OrdemServico")
                .Include("Historicos")
                .Include("Produtos.GrupoAtividade")
                .Include("Produtos.Atividade")
                .Include("Produtos.TipoAtividade")
                .Include("Cronogramas")
                .Where(a => a.IdPacto == id).FirstOrDefault();
        }

        public override IEnumerable<Pacto> Buscar(Expression<Func<Pacto, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public override Pacto ObterPorId(int id)
        {
            return DbSet.AsNoTracking().Where(a => a.IdPacto == id).FirstOrDefault();
        }

        public void AtualizaEstadoEntidadesRelacionadas(Pacto pacto)
        {
            Db.UpdateGraph(pacto, m => m.OwnedCollection(p => p.Produtos, with => with.OwnedCollection(p2 => p2.IniciativasPlanoOperacionalProduto).OwnedCollection(p2 => p2.Avaliacoes, with2 => with2.OwnedCollection(p3 => p3.AvaliacoesDetalhadas))).OwnedCollection(p => p.Cronogramas));
        }
        public IEnumerable<Pacto> ConsultarPactos(Pacto objFiltro, bool incluirUnidadesSubordinadas = false)
        {
            var query = DbSet.AsNoTracking().Include("Produtos")
                .Include("OrdemServico")
                .Include("Historicos")
                .Include("Produtos.GrupoAtividade")
                .Include("Produtos.Atividade")
                .Include("Produtos.TipoAtividade")
                .Include("Cronogramas")
                .Include("SituacaoPacto")
                .Include("TipoPacto").AsQueryable();

            if (objFiltro.IdPacto > 0)
            {
                query = query.Where(x => x.IdPacto == objFiltro.IdPacto);
            }

            if (!string.IsNullOrEmpty(objFiltro.Nome))
            {
                query = query.Where(x => x.Nome.Contains(objFiltro.Nome));
            }

            if (objFiltro.UnidadeExercicio > 0)
            {
                if (incluirUnidadesSubordinadas)
                {
                    var unidadesSubordinadas = _unidadeService.ObterUnidadesSubordinadas(objFiltro.UnidadeExercicio);
                    var idsUnidadesSubordinadas = unidadesSubordinadas.Select(us => us.IdUnidade).ToList();
                    // query = query.Where(x => idsUnidadesSubordinadas.Contains(x.UnidadeExercicio));
                }
                else
                {
                    query = query.Where(x => x.UnidadeExercicio == objFiltro.UnidadeExercicio);
                }
            }
            if (objFiltro.IdSituacaoPacto > 0)
            {
                query = query.Where(x => x.IdSituacaoPacto == objFiltro.IdSituacaoPacto);
            }

            if (objFiltro.IdTipoPacto > 0)
            {
                query = query.Where(x => x.IdTipoPacto == objFiltro.IdTipoPacto);
            }

            if (objFiltro.DataPrevistaInicio > DateTime.MinValue && objFiltro.DataPrevistaTermino > DateTime.MinValue)
            {
                query = query.Where(x => x.DataPrevistaInicio >= objFiltro.DataPrevistaInicio && x.DataPrevistaTermino <= objFiltro.DataPrevistaTermino);
            }
            else if (objFiltro.DataPrevistaInicio > DateTime.MinValue && objFiltro.DataPrevistaTermino == DateTime.MinValue)
            {
                query = query.Where(x => x.DataPrevistaInicio >= objFiltro.DataPrevistaInicio);
            }
            else if (objFiltro.DataPrevistaInicio == DateTime.MinValue && objFiltro.DataPrevistaTermino > DateTime.MinValue)
            {
                query = query.Where(x => x.DataPrevistaTermino <= objFiltro.DataPrevistaTermino);
            }

            return query.AsEnumerable();

        }
         
    }
}
