namespace Noted.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}