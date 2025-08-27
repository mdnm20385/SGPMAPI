namespace Model.Models.SGPM;

public class UsuarioLoginTentativa
{
    public int Id { get; set; }
    public string Login { get; set; }
    public int Tentativas { get; set; }
    public DateTime? UltimaTentativa { get; set; }
    public bool Bloqueado { get; set; }
    public DateTime? BloqueadoAte { get; set; }
}