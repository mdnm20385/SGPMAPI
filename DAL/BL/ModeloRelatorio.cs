using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models.SJM;

namespace DAL.BL
{

    #region SISTEMA DE GESTÃO DE JUNTAS MÉDICAS
    public class ModeloRelatorios
    {
        //--DClinicos
        public string PaStamp { get; set; }
        public string DadosAnamense { get; set; }
        public string ExamesObjectivos { get; set; }
        public string ExamesClinicos { get; set; }
        public string DiaDef { get; set; }
        public string Conclusao { get; set; }

        //--EntradaProcesso
        public string ProcessoStamp { get; set; }
        public string EntradaStamp { get; set; }
        public string Remetente { get; set; }
        public string ProvProveniencia { get; set; }
        public string DataEntrada { get; set; }

        //--Categoria
        public string Descricao { get; set; }
        public string MilStamp { get; set; }
        public string CatStamp { get; set; }
        public string CodCat { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodRamo { get; set; }
        public string Ramo { get; set; }
        public string ClasseMilitar { get; set; }

        //--Pa
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string NumBI { get; set; }
        public string Naturalidade { get; set; }
        public string ResProv { get; set; }
        public string ResDist { get; set; }
        public string ResPosto { get; set; }
        public string ResLocal { get; set; }
        public string ResBairro { get; set; }
        public string ResQuarteirao { get; set; }
        public string ResAvenida { get; set; }
        public string NumCasa { get; set; }
        public string ConPrinc { get; set; }
        public string ConAlter { get; set; }
        public string Orgao { get; set; }
        public string Unidade { get; set; }
        public string Subunidade { get; set; }
        public string Patente { get; set; }
        public byte[] Junta { get; set; }
        public string Tipodoc { get; set; }

        //--Processo
        public int Numero { get; set; }
        public string TipoDoc { get; set; }
        public string Assunto { get; set; }
        public byte[] Documento { get; set; }


        //--SaidaProcesso
        public string SaidaStamp { get; set; }
        public string Destinatario { get; set; }
        public string Recebeu { get; set; }
        public string DataSaida { get; set; }

        //--Pais
        public string PaisStamp { get; set; }
        public string PaisDescricao { get; set; }
        public string CodPais { get; set; }
        public bool PorDefeito { get; set; }
        public string Nacional { get; set; }
        public string Abreviatura { get; set; }

        //--Provincias
        public string CodProv { get; set; }
        public string ProvinciaStamp { get; set; }
        public string ProvDescricao { get; set; }

        //--Distrito
        public string CodDistrito { get; set; }
        public string DistritoStamp { get; set; }
        public string DistDescricao { get; set; }

        //--PostAdministrativo
        public string CodPostoAdm { get; set; }
        public string PostAdmStamp { get; set; }
        public string PAdmDescricao { get; set; }
        public string CodDistStamp { get; set; }

        //--Localidade
        public string CodLocalidade { get; set; }
        public string LocalidadeStamp { get; set; }
        public string LocalidadeDescricao { get; set; }
        public decimal CodPostAdmin { get; set; }

        //--Fotos
        public byte[] Foto { get; set; }

        //--Patente
        public int TotalSegCab { get; set; }
        public string PatenteDescricao { get; set; }
        public string PatStamp { get; set; }
        public string Categoria { get; set; }
        public string CodPat { get; set; }
        public int CodPatente { get; set; }
        public string CodCategoria { get; set; }
        public string ClasseMil { get; set; }

        //--Orgao
        public string Regime { get; set; }
        public string Orgaos { get; set; }
        public string Subunidade1 { get; set; }
        public string Subunidade2 { get; set; }
        public string OrgaoStamp { get; set; }
        public int CodOrgao { get; set; }
        public int Organica { get; set; }
        public int TotalOf { get; set; }
        public int TotalOfGen { get; set; }
        public int TotalGenEx { get; set; }
        public int TotalTteGen { get; set; }
        public int TotalMajGen { get; set; }
        public int TotalMajGenr { get; set; }
        public int TotalBrigadeiro { get; set; }
        public int TotalOfSup { get; set; }
        public int TotalCor { get; set; }
        public int TotalTteCor { get; set; }
        public int TotalMaj { get; set; }
        public int TotalOfSub { get; set; }
        public int TotalCap { get; set; }
        public int TotalTte { get; set; }
        public int TotalTteMil { get; set; }
        public int TotalAlf { get; set; }
        public int TotalAlfMil { get; set; }
        public int TotalSarg { get; set; }
        public int TotalInt { get; set; }
        public int TotalSub { get; set; }
        public int TotalPriSar { get; set; }
        public int TotalSegSar { get; set; }
        public int TotalTerSar { get; set; }
        public int TotalFur { get; set; }
        public int FormacaMedia { get; set; }
        public int Posgradua { get; set; }
        public int CurMedio { get; set; }
        public int DecprimClase { get; set; }
        public int CursoBasico { get; set; }
        public int FormBasica { get; set; }
        public int NonaClase { get; set; }
        public int OitavaClase { get; set; }
        public int Sextalase { get; set; }
        public int Mestrado { get; set; }
        public int Doutoramento { get; set; }
        public int Licenciatura { get; set; }
        public int Medio { get; set; }
        public int DecseguClase { get; set; }
        public int DecClase { get; set; }
        public int SetClase { get; set; }
        public int QuintaClase { get; set; }
        public int Bacharelato { get; set; }
        public int EnsinoPrimario { get; set; }
        public int QpOfi { get; set; }
        public int RvOfi { get; set; }
        public int SenOfi { get; set; }
        public int TotalGeralOfi { get; set; }
        public int TotalGeralSargen { get; set; }
        public int TotalGeralPrac { get; set; }
        public int Existenciaoficiais { get; set; }
        public int Existenciasargentos { get; set; }
        public int ExistenciaPracas { get; set; }
        public int Emfaltaoficiais { get; set; }
        public int EmExcessooficiais { get; set; }
        public int EmExcessosargentos { get; set; }
        public int EmExcessoPracas { get; set; }
        public int Emfaltasargentos { get; set; }
        public int EmfaltaPracas { get; set; }
        public int ServEfDecorrConvcMobOfi { get; set; }
        public int QpSargen { get; set; }
        public int RvSargen { get; set; }
        public int SenSargen { get; set; }
        public int ServEfDecorrConvcMobSargen { get; set; }
        public int QpPrac { get; set; }
        public int RvPrac { get; set; }
        public int TotalQP { get; set; }
        public int TotalDisp { get; set; }
        public int TotalLic { get; set; }
        public int TotalRT { get; set; }
        public int TotalGeral { get; set; }
        public int SenPrac { get; set; }
        public int ServEfDecorrConvcMobPrac { get; set; }
        public int TotalPriCab { get; set; }
        public int TotalSold { get; set; }
        public string FaixaEtaria { get; set; }
        public int TotalPra { get; set; }

        //--Ramo
        public int TotalSegCabo { get; set; }
        public string RamoStamp { get; set; }
        public int TotalOficiais { get; set; }
        public int TotalOfGenerais { get; set; }
        public int TotalGenExercito { get; set; }
        public int TotalTenetteGenerais { get; set; }
        public int TotalOfSuperior { get; set; }
        public int TotalTteCoronel { get; set; }
        public int TotalMajor { get; set; }
        public int TotalOfSubalternos { get; set; }
        public int TotalCapitao { get; set; }
        public int TotalSargentos { get; set; }
        public int totalInt { get; set; }
        public int TotalSubIntedente { get; set; }
        public int TotalPriSargento { get; set; }
        public int TotalSegSargento { get; set; }
        public int TotalTerSargento { get; set; }
        public int TotalFurriel { get; set; }
        public int TotalPraca { get; set; }
        public int TotalPriCabo { get; set; }
        public int TotalSoldado { get; set; }
        public string Regiao { get; set; }
        public string provincia { get; set; }
        public string Distrito { get; set; }
        public string PostoAdm { get; set; }
        public int TotalCoronel { get; set; }
        public int TotalIntedente { get; set; }
        public string Localidade { get; set; }
        public string Zona { get; set; }
        public string Provincia { get; set; }
        public int CodProvincia { get; set; }

        //--Unidade
        public string UnidadeStamp { get; set; }
        public bool Centro { get; set; }
        public bool EstabEnsino { get; set; }
        public int CodUnidade { get; set; }
        public bool Cibm { get; set; }
        public bool UnidSubordCentral { get; set; }
        public bool HospMilitar { get; set; }
        public bool PCO { get; set; }

        //--Subunidade
        public string SubunidadeStamp { get; set; }
        public int CodSubUnidade { get; set; }




        
        public string Homologado { get; set; }
    }
    
    
    public class Orgao1
    {
        public string Sexo { get; set; }

        public string Regime { get; set; }
        public string Orgaos { get; set; }
        public string Unidade { get; set; }
        public string Subunidade { get; set; }
        public string Subunidade1 { get; set; }
        public string Subunidade2 { get; set; }
        public string OrgaoStamp { get; set; }

        public int CodOrgao { get; set; }

        public int Organica { get; set; }

        public int TotalOf { get; set; }

        public int TotalOfGen { get; set; }

        public int TotalGenEx { get; set; }

        public int TotalTteGen { get; set; }

        public int TotalMajGen { get; set; }
        public int TotalMajGenr { get; set; }
        public int TotalBrigadeiro
        {
            get;
            set;
        }

        public int TotalOfSup { get; set; }

        public int TotalCor { get; set; }

        public int TotalTteCor { get; set; }

        public int TotalMaj { get; set; }

        public int TotalOfSub { get; set; }

        public int TotalCap { get; set; }

        public int TotalTte { get; set; }

        public int TotalTteMil { get; set; }

        public int TotalAlf { get; set; }

        public int TotalAlfMil { get; set; }

        public int TotalSarg { get; set; }

        public int TotalInt { get; set; }

        public int TotalSub { get; set; }

        public int TotalPriSar { get; set; }

        public int TotalSegSar { get; set; }

        public int TotalTerSar { get; set; }

        public int TotalFur { get; set; }

        public int FormacaMedia { get; set; }
        public int Posgradua { get; set; }
        public int CurMedio { get; set; }
        public int DecprimClase { get; set; }
        public int CursoBasico { get; set; }
        public int FormBasica { get; set; }
        public int NonaClase { get; set; }
        public int OitavaClase { get; set; }
        public int Sextalase { get; set; }
        public int Mestrado { get; set; }
        public int Doutoramento { get; set; }
        public int Licenciatura { get; set; }
        public int Medio { get; set; }
        public int DecseguClase { get; set; }
        public int DecClase { get; set; }
        public int SetClase { get; set; }
        public int QuintaClase { get; set; }
        public int Bacharelato { get; set; }
        public int EnsinoPrimario { get; set; }
        public int QpOfi { get; set; }
        public int RvOfi { get; set; }
        public int SenOfi { get; set; }
        public int TotalGeralOfi { get; set; }
        public int TotalGeralSargen { get; set; }
        public int TotalGeralPrac { get; set; }
        //public int TotalGeral { get; set; }

        public int Existenciaoficiais { get; set; }
        public int Existenciasargentos { get; set; }
        public int ExistenciaPracas { get; set; }
        public int Emfaltaoficiais { get; set; }
        public int EmExcessooficiais { get; set; }
        public int EmExcessosargentos { get; set; }
        public int EmExcessoPracas { get; set; }
        public int Emfaltasargentos { get; set; }
        public int EmfaltaPracas { get; set; }
        public int ServEfDecorrConvcMobOfi { get; set; }
        public int QpSargen { get; set; }
        public int RvSargen { get; set; }
        public int SenSargen { get; set; }
        public int ServEfDecorrConvcMobSargen { get; set; }
        public int QpPrac { get; set; }
        public int RvPrac { get; set; }



        public int TotalQP { get; set; }
        public int TotalDisp { get; set; }
        public int TotalLic { get; set; }
        public int TotalRT { get; set; }
        public int TotalGeral { get; set; }









        public int SenPrac { get; set; }
        public int ServEfDecorrConvcMobPrac { get; set; }

        public int TotalPriCab { get; set; }

        public int TotalSegCab { get; set; }

        public int TotalSold { get; set; }

        public string Descricao { get; set; }

        public string MilStamp { get; set; }

        public string AlterouDataHora { get; set; }

        public string Alterou { get; set; }

        public string Inseriu { get; set; }

        public string FaixaEtaria { get; set; }
        public string InseriuDataHora { get; set; }
        public int TotalPra { get; set; }
        public string ResProv { get; set; }
    }
    public class Ramo1
    {
        public int TotalSegCabo { get; set; }

        public string Descricao { get; set; }

        public string MilStamp { get; set; }

        public string AlterouDataHora { get; set; }

        public string Alterou { get; set; }

        public string Inseriu { get; set; }

        public string InseriuDataHora { get; set; }

        public string RamoStamp { get; set; }

        public int TotalTteMil { get; set; }

        public int CodRamo { get; set; }

        public int Organica { get; set; }

        public int TotalOficiais { get; set; }

        public int TotalOfGenerais { get; set; }

        public int TotalGenExercito { get; set; }

        public int TotalTenetteGenerais { get; set; }

        public int TotalMajGen { get; set; }

        private int _totalBrigadeiro;
        public int TotalBrigadeiro
        {
            get
            {
                return this._totalBrigadeiro;
            }
            set
            {

                this.TotalMajGen = value;
            }
        }

        public int TotalOfSuperior { get; set; }

        public int TotalCor { get; set; }

        public int TotalTteCoronel { get; set; }

        public int TotalMajor { get; set; }

        public int TotalOfSubalternos { get; set; }

        public int TotalCapitao { get; set; }

        public int TotalTte { get; set; }

        public int TotalAlf { get; set; }

        public int TotalAlfMil { get; set; }

        public int TotalSargentos { get; set; }

        public int totalInt { get; set; }

        public int TotalSubIntedente { get; set; }

        public int TotalPriSargento { get; set; }

        public int TotalSegSargento { get; set; }

        public int TotalTerSargento { get; set; }

        public int TotalFurriel { get; set; }

        public int TotalPraca { get; set; }

        public int TotalPriCabo { get; set; }

        public int TotalSoldado { get; set; }

        public string Regiao { get; set; }

        public string provincia { get; set; }

        public string Distrito { get; set; }

        public string PostoAdm { get; set; }

        public string Orgao { get; set; }
        public int TotalCoronel { get; set; }
        public int TotalIntedente { get; set; }
        public string Localidade { get; set; }
        public string Zona { get; set; }
        public string Provincia { get; set; }
        public int CodProvincia { get; set; }
        public int CodDistrito { get; set; }
        public int CodPostoAdm { get; set; }
        public int CodLocalidade { get; set; }
    }
    public class Busca1
    {
        public string BuscaStamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Numtabela { get; set; }


        public string Inseriu { get; set; }

        public string InseriuDataHora { get; set; }

        public string Alterou { get; set; }

        public string AlterouDataHora { get; set; }
    }
    #endregion
}
