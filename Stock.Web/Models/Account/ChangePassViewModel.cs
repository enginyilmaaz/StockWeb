using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Account
{
    public class ChangePassViewModel
    {
        [DisplayName("Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string Password { get; set; }

        [DisplayName("Parola Tekrarı")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string RePassword { get; set; }
    }
}
