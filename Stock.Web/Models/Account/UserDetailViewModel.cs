using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Account
{
    public class UserDetailViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string LastName { get; set; }

        [DisplayName("Eposta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string Email { get; set; }



    }
}
