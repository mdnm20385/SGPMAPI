using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Ent
    {
        [Key]
        public string Entstamp { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Fax { get; set; }
        public decimal Cp { get; set; }
        public string Email { get; set; }
        public decimal Nuit { get; set; }
        public string Zona { get; set; }
        public string Tipo { get; set; }
        public decimal CodVend { get; set; }
        public string Vendedor { get; set; }
        public string Nimpexp { get; set; }
        public decimal Perdesc { get; set; }
        public string Moeda { get; set; }
        public bool Status { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public decimal Tabela { get; set; }
        public DateTime Datacl { get; set; }
        public string Obs { get; set; }
        public string Pais { get; set; }
        public string Qmc { get; set; }
        public DateTime Qmcdathora { get; set; }
        public string Qma { get; set; }
        public DateTime Qmadathora { get; set; }
        public string Localidade { get; set; }
        public string Codpais { get; set; }
        public decimal Codarm { get; set; }
        public string Descarm { get; set; }
        public bool Clivainc { get; set; }
        public bool Cobrador { get; set; }
        public decimal Codcondpag { get; set; }
        public string Descondpag { get; set; }
    }
}
