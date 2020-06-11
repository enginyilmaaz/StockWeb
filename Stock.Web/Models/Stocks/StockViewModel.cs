using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Stocks
{
    public class StockViewModel
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int ProductId { get; set; }

        [DisplayName("Alış Fiyatı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public double PiecePrice { get; set; }

        [DisplayName("Miktar")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int Quantity { get; set; }

        [DisplayName("Toplam Fiyat")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public double TotalPrice { get; set; }




    }
}
