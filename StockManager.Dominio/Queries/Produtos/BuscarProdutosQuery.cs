using StockManager.Dominio.Dtos;
using StockManager.SharedKernel.Dispatcher.Interfaces;

namespace StockManager.Dominio.Queries.Produtos;

public record BuscarProdutosQuery() : IQuery<ICollection<ProdutoDto>>;