using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string UserTypeDescription { get; set; }
    }
}
