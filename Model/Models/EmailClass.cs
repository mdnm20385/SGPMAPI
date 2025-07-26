using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class EmailClass
    {
        [Key]
        public string EmailClassStamp { get; set; } 
        public string? Email { get; set; }
        public string? StampDire { get; set; }
        public string? StampDireDep { get; set; }
        public bool RecebeEmailTare { get; set; } = false;
        public virtual Dir Dir { get; set; }
        public virtual Dirdep Dirdep { get; set; }
    }
}
