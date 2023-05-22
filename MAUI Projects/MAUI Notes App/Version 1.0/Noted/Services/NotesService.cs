using System.Net.Http.Json;

namespace Noted.Services
{
    public class NotesService
    {
        HttpClient httpClient;

        public NotesService()
        {
            this.httpClient = new HttpClient();
        }

        List<Note> notesList = new();
        public async Task<List<Note>> GetNotes()
        {

            if (notesList?.Count > 0)
                return notesList;

            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/RafaelSilvajs/jsonconsume/main/notes.json");

            if (response.IsSuccessStatusCode)
            {
                notesList = await response.Content.ReadFromJsonAsync<List<Note>>();
            }

            return notesList;

        }

    }
}
