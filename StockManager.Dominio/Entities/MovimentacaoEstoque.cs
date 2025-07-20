using StockManager.Dominio.Enums;

namespace StockManager.Dominio.Entities;

public class MovimentacaoEstoque
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; }

    public DateTime Data { get; set; }
    public TipoMovimentacao TipoMovimentacao { get; set; }
    public int Quantidade { get; set; }
}
