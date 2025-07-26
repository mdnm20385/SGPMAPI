using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Experience
    {
        public Experience()
        {
        }

        [Key]
        public int ExperienceId { get; set; }

        [ForeignKey("Applicant")]//very important
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; private set; } //very important 

        public string CompanyName { get; set; }
        public string Designation { get; set; }
        //[Required]
        //[Range(1, 25, ErrorMessage = "Years must be between 1 to 25")]
        [DisplayName("Total Experience in Years")]
        public int YearsWorked { get; set; }

        public bool IsDeleted { get; set; }
    }
}
