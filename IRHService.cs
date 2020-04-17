using PGD.Domain.Entities;
using PGD.Domain.Entities.RH;
using PGD.Domain.Entities.Usuario;
using PGD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Domain.Interfaces.Service
{
    public interface IRHService
    {
        IEnumerable<Perfil> ObterPerfis(Usuario objUsuario);

        #region CSU008_RN050
        IEnumerable<Unidade> ObterUnidades(int idTipoPacto = 0);
        Unidade ObterUnidade(int idUnidade);
        #endregion

        IEnumerable<Feriado> ObterFeriados(DateTime dtAPartirDe);

        bool VerificaFeriado(DateTime dataAVerificar);

        Feriado ObterFeriado(DateTime data);

        IEnumerable<Unidade> ObterUnidadesSubordinadas(int idUnidadePai);

        IEnumerable<Usuario> ObterDirigentesUnidade(int idUnidade);


    }
}
