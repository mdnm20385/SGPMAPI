using System.ComponentModel.DataAnnotations;
using Model.Models.ProdutTest.Base;

namespace Model.Models.ProdutTest
{
    public class CustomerModel :  BaseModel 
    {
        [Required]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
