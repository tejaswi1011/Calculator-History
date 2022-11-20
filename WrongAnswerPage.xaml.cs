namespace Project1;

public partial class WrongAnswerPage : ContentPage
{
	public WrongAnswerPage()
	{
		InitializeComponent();
	}
    public async void skipNext(object sender, EventArgs e)

    {
        SStore.set(SStore.page + 1);
        if (SStore.page >= 9)
        {
            await Navigation.PushAsync(new CompletePage());
            return;
        }
        await Navigation.PushAsync(new ExamPage());
    }



    public async void tryTheQuestionAgain(object sender, EventArgs e)

    {
        SStore.set(SStore.page);
        await Navigation.PushAsync(new ExamPage());

    }
}