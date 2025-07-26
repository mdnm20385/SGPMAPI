using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public  class Param
    {
        [Key]
        public string Paramstamp { get; set; }
        public string Codprod { get; set; }
        public string Smtpserver { get; set; } //Servidor SMTP
        public decimal Smtpport { get; set; } = 0; //porta do SMTP

        public int SmtpportInt { get; set; } //porta do SMTP
        public string Outgoingemail { get; set; }
        public string Outgoingpassword { get; set; }
    }
}
