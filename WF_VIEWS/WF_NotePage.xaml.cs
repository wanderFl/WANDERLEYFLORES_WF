namespace WANDERLEYFLORES_WF.Views;


public partial class WF_NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "Wanderley Flores");

    public WF_NotePage()
    {
        InitializeComponent();


        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(_fileName, WFTextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        WFTextEditor.Text = string.Empty;
    }
    private void LoadNote(string fileName)
    {
        WF_Models.WF_Note noteModel = new WF_Models.WF_Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}