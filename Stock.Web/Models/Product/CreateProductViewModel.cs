using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Product
{
    public class CreateProductViewModel
    {

        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string Name { get; set; }

        [DisplayName("Alış Fiyatı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public double PurchasePrice { get; set; }

        [DisplayName("Satış Fiyatı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public double SellingPrice { get; set; }



        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int CategoryId { get; set; }

        [DisplayName("Ürün Görseli")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string ImageUrl { get; set; }
    }
}
