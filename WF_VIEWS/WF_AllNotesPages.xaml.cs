namespace WANDERLEYFLORES_WF.WF_VIEWS;

public partial class WF_AllNotesPages : ContentPage
{
	public WF_AllNotesPages()
	{
		InitializeComponent();

        BindingContext = new WF_Models.AllNotes();
       
    }

    protected override void OnAppearing()
    {
        ((WF_Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WF_Models));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (WF_Models.WF_Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}