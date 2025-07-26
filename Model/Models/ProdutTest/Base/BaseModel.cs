using System.ComponentModel.DataAnnotations;

namespace Model.Models.ProdutTest.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
