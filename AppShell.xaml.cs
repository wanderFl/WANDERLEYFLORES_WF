namespace WANDERLEYFLORES_WF;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.WF_NotePage), typeof(Views.WF_NotePage));
    }
}
