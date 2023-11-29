namespace WANDERLEYFLORES_WF.Views;

public partial class WF_AbousPage : ContentPage

{
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is WF_Models.WF_About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}