using System;
using System.Windows.Forms;
using MeshAnalysis;

namespace Controls
{
    public partial class CalcControl : UserControl
    {
        public CalcControl()
        {
            InitializeComponent();
            labelNumber.Text = "0";
        }

        private readonly Calc _calc = new Calc();

        private int k;
        //Калькулятор
        private void CorrectNumber()
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (labelNumber.Text.IndexOf("∞") != -1)
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (labelNumber.Text[0] == '0' && (labelNumber.Text.IndexOf(",") != 1))
                labelNumber.Text = labelNumber.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (labelNumber.Text[0] == '-')
                if (labelNumber.Text[1] == '0' && (labelNumber.Text.IndexOf(",") != 2))
                    labelNumber.Text = labelNumber.Text.Remove(1, 1);
        }


        private void button00_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "0";

            CorrectNumber();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "1";

            CorrectNumber();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "2";

            CorrectNumber();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "3";

            CorrectNumber();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "4";

            CorrectNumber();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "5";

            CorrectNumber();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "6";

            CorrectNumber();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "7";

            CorrectNumber();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "8";

            CorrectNumber();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "9";

            CorrectNumber();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if ((labelNumber.Text.IndexOf(",") == -1) && (labelNumber.Text.IndexOf("∞") == -1))
                labelNumber.Text += ",";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelNumber.Text = "0";

            _calc.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (!buttonMult.Enabled)
                labelNumber.Text = _calc.Multiplication(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonDiv.Enabled)
                labelNumber.Text = _calc.Division(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonPlus.Enabled)
                labelNumber.Text = _calc.Sum(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonMinus.Enabled)
                labelNumber.Text = _calc.Subtraction(Convert.ToDouble(labelNumber.Text)).ToString();

            _calc.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMinus.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonPlus.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonDiv.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMult.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                labelNumber.Text = _calc.Square().ToString();

                _calc.Clear_A();
                FreeButtons();
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                _calc.Put_A(Convert.ToDouble(labelNumber.Text));

                labelNumber.Text = _calc.Sqrt().ToString();

                _calc.Clear_A();
                FreeButtons();
            }
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text[0] == '-')
                labelNumber.Text = labelNumber.Text.Remove(0, 1);
            else
                labelNumber.Text = "-" + labelNumber.Text;
        }
        private bool CanPress()
        {
            if (!buttonMult.Enabled)
                return false;

            if (!buttonDiv.Enabled)
                return false;

            if (!buttonPlus.Enabled)
                return false;

            if (!buttonMinus.Enabled)
                return false;

            return true;
        }

        private void FreeButtons()
        {
            buttonMult.Enabled = true;
            buttonDiv.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
        }

    }
}
