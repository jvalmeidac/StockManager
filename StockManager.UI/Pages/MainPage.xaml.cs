using StockManager.UI.Models;
using StockManager.UI.PageModels;

namespace StockManager.UI.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}