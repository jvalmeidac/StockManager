namespace StockManager.Dominio.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string CodigoSku { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    
    public Guid CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    
    public Guid MarcaId { get; set; }
    public Marca Marca { get; set; }
    
    public Guid TamanhoId { get; set; }
    public Tamanho Tamanho { get; set; }
}