using PGD.Domain.Entities;
using PGD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Domain.Entities.RH
{
    public class RecursosHumanos
    {
        public int IdRecursosHumanos { get; set; }
        public int IdUnidade { get; set; }
        public int IdPerfil { get; set; }
        public Unidade Unidade { get; set; }
        public PGD.Domain.Enums.Perfil Perfil { get; set; }
    }
}
