namespace Noted.ViewModels;

[QueryProperty(nameof(Note), "Note")]
public partial class DetailViewModel : BaseViewModel
{
    public DetailViewModel()
    {
    }

    [ObservableProperty]
    Note note;
}