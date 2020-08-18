using PGD.Domain.Entities.RH;

namespace PGD.Domain.Entities
{
    public class UsuarioPerfilUnidade
    {
        public long Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int IdUnidade { get; set; }
        public bool Excluido { get; set; }
        public virtual Usuario.Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}