using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

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

        [DisplayName("Ürün Mikatarı")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int Quantity { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int CategoryId { get; set; }

        [DisplayName("ürün Görseli")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public int ImageUrl { get; set; }
    }
}
