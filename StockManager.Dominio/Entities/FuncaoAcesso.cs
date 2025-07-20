namespace StockManager.Dominio.Entities;

public class FuncaoAcesso
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Usuario> Usuarios { get; set; } = [];
}