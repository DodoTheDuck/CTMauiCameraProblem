using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CTMauiCameraProblem.PageModels;

namespace CTMauiCameraProblem.Pages;

public partial class CameraPage : ContentPage
{
    public CameraPage(CameraPageModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await RequestCameraPermissions();
    }

    private async Task RequestCameraPermissions()
    {
        var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
        if (cameraStatus != PermissionStatus.Granted)
        {
            await DisplayAlertAsync("Permission Required", "Camera permission is required to use this feature.", "OK");
        }
    }

    private async void OnCaptureClicked(object sender, EventArgs e)
    {
        var result = await cameraView.CaptureImage(CancellationToken.None);

        if (result is not null)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, $"photo_{DateTime.Now:yyyyMMdd_HHmmss}.jpg");

            using var fileStream = File.Create(filePath);
            await result.CopyToAsync(fileStream);

            if (BindingContext is CameraPageModel viewModel)
            {
                viewModel.PhotoCapturedCommand.Execute(filePath);
            }
        }
    }

    private void OnMediaCaptured(object? sender, MediaCapturedEventArgs e)
    {
        // Optional: Handle additional media capture events
    }
}
