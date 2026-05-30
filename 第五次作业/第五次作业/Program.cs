using System.Globalization;
using System.Windows.Forms;

namespace 第五次作业;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new CalculatorForm());
    }
}

public class CalculatorForm : Form
{
    private readonly TextBox displayBox;
    private string currentInput = string.Empty;
    private double? firstNumber;
    private string? selectedOperator;
    private bool isResultShown;

    public CalculatorForm()
    {
        Text = "简易计算器";
        Width = 380;
        Height = 480;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        displayBox = new TextBox
        {
            ReadOnly = true,
            Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular),
            TextAlign = HorizontalAlignment.Right,
            Width = 330,
            Height = 45,
            Left = 15,
            Top = 15
        };
        Controls.Add(displayBox);

        CreateButtons();
    }

    private void CreateButtons()
    {
        var buttonSpecs = new (string Text, int Row, int Col)[]
        {
            ("7", 0, 0), ("8", 0, 1), ("9", 0, 2), ("/", 0, 3),
            ("4", 1, 0), ("5", 1, 1), ("6", 1, 2), ("*", 1, 3),
            ("1", 2, 0), ("2", 2, 1), ("3", 2, 2), ("-", 2, 3),
            ("C", 3, 0), ("0", 3, 1), ("=", 3, 2), ("+", 3, 3)
        };

        const int buttonWidth = 75;
        const int buttonHeight = 75;
        const int margin = 8;
        const int startX = 15;
        const int startY = 80;

        foreach (var (text, row, col) in buttonSpecs)
        {
            var button = new Button
            {
                Text = text,
                Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold),
                Width = buttonWidth,
                Height = buttonHeight,
                Left = startX + col * (buttonWidth + margin),
                Top = startY + row * (buttonHeight + margin)
            };

            if (char.IsDigit(text[0]))
            {
                button.Click += (_, _) => OnDigitClicked(text);
            }
            else if (text is "+" or "-" or "*" or "/")
            {
                button.Click += (_, _) => OnOperatorClicked(text);
            }
            else if (text == "=")
            {
                button.Click += (_, _) => OnEqualClicked();
            }
            else if (text == "C")
            {
                button.Click += (_, _) => ClearAll();
            }

            Controls.Add(button);
        }
    }

    private void OnDigitClicked(string digit)
    {
        if (isResultShown)
        {
            ClearAll();
        }

        currentInput += digit;
        UpdateDisplay();
    }

    private void OnOperatorClicked(string op)
    {
        if (string.IsNullOrWhiteSpace(currentInput))
        {
            return;
        }

        if (!double.TryParse(currentInput, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
        {
            displayBox.Text = "输入错误";
            return;
        }

        if (firstNumber is null)
        {
            firstNumber = value;
        }

        selectedOperator = op;
        currentInput = string.Empty;
        isResultShown = false;
        UpdateDisplay();
    }

    private void OnEqualClicked()
    {
        if (firstNumber is null || selectedOperator is null || string.IsNullOrWhiteSpace(currentInput))
        {
            return;
        }

        if (!double.TryParse(currentInput, NumberStyles.Float, CultureInfo.InvariantCulture, out var secondNumber))
        {
            displayBox.Text = "输入错误";
            return;
        }

        var expression = $"{FormatNumber(firstNumber.Value)}{selectedOperator}{FormatNumber(secondNumber)}";

        try
        {
            var result = selectedOperator switch
            {
                "+" => firstNumber.Value + secondNumber,
                "-" => firstNumber.Value - secondNumber,
                "*" => firstNumber.Value * secondNumber,
                "/" when Math.Abs(secondNumber) < double.Epsilon => throw new DivideByZeroException(),
                "/" => firstNumber.Value / secondNumber,
                _ => throw new InvalidOperationException("未知运算符")
            };

            displayBox.Text = $"{expression}={FormatNumber(result)}";
            currentInput = result.ToString(CultureInfo.InvariantCulture);
            firstNumber = null;
            selectedOperator = null;
            isResultShown = true;
        }
        catch (DivideByZeroException)
        {
            displayBox.Text = "除数不能为0";
            ClearStateOnly();
        }
    }

    private void ClearAll()
    {
        ClearStateOnly();
        displayBox.Clear();
    }

    private void ClearStateOnly()
    {
        currentInput = string.Empty;
        firstNumber = null;
        selectedOperator = null;
        isResultShown = false;
    }

    private void UpdateDisplay()
    {
        if (firstNumber is not null && selectedOperator is not null)
        {
            displayBox.Text = $"{FormatNumber(firstNumber.Value)}{selectedOperator}{currentInput}";
            return;
        }

        displayBox.Text = currentInput;
    }

    private static string FormatNumber(double number)
    {
        return number % 1 == 0
            ? ((long)number).ToString(CultureInfo.InvariantCulture)
            : number.ToString(CultureInfo.InvariantCulture);
    }
}
