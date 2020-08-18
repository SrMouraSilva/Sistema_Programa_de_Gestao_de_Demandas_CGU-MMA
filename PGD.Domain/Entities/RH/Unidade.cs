using System.Collections.Generic;

namespace PGD.Domain.Entities.RH
{
    public class Unidade
    {
        #region CSU0008_RN050
        public int IdUnidade { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        #endregion
        public string Sigla { get; set; }
        public bool Excluido { get; set; }
        public virtual ICollection<UsuarioPerfilUnidade> UsuariosPerfisUnidades { get; set; }
    }
}
