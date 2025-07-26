using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class SoftWareExperience
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual  Applicant Applicant { get; set; }



        [ForeignKey("SoftWares")]
        public int SoftWareId { get; set; }
        public virtual SoftWare SoftWares { get; set; }
        
        [Range(1, 10, ErrorMessage = "Select your rating out of 10, 10 is the best. 1 is poor")]
        public int Rating { get; set; }

        [Required]
        [StringLength(50)] 
        public string Notes { get; set; } = "";

        [NotMapped]
        public bool IsHidden { get; set; } = false
            ;

        
        public bool IsDeleted { get; set; } 
    }
}
