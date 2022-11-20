using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Project1;

public partial class ExamPage : ContentPage
{
    private int _qn = 0;
    private string _correnct = "";

    public ExamPage()

    {

        InitializeComponent();
        restoreQuestion();
        renderQuestion();

    }

    public void restoreQuestion()

    {

        _qn = SStore.page;

    }



    public async void nextQuestion()

    {

        ++_qn;
        SStore.set(_qn);
        if(_qn >= 9)
        {
            await Navigation.PushAsync(new CompletePage());
            return;
        }

        renderQuestion();

    }



    public async void renderQuestion()

    {
        this.sucessMsg.Text = "";
        APIService rest = new APIService();

        var questionData = await rest.getAnswerJSON(_qn);

        questionLabel.Text = questionData.questionText;

        optOneBtn.Text = questionData.optionOne;

        optTwoBtn.Text = questionData.optionTwo;

        optThreeBtn.Text = questionData.optionThree;

        _correnct = questionData.correctOptionValue;

    }



    private async void optionBtn_Clicked(object sender, EventArgs e)

    {

        Button button = (Button)sender;
        string selectedOption = button.Text;
        if (selectedOption == _correnct)
        {
            this.sucessMsg.Text = "You Selected the correct Answer !";
            await Task.Delay(2000);
            nextQuestion();
        }
        else
        {
            await Navigation.PushAsync(new WrongAnswerPage());
        }

      
    }


}