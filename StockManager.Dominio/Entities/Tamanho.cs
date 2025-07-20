namespace StockManager.Dominio.Entities;

public class Tamanho
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }

    public ICollection<Produto> Produtos { get; set; } = [];
}