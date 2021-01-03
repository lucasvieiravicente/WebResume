using lucasvieiravicentenetcore.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace lucasvieiravicentenetcore.Models
{
    public class EmailViewModel
    {       
        [Required(ErrorMessage = ErrorMessages.NameNecessary)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = ErrorMessages.EmailIncorrect)]
        [Required(ErrorMessage = ErrorMessages.EmailNecessary)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [RegularExpression("[\\d]", ErrorMessage = ErrorMessages.PhoneIncorrect)]
        [Required(ErrorMessage = ErrorMessages.PhoneNecessary)]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ErrorMessages.BodyNecessary)]
        [Display(Name = "Mensagem")]
        public string Body { get; set; }

        public string Subject { get; set; }
    }
}
