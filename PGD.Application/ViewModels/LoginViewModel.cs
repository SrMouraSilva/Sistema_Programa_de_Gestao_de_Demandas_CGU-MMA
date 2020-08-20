using System.ComponentModel.DataAnnotations;

namespace PGD.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo CPF é de preenchimento obrigatório!")]
        [StringLength(14)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Senha é de preenchimento obrigatório!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
