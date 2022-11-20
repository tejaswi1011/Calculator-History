namespace Project1;

public partial class HistoryExps : ContentPage
{
	public HistoryExps()
	{
		InitializeComponent();
		BindingContext = App.viewModel;
	}
}