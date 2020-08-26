﻿using PGD.Application.ViewModels.Filtros.Base;

namespace PGD.Application.ViewModels.Filtros
{
    public class UnidadeFiltroViewModel : BaseFiltroViewModel
    {
        public UnidadeFiltroViewModel()
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