using DomainValidation.Validation;
using PGD.Domain.Entities.RH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Domain.Entities
{
    public class Unidade_TipoPacto
    {
        public Unidade_TipoPacto()
        {
            ValidationResult = new ValidationResult();
        }
        public int IdUnidade_TipoPacto { get; set; }        
        public int IdUnidade { get; set; }        
        [ForeignKey("TipoPacto")]
        public int IdTipoPacto { get; set; }
        public virtual TipoPacto TipoPacto { get; set; }
        public bool IndPermitePactoExterior { get; set; }        
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            return true;
        }
    }
}
