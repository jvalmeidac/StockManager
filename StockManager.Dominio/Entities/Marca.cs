namespace StockManager.Dominio.Entities;

public class Marca
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    
    public ICollection<Produto> Produtos { get; set; } = [];
}