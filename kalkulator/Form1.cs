namespace kalkulator
{
    public partial class Form1 : Form
    {
        private string _currentInput = "";
        private string _operation = "";
        private double _firstNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is not Button button) return;

            string buttonText = button.Text;

            if (double.TryParse(buttonText, out _))
            {
                _currentInput += buttonText;
                UpdateDisplay();
            }
            else if (buttonText == "C")
            {
                _currentInput = "";
                _firstNumber = 0;
                _operation = "";
                UpdateDisplay();
            }
            else if (buttonText == "=")
            {
                PerformCalculation();
            }
            else
            {
                if (_currentInput != "")
                {
                    _firstNumber = double.Parse(_currentInput);
                    _currentInput = "";
                }
                _operation = buttonText;
                UpdateDisplay();
            }
        }

        private void PerformCalculation()
        {
            if (string.IsNullOrEmpty(_operation) || _currentInput == "") return;

            double secondNumber = double.Parse(_currentInput);
            double result = 0;

            switch (_operation)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "*":
                    result = _firstNumber * secondNumber;
                    break;
                case "/":
                    result = secondNumber != 0 ? _firstNumber / secondNumber : 0;
                    break;
            }

            _currentInput = result.ToString();
            _operation = "";
            _firstNumber = 0;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            textBox1.Text = _currentInput;
        }
    }
}

