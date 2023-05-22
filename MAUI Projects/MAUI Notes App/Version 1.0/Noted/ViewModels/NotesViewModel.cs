using Noted.Services;
using Noted.Views;

namespace Noted.ViewModels;
public partial class NotesViewModel : BaseViewModel
{
    NotesService notesService;
    public ObservableCollection<Note> Notes { get; } = new();

    [ObservableProperty]
    bool isRefreshing;

    public NotesViewModel(NotesService notesService)
    {
        Title = "Taking Notes";
        this.notesService = notesService;
    }

    [RelayCommand]
    async Task GoToDetails(Note note)
    {
        if (note == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
    {
        {"Note", note}
    });
    }

    [RelayCommand]
    async Task GetNotesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var notes = await notesService.GetNotes();

            if (Notes.Count != 0)
                Notes.Clear();

            foreach (var note in notes)
                Notes.Add(note);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to get the notes: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }
}
