﻿using PGD.Domain.Filtros.Base;

namespace PGD.Domain.Filtros
{
    public class UnidadeFiltro : BaseFiltro
    {
        public UnidadeFiltro()
        {
            OrdenarPor = "Nome";
        }

        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string NomeOuSigla { get; set; }
        public int? IdUnidadeSuperior { get; set; }
        public bool BuscarExcluidos { get; set; }
        public bool IncludeUnidadeSuperior { get; set; }
        public bool IncludeUnidadesFilhas { get; set; }
        public bool IncludeUnidadePerfisUnidades { get; set; }
        public bool IncludeUnidadeTiposPactos { get; set; }

    }
}