using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.ProdutTest.Base;

namespace Model.Models.ProdutTest
{
    [Table("Category")]
    public class CategoryModel : BaseModel
    {
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

        public CategoryModel()
        {
            Products = new List<ProductModel>();
        }

        
    }
}
