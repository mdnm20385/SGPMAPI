using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class SoftWare
    {
        [Key]
        public int Id { get; set; }

        [Required] [StringLength(150)]
        public string Name { get; set; } = "";
    }
}
