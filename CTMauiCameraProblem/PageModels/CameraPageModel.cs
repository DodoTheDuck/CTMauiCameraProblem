using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CTMauiCameraProblem.PageModels
{
    public partial class CameraPageModel : ObservableObject
    {
        [ObservableProperty]
        private ImageSource? _capturedImage;

        [ObservableProperty]
        private bool _hasPhoto;

        [RelayCommand]
        private void PhotoCaptured(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                CapturedImage = ImageSource.FromFile(imagePath);
                HasPhoto = true;
            }
        }

        [RelayCommand]
        private void ClearPhoto()
        {
            CapturedImage = null;
            HasPhoto = false;
        }
    }
}
