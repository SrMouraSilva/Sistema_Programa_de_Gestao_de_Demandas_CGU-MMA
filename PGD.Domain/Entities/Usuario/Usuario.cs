using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Domain.Entities.Usuario
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email{ get; set; }
        public int Unidade { get; set; }
        public string NomeUnidade { get; set; }
        public bool Administrador { get; set; }
        public bool Inativo { get; set; }

    }
}
