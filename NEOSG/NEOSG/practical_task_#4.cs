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

    public List<List<string>> AddNote(List<List<string>> container)
    {
        List<string> new_note = new List<string>() { date.ToString(), preview, description };
        container.Add(new_note);
        return container;
    }
}

// // List<List<int>> matrix = new List<List<int>>(){};
// // for (int i = 0; i < 10; i++)
// // {
// //     List<int> elem = new List<int>(){1, 2};
// //     matrix.Add(elem);
// // }
//
// // foreach (var list in matrix)
// // {
// //     Console.WriteLine(String.Join(',', list));
// // }