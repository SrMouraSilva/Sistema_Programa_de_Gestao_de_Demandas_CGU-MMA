using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Application.ViewModels
{
    public class Unidade_TipoPactoViewModel
    {

        public int IdUnidade_TipoPacto { get; set; }
        [Required(ErrorMessage ="A unidade deve ser selecionada")]
        public int IdUnidade { get; set; }
        [Required(ErrorMessage = "O tipo de pacto deve ser selecionado")]
        public int IdTipoPacto { get; set; }
        public bool IndPermitePactoExterior { get; set; }

    }
}
