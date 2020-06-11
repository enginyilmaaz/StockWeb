using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Category
{
    public class CreateCategoryViewModel
    {
        [Required]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
    }
}
