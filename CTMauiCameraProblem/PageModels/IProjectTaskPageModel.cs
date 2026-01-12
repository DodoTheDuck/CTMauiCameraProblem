using CommunityToolkit.Mvvm.Input;
using CTMauiCameraProblem.Models;

namespace CTMauiCameraProblem.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}