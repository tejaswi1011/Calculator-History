namespace Project1;

public partial class CompletePage : ContentPage
{
	public CompletePage()
	{
		InitializeComponent();
	}

    public async void startOver(object sender, EventArgs e)

    {
        SStore.set(0);
        await Navigation.PushAsync(new ExamPage());

    }
}