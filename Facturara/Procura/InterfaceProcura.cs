using Model.Models.Facturacao;
using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Procura
{
    public interface InterfaceProcura
    {
        Task<PaginationResponseBl<List<SharedClasses.Procura>>> Procurar(string tabela, string campo, string campo1,
            string chave, string valorprocurado,
            int currentNumber, int pagesize, string condicaodata = "");
        Task<ServiceResponse<Mdnviewgrelha>> ComboboxesMdn(string campos, string tabela, string condicoes);
        Task<PaginationResponseBl<object>> MetodoGenerico(string tabela, string campo, string campo1,
            string chave, string valorprocurado,
            int currentNumber, int pagesize, Usuario u, string condicaodata = "", string orderby = "",string entradastamp="");


        Task<ServiceResponse<Selectview>> Comboboxes(string tabela, string campo1, string campo2, string condicao = "", string Campochave="");

        Task<ServiceResponse<Selectview>> Comboboxes17(string tabela, string campo1, string campo2,
            string condicao , string Campochave ); 
        Task<IEnumerable<Fact>> GetFactsAsync();

        Task<bool> DeleteFactAsync(string factstamp); 
        Task<Fact> GetFactWithChildrenAsync(string factstamp);
    }
}
