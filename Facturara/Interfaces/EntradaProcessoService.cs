using DAL.Conexao;

namespace SGPMAPI.Interfaces
{
    public class EntradaProcessoService : InterfEntradaProcesso
    {
        public readonly SGPMContext ApIcontext;
        public EntradaProcessoService(SGPMContext descricaoAPi)
        {
            ApIcontext = descricaoAPi;
        }
       
        public async Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave)
        {
            
            return true;
        }
        public async Task<bool> Eliminar(string id)
        {
            bool flag;
           
            return false;
        }
    }
}
