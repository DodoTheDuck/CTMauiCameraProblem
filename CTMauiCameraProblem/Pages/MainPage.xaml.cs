using CTMauiCameraProblem.Models;
using CTMauiCameraProblem.PageModels;

namespace CTMauiCameraProblem.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}