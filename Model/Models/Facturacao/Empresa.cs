using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Empresa
    {
        [Key]
        public string Empresastamp { get; set; }
        public decimal Codigo { get; set; }
        [MaxLength(20000)]
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Morada2 { get; set; }
        public string Sede { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public decimal Cp { get; set; }
        public string Actividade { get; set; }
        
        public decimal Nuit { get; set; }
        public string Sigla { get; set; }
        public string Moeda { get; set; }
        public string Infobanc { get; set; }
        public string Declarante { get; set; }
        public string Refdeclara { get; set; }
        public string CodigoINSS { get; set; }
        [MaxLength(200)]
        public string Grupo1 { get; set; }
        [MaxLength(200)]
        public string Grupo2 { get; set; }
        public string Webpage { get; set; }
        public string Empslogan { get; set; }
        public string Actdgi { get; set; }
        public string Reparticao { get; set; }
        public decimal Capitalsocial { get; set; }
        public string Matricula { get; set; }
        public bool LogoGrande { get; set; }
        public bool MostraNome { get; set; }

        public byte[] Logo { get; set; }

        #region Grupo de parceiros......

        public byte[] Logo1 { get; set; }
        public byte[] Logo2 { get; set; }
        public byte[] Logo3 { get; set; }
        public byte[] Logo4 { get; set; }
        public byte[] Logo5 { get; set; }
        public byte[] Logo6 { get; set; }
        public byte[] Logo7 { get; set; }
        public byte[] Logo8 { get; set; }
        public byte[] Logo9 { get; set; }
        public byte[] Logo10 { get; set; }
        public byte[] Logo11 { get; set; }
        public byte[] Logo12 { get; set; }
        public byte[] Logo13 { get; set; }
        public byte[] Logo14 { get; set; }
        public byte[] Logo15 { get; set; }       
        
        #region Grupo de Clintes......

        public byte[] Cl1 { get; set; }
        public byte[] Cl2 { get; set; }
        public byte[] Cl3 { get; set; }
        public byte[] Cl4 { get; set; }
        public byte[] Cl5 { get; set; }
        public byte[] Cl6 { get; set; }
        public byte[] Cl7 { get; set; }
        public byte[] Cl8 { get; set; }
        public byte[] Cl9 { get; set; }
        public byte[] Cl10 { get; set; }
        public byte[] Cl11 { get; set; }
        public byte[] Cl12 { get; set; }
        public byte[] Cl13 { get; set; }
        public byte[] Cl14 { get; set; }
        public byte[] Cl15 { get; set; }
        public bool Emptransporte { get; set; }
        #endregion

        #endregion
        public byte[] ImagemFundo { get; set; }
        public virtual ICollection<EmpresaMod> EmpresaMod { get; set; }
        public virtual ICollection<Empresadep> Empresadep { get; set; }

    }
}
