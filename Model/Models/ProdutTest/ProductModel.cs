using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.ProdutTest.Base;

namespace Model.Models.ProdutTest
{
    [Table("Products")]
    public class ProductModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }


        [ForeignKey("CategoryModel")]
        [DisplayName("Category")]
        [Required]
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }


    }
}
