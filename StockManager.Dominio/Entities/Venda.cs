namespace StockManager.Dominio.Entities;

public class Venda
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Total { get; set; }
    public string FormaPagamento { get; set; }

    public ICollection<ItemVenda> Itens { get; set; } = [];
}
