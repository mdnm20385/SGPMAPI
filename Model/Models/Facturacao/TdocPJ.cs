using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class TdocPj
    {
        [Key]
        public string Tdocpjstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Defa { get; set; }
        public bool Compra { get; set; } // Permite mostrar buttao compras 
        public bool Venda { get; set; } // Permite mostrar buttao vendas 
        public bool Di { get; set; }// Permite mostrar buttao documentos internos 
    }

}
