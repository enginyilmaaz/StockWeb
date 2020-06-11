using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Web.Models.Category
{
    public class EditCategoryViewModel
    {
        [Required]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        public int Id { get; set; }

    }
}
