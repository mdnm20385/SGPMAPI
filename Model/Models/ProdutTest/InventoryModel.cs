using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.ProdutTest.Base;

namespace Model.Models.ProdutTest
{
    [Table("Inventory")]
    public class InventoryModel : BaseModel
    {

        public InventoryModel()
        {
            InventoryItems = new List<InventoryItemModel>();
        }
        [Required]
        [DisplayName("Order No")]
        public string InventoryCode { get; set; }

        [Required]
        public float TotalAmount { get; set; }
        public string Status { get; set; }
        public float GivenAmount { get; set; }
        public float ChangeAmount { get; set; }

        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        public ICollection<InventoryItemModel> InventoryItems { get; set; }
    }
}
