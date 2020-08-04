using PGD.Domain.Entities.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Domain.Interfaces.Service
{
    public interface IUnidadeService : IService<Unidade>
    {
        IEnumerable<Unidade> ObterUnidades(int idTipoPacto = 0);
        IEnumerable<Unidade> ObterUnidadesSubordinadas(int idUnidadePai);
        Unidade ObterUnidade(int idUnidade);


    }
}
