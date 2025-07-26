namespace SGPMAPI.Interfaces
{
    public interface InterfEntradaProcesso
    {
        Task<bool> Eliminar(string id);
        Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave);
    }
}
