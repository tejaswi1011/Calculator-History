namespace Project1;

public partial class AdvCal : ContentPage
{
	public AdvCal()
	{
		InitializeComponent();
        OnClr(this, null);
    }

    string currentEntry = "";
    int currentState = 1;
    //string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";
    string equation = "";

    void OnSelectNum(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;
        equation += pressed;

        this.resultText.Text += equation;
        equation = String.Empty;
        
    }
    private void LockNumValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }

    void OnClr(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "";
        currentEntry = string.Empty;
        this.CurrentCalculation.Text = null;
    }

    void OnCalc(object sender, EventArgs e)
    {
        this.CurrentCalculation.Text = this.resultText.Text;
        Evaluate(this.resultText.Text.ToString());
    }

    void Evaluate(string input)
    {
        String expr = "(" + input + ")";
        Stack<String> ops = new Stack<String>();
        Stack<Double> vals = new Stack<Double>();

        for (int i = 0; i < expr.Length; i++)
        {
            String s = expr.Substring(i, 1);
            if (s.Equals("(")) { }
            else if (s.Equals("+")) ops.Push(s);
            else if (s.Equals("-")) ops.Push(s);
            else if (s.Equals("×")) ops.Push(s);
            else if (s.Equals("÷")) ops.Push(s);
            else if (s.Equals("Sqrt")) ops.Push(s);
            else if (s.Equals("%")) ops.Push(s);
            else if (s.Equals(")"))
            {
                int count = ops.Count;
                while (count > 0)
                {
                    String op = ops.Pop();
                    Double v = vals.Pop();
                    if (op.Equals("+")) v = vals.Pop() + v;
                    else if (op.Equals("-")) v = vals.Pop() - v;
                    else if (op.Equals("×")) v = vals.Pop() * v;
                    else if (op.Equals("÷")) v = vals.Pop() / v;
                    else if (op.Equals("Sqrt")) v = Math.Sqrt(v);
                    else if (op.Equals("%")) v = v / 100;
                    vals.Push(v);

                    count--;
                }
            }
            else
            {
                vals.Push(Double.Parse(s));
            }
        }
        this.resultText.Text = vals.Pop().ToString();
        App.viewModel.saveToHistory($"{input} = {this.resultText.Text}");
    }

}