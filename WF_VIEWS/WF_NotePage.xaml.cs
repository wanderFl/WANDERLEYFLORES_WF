namespace WANDERLEYFLORES_WF.Views;


public partial class WF_NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "Wanderley Flores");

    public WF_NotePage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
            WFTextEditor.Text = File.ReadAllText(_fileName);
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
}