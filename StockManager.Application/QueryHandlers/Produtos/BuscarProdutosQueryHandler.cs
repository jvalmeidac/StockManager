using StockManager.Dominio.Dtos;
using StockManager.Dominio.Queries.Produtos;
using StockManager.Dominio.Repositories;
using StockManager.SharedKernel.Dispatcher.Interfaces;

namespace StockManager.Application.QueryHandlers.Produtos;

public class BuscarProdutosQueryHandler(IProdutoRepository produtoRepository) 
    : IQueryHandler<BuscarProdutosQuery, ICollection<ProdutoDto>>
{
    public async Task<ICollection<ProdutoDto>> HandleAsync(BuscarProdutosQuery query)
    {
        var produtos = (await produtoRepository.GetAllAsync()).ToList();
        if (!produtos.Any())
        {
            return [];
        }

        return [.. produtos.Select(produto => new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            CategoriaNome = produto.Categoria.Nome,
            TamanhoCodigo = produto.Tamanho.Codigo,
            MarcaNome = produto.Marca.Nome,
            CodigoSku = produto.CodigoSku,
            Cor = produto.Cor,
            Preco = produto.Preco,
            QuantidadeEstoque = produto.QuantidadeEstoque
        })];
    }
}