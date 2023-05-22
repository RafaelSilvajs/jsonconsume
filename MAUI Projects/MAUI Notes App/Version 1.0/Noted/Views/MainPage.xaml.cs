namespace Noted.Views;

public partial class MainPage : ContentPage
{
    public MainPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
