using CommunityToolkit.Mvvm.Input;
using StockManager.UI.Models;

namespace StockManager.UI.PageModels;

public interface IProjectTaskPageModel
{
    IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
    bool IsBusy { get; }
}