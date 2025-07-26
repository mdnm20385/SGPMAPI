using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pe
    {
        [Key]
        public string Pestamp { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        [DecimalPrecision(16,0,true)]
        public decimal Nuit { get; set; }
        public string Bi { get; set; }  
        public decimal Codsit { get; set; }
        public string Situacao { get; set; }
        public DateTime Datanasc { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataFimContrato { get; set; }
        public DateTime DataDemissao { get; set; }
        public string Sexo { get; set; }
        public string Ecivil { get; set; }
        public DateTime Dcasa { get; set; }
        public byte[] Foto { get; set; }
        /// <summary>
        /// Dados de Nascimento
        /// </summary>
        public string Nacional { get; set; }
        public string Pais { get; set; }
        public string ProvNasc { get; set; }
        public string DistNasc { get; set; }
        public string PadNasc { get; set; }
        //------------Fim Nascimento-----------

        /// <summary>
        /// Dados da Morada
        /// </summary>
        /// 
        public string Bairro { get; set; }
        public string ProvMorada { get; set; }
        public string DistMorada { get; set; }
        public string PadMorada { get; set; }
        public string Locali { get; set; }
        //------------Fim Morada-------------
        /// <summary>
        /// Filiação
        /// </summary>
        public string Pai { get; set; }
        public string Mae { get; set; }
        /// <summary>
        /// Nivel Academico
        /// </summary>
        public decimal CodNivel { get; set; }
        public string Nivel { get; set; }
        public decimal CodCateg { get; set; }
        public string Categ { get; set; }
        public decimal Codprof { get; set; }
        public string Prof { get; set; }
        public decimal Codep { get; set; }
        public string Depart { get; set; }
        public decimal Codrep { get; set; }
        public string Repart { get; set; }
        public string Nrinss { get; set; } //Numero de Seguranca Social
        public string BalcaoInss { get; set; } //Balcao de Seguranca Social
        public DateTime DataInss { get; set; } //Data de admissao a Seguranca Social
        public bool RelPonto { get; set; }
        [DecimalPrecision(16,2,true)]
        public decimal ValBasico { get; set; } //Vencimento Base
        [DecimalPrecision(16,2,true)]
        public decimal Horasdia { get; set; }//Numero de horas de trabalho por dia 
        public decimal Nrdepend { get; set; }//Numero de dependentes para IRPS
        [MaxLength(500)]
        public string Obs { get; set; }
        public string Codtipo { get; set; }//Tipo de funcionario (Mecanico,Motorista,etc)
        public string Tipo { get; set; }//Tipo de funcionario (Mecanico,Motorista,etc)
        //Novos campos 
        public string Codccu { get; set; }
        public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        [DecimalPrecision(16,2,true)]
        public decimal Diasmes { get; set; } //numero de Dias de trabalho no mes
         [DecimalPrecision(16,2,true)]
        public decimal HorasSemana { get; set; }//Horas de Trabalho por semana SalHora
         [DecimalPrecision(16,2,true)]
        public decimal SalHora { get; set; }//Valor do salario por hora 
        public string TabIrps { get; set; }//Tabela do IRPS a usar 
        public string CodRepFinancas { get; set; } //Codigo de Reparticao de financas 
        public string DescRepFinancas { get; set; } //Codigo de Reparticao de financas 
        public string Apolice { get; set; }//Numero de apolice 
        public DateTime DataApoliceIn { get; set; }//Numero de apolice 
        public DateTime DataApoliceTer { get; set; }//Numero de apolice 
        public string Seguradora { get; set; }
        public string Moeda { get; set; }//Moeda de recebimento 
        public bool NaoInss { get; set; }//Nao processa O INSS
        public bool NaoIRPS { get; set; }//Nao processa O IRPS
        public string Tirpsstamp { get; set; }//Tabela de IRPS
        public bool Ntabelado { get; set; }//Indica que o valor nao tabelado 
        public string Pontonome { get; set; }//Nome do relogio do ponto 
        public string Formapag { get; set; }
        public string Campomultiuso { get; set; }//1
        public decimal Codformp { get; set; }
        public DateTime Dataadm { get; set; }//DAta de admissao 
        public DateTime ReDataadm { get; set; }//DAta de readmissao 
        [DecimalPrecision(16, 2, true)]
        public decimal Basedia { get; set; }

        [DecimalPrecision(16, 2, true)]
        public decimal TotalPacientesDia { get; set; }

        public bool Pedagogico { get; set; }//Director pedagógico
        public bool Coordenador { get; set; }//Coordenador/Conselheiro/supervisor/Director do curso
        public virtual ICollection<Pefalta> Pefalta { get; set; }
        public virtual ICollection<Pehextra> Pehextra { get; set; }
        public virtual ICollection<Pedoc> Pedoc { get; set; }
        public virtual ICollection<Peling> Peling { get; set; }
        public virtual ICollection<Pecont> Pecont { get; set; }
        public virtual ICollection<Pefam> Pefam { get; set; }
        public virtual ICollection<Pesind> Pesind { get; set; }
        public virtual ICollection<Pecontra> Pecontra { get; set; }//Contratos 
        public virtual ICollection<Pebanc> Pebanc { get; set; }
        public virtual ICollection<Pefer> Pefer { get; set; }//Ferias 
        public virtual ICollection<Pesub> Pesub { get; set; }
        public virtual ICollection<Pedesc> Pedesc { get; set; }
        public virtual ICollection<PeForm> PeForm { get; set; }
        public virtual ICollection<Peaus> Peaus { get; set; }//Ausencias prolongadas...
        public virtual ICollection<Peacidente> Peacidente { get; set; }//Acidentes
        public virtual ICollection<Pect> Pect { get; set; }//Contas de contabilidade 
        public virtual ICollection<Pefunc> Pefunc { get; set; }//Contas de contabilidade 
        public virtual ICollection<Pedisc> Pedisc { get; set; }//Disciplinas que leciona 
        public virtual ICollection<PeSalbase> PeSalbase { get; set; }//salamento de sal vase dos professores 
        public virtual ICollection<DistribuicaoTurno> DistribuicaoTurno { get; set; }
        

    }
}
