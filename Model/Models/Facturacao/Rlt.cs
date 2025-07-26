using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Rlt
    {
        [Key]
        public string Rltstamp { get; set; }
        public decimal Numero { get; set; }
        public string Descricao { get; set; }
        public decimal Tipofilter { get; set; }
        public string ComboQry1 { get; set; }//Representa o Querry de Centro de custo 
        public string TmGrid { get; set; }
        public string ClnBold { get; set; }
        public string ClmMask { get; set; }
        public string ClnHeader { get; set; }
        public string ClnAlign { get; set; }
        public string ClnCor { get; set; }//Representa o Querry da Dataset2
        public string ClnTab { get; set; }
        public bool ClnReport { get; set; }

        //  [Column("CrQuery", TypeName = "nvarchar(max)")]
        [MaxLength(40000)]
        public string CrQuery { get; set; }
        public bool UsaMoeda { get; set; }
        public string Tabela { get; set; }
        public string ComboQry2 { get; set; }//Representa o Querry do ano 
        public string ComboQry3 { get; set; }//Representa os nomes das colunas para o mapa
        public string ComboQry4 { get; set; }//Representa os tamanhos das colunas para o mapa
        public string ComboQry5 { get; set; }//Representa a Origem para relatorio de tipo painel 
        public string ComboQry6 { get; set; }//Representa o filtro de intervalo entre anos 
        public string ComboQry7 { get; set; }//Representa o Querry da moeda 
        public string ComboQry8 { get; set; } 
        public string ComboQry9 { get; set; }
        public decimal TipoRlt { get; set; }
        public bool RltGrafico { get; set; }
        public bool Pos { get; set; }//Visível em POS 
        public string Filtros { get; set; }
        public string DescFiltroEntreDatas { get; set; }
        public string FiltroEntreDatas { get; set; }  

        public string DescFiltroEntreAnos { get; set; }
        public string FiltroEntreAnos { get; set; }

        public string DescFiltroAno { get; set; } 
        public string FiltroAno { get; set; }
        public string DescFiltroData { get; set; }
        public string FiltroData { get; set; }

        public string Codmodulo { get; set; }//Sigla do Modulo associado 
        public string Modulo { get; set; }//Descricao do modulo associado 
        public decimal Mostracfe { get; set; }//Mostra o Campos:  1-cliente, 2-fornecedor, 3-entidade
        public bool Mostrapj { get; set; }//Mostra o Campo Projecto
        public bool Mostrafp { get; set; }//Mostra Formas de pagamento 
        public bool MostraTesoura { get; set; }//Mostra Tesouraria  
        public bool NaoMostraM { get; set; }//Nao Mostra Moeda NaoMostraMoeda 
        public bool Mostraprc { get; set; }//Mostra o processanento de salario
        public bool Geramapa { get; set; }//Gera um mapa e não uma impressao expecifica 
                                          // [Column("ReportXml", TypeName = "nvarchar(max)")]
        public string ReportXml { get; set; }

        //[MaxLength(2500)]
        //public string Param1 { get; set; }
        public bool Mostrausr { get; set; }//Mostra utilizador no relatorio
        public bool MostraCorredor { get; set; }//Mostra Corredor no relatorio(Usado no módulo de TPM)
        public bool Mostratdocf { get; set; }//Mostra tipo de documentos no relatorio(Usado no módulo de BWT)

        #region Grupo Academia........
        public bool Mostracurso { get; set; }
        public bool Mostraturma { get; set; }

        public bool Mostraplanocur { get; set; }//Plano Curricular 
        public bool Mostradisciplina { get; set; }
        public bool Mostraanosem { get; set; }//Ano semestre 
        public bool Mostraprof { get; set; }//Ano Professor 
        public bool Mostraetapasem { get; set; }//Ano Etapa ou semestre  
        #endregion


        public virtual ICollection<Docmodulo> Docmodulo { get; set; }
        public virtual ICollection<Rltusr> Rltusr { get; set; }
        public virtual ICollection<RltCc> RltCc { get; set; }
        public virtual ICollection<Rltmapa> Rltmapa { get; set; }
        public string XmlString { get; set; }
        public bool MostraEscala { get; set; }
        public bool Mostraturno { get; set; }//MostraEscala
        public bool Mostradi { get; set; }//Mostra documentos internos
    }
}
