namespace Project1;

public partial class App : Application
{
    public static HistoryExpViewModel viewModel;

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        viewModel = new HistoryExpViewModel();

    }
}
