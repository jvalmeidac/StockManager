using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using StockManager.Dominio.Dtos;
using StockManager.Dominio.Queries.Produtos;
using IDispatcher = StockManager.SharedKernel.Dispatcher.IDispatcher;

namespace StockManager.UI.PageModels;

public class ProdutosPageModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IDispatcher _dispatcher;
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ProdutoDto> Produtos { get; set; } = [];

    public ProdutosPageModel(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        CarregarDados();
    }

    public async void CarregarDados()
    {
        Produtos.Clear();
        var produtos = await _dispatcher.SendQueryAsync(new BuscarProdutosQuery());
        foreach (var produto in produtos)
        {
            Produtos.Add(produto);
        }
    }
}