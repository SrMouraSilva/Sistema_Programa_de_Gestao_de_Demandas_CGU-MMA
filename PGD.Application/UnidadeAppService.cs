using PGD.Application.Interfaces;
using PGD.Domain.Entities.RH;
using PGD.Domain.Interfaces.Service;
using PGD.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Application
{
    public class UnidadeAppService : ApplicationService, IUnidadeAppService
    {
        private readonly IUnidadeService _unidadeService;

        public UnidadeAppService(IUnidadeService unidadeService, IUnitOfWork uow)
            : base(uow)
        {
            _unidadeService = unidadeService;
        }

        public Unidade Adicionar(Unidade obj)
        {
            throw new NotImplementedException();
        }

        public Unidade Atualizar(Unidade obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Unidade> Buscar(Expression<Func<Unidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Unidade ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Unidade> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Unidade> ObterTodos(string strInclude)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
