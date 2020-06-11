using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Account
{
    public class AccountLoginViewModel
    {

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
