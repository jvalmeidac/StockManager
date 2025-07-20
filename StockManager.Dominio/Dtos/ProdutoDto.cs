namespace StockManager.Dominio.Dtos;

public record ProdutoDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cor { get; set; }
    public string? CodigoSku { get; set; }
    public decimal? Preco { get; set; }
    public int? QuantidadeEstoque { get; set; }
    public string? CategoriaNome { get; set; }
    public string? MarcaNome { get; set; }
    public string? TamanhoCodigo { get; set; }
}