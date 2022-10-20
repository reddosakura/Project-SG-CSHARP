namespace NEONOTE;

public class Note
{
    private DateTime date;
    private string preview;
    private string description;
    // private List<List<string>> notes_container;

    public Note(DateTime note_date, string note_preview, string note_description)
    {
        date = note_date;
        preview = note_preview;
        description = note_description;
    }

    public List<List<string>> AddNote(List<List<string>> container) //
    {
        List<string> new_note = new List<string>() { date.ToLongDateString(), preview, description };
        container.Add(new_note);
        return container;
    }

}
