namespace Model.Models.Facturacao
{
public class LsLic
    {
        public string Empresa { get; set; }
        public string Sigla { get; set; }
        public string Morada { get; set; }
        public bool Trial { get; set; }
        public decimal LimitTrial { get; set; }
        public bool Fullic { get; set; }
        public bool Ges { get; set; }
        public bool CT { get; set; }
        public DateTime CtData { get; set; }
        public DateTime Ctval { get; set; }
        public bool POSR { get; set; }
        public bool GF { get; set; }
        public bool POSM { get; set; }
        public bool Flex { get; set; }
        public bool CRM { get; set; }
        public bool RHS { get; set; }
        public DateTime Rhval { get; set; }
        public DateTime Rhdata { get; set; }
        public bool AC { get; set; }
        public bool HT { get; set; }
        public bool FT { get; set; }
        public bool PJ { get; set; }
        public bool PRC { get; set; }
        public bool IMB { get; set; }
        public decimal NUIT { get; set; }
        public decimal UGes { get; set; } = 0;
        public decimal UCt { get; set; } = 0;
        public decimal URh { get; set; } = 0;

        //Hospital
        public bool HPS { get; set; }
        public decimal UHP { get; set; }
        public DateTime HPdata { get; set; }
        public DateTime HPval { get; set; }
        //Hospital

        public DateTime Fulllicval { get; set; }
        public DateTime Fulllicdata { get; set; }
        public DateTime DemoVal { get; set; }//Validade da Versao Demo
        public DateTime Demodata { get; set; }//Data da versao demo 
        public DateTime Tecval { get; set; }//Validade da Versao Tecnica 
        public DateTime Tecdata { get; set; } //Data da Versao Tecnica 
        public string Din { get; set; }
        public bool Tec { get; set; }
        public bool Demo { get; set; }
        public bool Anual { get; set; }
        public decimal LimitDemo { get; set; }
        public decimal LimitTec { get; set; }
        public bool Memp { get; set; }
        public bool Encripted { get; set; }
    }
}
