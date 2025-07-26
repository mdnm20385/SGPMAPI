using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Vt
    {
        [Key]
        public string Vtstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public string Chassis { get; set; }
        public decimal anofab { get; set; }
        public decimal tara { get; set; }
        public decimal pesobruto { get; set; }
        public string Combustivel { get; set; }
        public string Pneus { get; set; }
        public decimal codentida { get; set; }
        public string Nomentida { get; set; }
        public DateTime valInspec { get; set; }
        public DateTime daquisic { get; set; }
        public string Obs { get; set; }
        public decimal Status { get; set; }
        public string Descstatus { get; set; }
        public string Seguradora { get; set; }
        public string Apolice { get; set; }
        public DateTime valapolice { get; set; }
        public decimal codtrl { get; set; }
        public string trailer { get; set; }
        public string Numlic { get; set; }
        public DateTime DatLic { get; set; }
        public DateTime validLic { get; set; }
        public string NumInspec { get; set; }
        public DateTime DatInspec { get; set; }
        public DateTime DatSegura { get; set; }
        public decimal Anomanifest { get; set; }
        public DateTime Datmanifest { get; set; }
        public DateTime Validmanifest { get; set; }
        public decimal capacit { get; set; }
        public bool Externa { get; set; }
        public decimal numdoc { get; set; }
        public string medveloc { get; set; }
        public decimal qttporkm { get; set; }
        public decimal capaclitros { get; set; }
        public string @ref { get; set; }
        public string stdesc { get; set; }
        public decimal codmarca { get; set; }
        public decimal tipo { get; set; }
        public string designacao { get; set; }
        public decimal valorbase { get; set; }
        public virtual ICollection<Vtcfg> Vtcfg { get; set; }       
        public virtual ICollection<Vtcorreias> Vtcorreias { get; set; }
        public virtual ICollection<Vtfiltros> Vtfiltros { get; set; }
        public virtual ICollection<Vtman> Vtman { get; set; }
        public virtual ICollection<Vtpneus> Vtpneus { get; set; } 
        public virtual ICollection<Vtoleos> Vtoleos { get; set; }
        public virtual ICollection<Vtdoc> Vtdoc { get; set; }
    }
}
