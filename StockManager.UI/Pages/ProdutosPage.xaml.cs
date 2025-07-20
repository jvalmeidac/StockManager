namespace StockManager.UI.Pages;

public partial class ProdutosPage : ContentPage
{
    public ProdutosPage(ProdutosPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}