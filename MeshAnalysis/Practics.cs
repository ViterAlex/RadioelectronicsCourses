using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using MeshAnalysis.Properties;

namespace MeshAnalysis
{
    public partial class Practics : Form
    {
        Calc C;
        int k, good = 0, bad = 0, allex = 0, chains = 0, chains1, chains2;
        int chains3, chains4, chains5;
        string ex1 = "Задача 1\n", ex2 = "Задача 2", ex3 = "Задача 3",
            ex4 = "Задача 4", ex5 = "Задача 5", br = "<br>", hr = "<hr>",
            pex1, pex2, pex3, pex4, pex5,
            aex1, aex2, aex3, aex4, aex5, try1, zam = "Заметки: ", answ = "Ответ: ", zad = "Условие: ";
        Color CurrentColor = Color.White;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;
        int t = 5, h = 5;
        int r = 0, gr = 0, b = 0;

        Excercises _excercises;
        public Practics()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            C = new Calc();
            labelNumber.Text = "0";
            g = panel1.CreateGraphics();
            using (var reader = new StreamReader(Program.Adress))
            {
                var serializer = new XmlSerializer(typeof(Excercises));
                _excercises = serializer.Deserialize(reader) as Excercises;
            }
            NewExercise();
            MessageBox.Show("ВНИМАНИЕ! На ввод правильного ответа для каждой задачи дано 3(три) попытки. Ответ вводить с точность до тысячных(три знака после запятой), разделяя целую и дробную части запятой(,)(Например: 32,000)");
        }

        private void Practics_Load(object sender, EventArgs e)
        {

        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (allex != 5)
            {
                MessageBox.Show("Вы не закончили тест!");
            }
            else Close();
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

            C.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (!buttonMult.Enabled)
                labelNumber.Text = C.Multiplication(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonDiv.Enabled)
                labelNumber.Text = C.Division(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonPlus.Enabled)
                labelNumber.Text = C.Sum(Convert.ToDouble(labelNumber.Text)).ToString();

            if (!buttonMinus.Enabled)
                labelNumber.Text = C.Subtraction(Convert.ToDouble(labelNumber.Text)).ToString();

            C.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMinus.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonPlus.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonDiv.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMult.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                labelNumber.Text = C.Square().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                labelNumber.Text = C.Sqrt().ToString();

                C.Clear_A();
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

        //Рисование

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                t = Convert.ToInt32(numericUpDown1.Value);
                h = Convert.ToInt32(numericUpDown1.Value);
                SolidBrush Brush = new SolidBrush(colorDialog1.Color);
                g.FillEllipse(Brush, e.X, e.Y, t, h);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
        }
        //Тест
        private void NewExercise()
        {
            if (_exerciseNumber >= _excercises.Count)
            {
                return;
            }
            pictureBox1.Image = _excercises[_exerciseNumber].GetImage();
            if (pictureBox1.Image == null)
            {
                pictureBox1.Hide();
            }
            else
            {
                pictureBox1.Show();
            }
            textBox1.Text = _excercises[_exerciseNumber].Text.ToString().Trim();
            casesControl1.SetCases(_excercises[_exerciseNumber].Cases);
            answerButton.Enabled = true;
            //casesControl1.isSel = 0;
            textBox2.Clear();
            panel1.Refresh();
            //chains = 0;
        }
        //Первая задача
        private void ex1Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 0;
            NewExercise();
            //chains = 0;
            tableLayoutPanel1.Enabled = true;
        }

        //Вторая задача
        private void ex2Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 1;
            NewExercise();
            //chains = 0;
            tableLayoutPanel1.Enabled = true;
        }

        //Третья задача
        private void ex3Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 2;
            NewExercise();
            //chains = 0;
            tableLayoutPanel1.Enabled = true;
        }

        //Четвёртая задача
        private void ex4Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 3;
            NewExercise();
            //chains = 0;
            tableLayoutPanel1.Enabled = true;
        }

        //Пятая задача
        private void ex5Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 4;
            NewExercise();
            //chains = 0;
            tableLayoutPanel1.Enabled = true;
        }

        private int _exerciseNumber;
        private int _bad;
        private int _good;

        private void button4_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ST newForm = new ST();
            newForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Theory newForm = new Theory();
            newForm.ShowDialog();
        }

        private void casesControl1_Load(object sender, EventArgs e)
        {

        }

        private string ImageToBase64(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            /*if (casesControl1.isSel == 0)
            {
                MessageBox.Show("Выберите ответ!");
                return;
            }
            */
            //textBox2.Clear();
            //allex++;
            //chains++;
            //panel1.Refresh();
            //switch (_exerciseNumber)
            //{
            //    case 0:
            //        chains1++;
            //        pex1 = textBox2.Text;
            //        if (casesControl1.CheckAnswers())
            //        {
            //            ex1Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            _good++;
            //            _exerciseNumber++;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex1 += casesControl1.GetAnswers();
            //            ex1 = textBox1.Text;
            //            allex++;
            //            ex2Button.PerformClick();
            //            good++;
            //            //ex1 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else if (chains1 == 3)
            //        {
            //            ex1Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex1 += casesControl1.GetAnswers();
            //            ex1 = textBox1.Text;
            //            bad++;
            //            allex++;
            //            //MessageBox.Show(this, "НЕПРАВИЛЬНО!");
            //            ex2Button.PerformClick();
            //            //ex1 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else MessageBox.Show(casesControl1.GetAnswers());
            //        break;
            //    case 1:
            //        chains2++;
            //        pex2 = textBox2.Text;
            //        if (casesControl1.CheckAnswers())
            //        {
            //            ex2Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            _good++;
            //            _exerciseNumber++;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex2 = casesControl1.GetAnswers();
            //            ex2 = textBox1.Text;
            //            allex++;
            //            ex3Button.PerformClick();
            //            good++;
            //            //ex2 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else if (chains2 == 3)
            //        {
            //            ex2Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex2 = casesControl1.GetAnswers();
            //            ex2 = textBox1.Text;
            //            bad++;
            //            allex++;
            //            ex3Button.PerformClick();
            //            //ex2 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else MessageBox.Show(casesControl1.GetAnswers());
            //        break;
            //    case 2:
            //        chains3++;
            //        pex3 = textBox2.Text;
            //        if (casesControl1.CheckAnswers())
            //        {
            //            ex3Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            _good++;
            //            _exerciseNumber++;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex3 = casesControl1.GetAnswers();
            //            ex3 = textBox1.Text;
            //            allex++;
            //            ex4Button.PerformClick();
            //            good++;
            //            //ex3 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else if (chains3 == 3)
            //        {
            //            ex3Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex3 = casesControl1.GetAnswers();
            //            ex3 = textBox1.Text;
            //            bad++;
            //            allex++;
            //            ex4Button.PerformClick();
            //            //ex3 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else MessageBox.Show(casesControl1.GetAnswers());
            //        break;
            //    case 3:
            //        chains4++;
            //        pex4 = textBox2.Text;
            //        if (casesControl1.CheckAnswers())
            //        {
            //            ex4Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            _good++;
            //            _exerciseNumber++;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex4 = casesControl1.GetAnswers();
            //            ex4 = textBox1.Text;
            //            allex++;
            //            ex5Button.PerformClick();
            //            good++;
            //            //ex4 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else if (chains4 == 3)
            //        {
            //            ex4Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex4 = casesControl1.GetAnswers();
            //            ex4 = textBox1.Text;
            //            bad++;
            //            allex++;
            //            ex5Button.PerformClick();
            //            //ex4 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else MessageBox.Show(casesControl1.GetAnswers());
            //        break;
            //    case 4:
            //        chains5++;
            //        pex5 = textBox2.Text;
            //        if (casesControl1.CheckAnswers())
            //        {
            //            ex5Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            _good++;
            //            _exerciseNumber++;
            //            allex++;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex5 = casesControl1.GetAnswers();
            //            ex5 = textBox1.Text;
            //            ex1Button.PerformClick();
            //            good++;
            //            //ex5 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else if (chains5 == 3)
            //        {
            //            ex5Button.Enabled = false;
            //            tableLayoutPanel1.Enabled = false;
            //            MessageBox.Show(casesControl1.GetAnswers());
            //            aex5 = casesControl1.GetAnswers();
            //            ex5 = textBox1.Text;
            //            bad++;
            //            allex++;
            //            ex1Button.PerformClick();
            //            //ex5 = textBox1.Text;
            //            //chains = 0;
            //        }
            //        else MessageBox.Show(casesControl1.GetAnswers());
            //        break;
            //    default:
            //        MessageBox.Show(this, string.Format("Правильных ответов: {0}\r\nНеправильных ответов:{1}", _good, _bad));
            //        break;

            //}

            //Проверяем ответы
            if (casesControl1.CheckAnswers())
            {
                //если все ответы верны
                //увеличиваем счётчик правильных ответов и переходим дальше.
                _good++;
                _results.Add(new Result
                {
                    Excercise = _excercises[_exerciseNumber],
                    Message = casesControl1.GetAnswers(),
                    //Здесь нужно брать нарисованную картинку и помещать в Notes
                    //Notes =
                });
                _exerciseNumber++;
                NewExercise();
                return;
            }
            _bad++;
            //Вывод информации об ответе, если есть неправильные ответы
            MessageBox.Show(casesControl1.GetAnswers(), string.Format("Задача {0}", _exerciseNumber + 1));
            //Если последняя попытка
            if (casesControl1.IsLastAttempt)
            {
                _results.Add(new Result
                {
                    Excercise = _excercises[_exerciseNumber],
                    Message = casesControl1.GetAnswers(),
                    //Здесь нужно брать нарисованную картинку и помещать в Notes
                    //Notes =
                });
                _exerciseNumber++;
                NewExercise();
            }
            if (_exerciseNumber == 5)
            {
                allex = 5;
                MessageBox.Show("Правильных ответов: " + _good + "; Неправильных ответов: " + _bad);
                Save();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private List<Result> _results = new List<Result>();
        private void Save()
        {
            using (SaveFileDialog saveFile1 = new SaveFileDialog()) {
                saveFile1.DefaultExt = "*.html";
                saveFile1.Filter = "html|*.html";
                if (saveFile1.ShowDialog() != System.Windows.Forms.DialogResult.OK
                    || saveFile1.FileName.Length == 0) return;
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, false, Encoding.UTF8))
                {
                    //шапка страницы
                    sw.WriteLine(Resources.HtmlTemplate);
                    //Для каждого результата — отдельная строка таблицы
                    foreach (var result in _results)
                    {
                        sw.WriteLine("<tr><td>");
                        //Заголовок в ячейке
                        sw.WriteLine("<h2>Задача {0}. </h2>", result.Excercise.Id);
                        //Задание
                        sw.WriteLine(result.Excercise.Text.Text);
                        //Иллюстрация к заданию
                        sw.WriteLine("<br/>\r\n<img src=\"{0}\"/><br/>", result.Excercise.Text.ImageBase64.Source);
                        sw.WriteLine("<h3>{0}</h3>\r\n", "Результат");
                        sw.WriteLine(result.Message.Replace("\r\n", "<br/>"));
                        //Если есть картинка, то добавляем раздел "Заметки"
                        if (result.Notes != null)
                        {
                            //Заметки
                            sw.WriteLine("<h3>{0}</h3><br/>", "Заметки");
                            sw.WriteLine(
                                "<img src=\"data:image/png;base64,{0}\"/><br/>", Excercise.ImageToBase64(result.Notes));
                        }
                        sw.WriteLine("</td></tr>");
                    }
                    sw.WriteLine("</table>\r\n</body>\r\n</html>");
                    //sw.WriteLine(zad);
                    //sw.WriteLine(ex1);
                    //sw.WriteLine(br);
                    //sw.WriteLine(answ);
                    //sw.WriteLine(aex1);
                    //sw.WriteLine(br);
                    //sw.WriteLine(zam);
                    //sw.WriteLine(pex1);
                    //sw.WriteLine(br);
                    //sw.WriteLine(hr);
                    //sw.WriteLine(zad);
                    //sw.WriteLine(ex2);
                    //sw.WriteLine(br);
                    //sw.WriteLine(answ);
                    //sw.WriteLine(aex2);
                    //sw.WriteLine(br);
                    //sw.WriteLine(zam);
                    //sw.WriteLine(pex2);
                    //sw.WriteLine(br);
                    //sw.WriteLine(hr);
                    //sw.WriteLine(zad);
                    //sw.WriteLine(ex3);
                    //sw.WriteLine(br);
                    //sw.WriteLine(answ);
                    //sw.WriteLine(aex3);
                    //sw.WriteLine(br);
                    //sw.WriteLine(zam);
                    //sw.WriteLine(pex3);
                    //sw.WriteLine(br);
                    //sw.WriteLine(hr);
                    //sw.WriteLine(zad);
                    //sw.WriteLine(ex4);
                    //sw.WriteLine(br);
                    //sw.WriteLine(answ);
                    //sw.WriteLine(aex4);
                    //sw.WriteLine(br);
                    //sw.WriteLine(zam);
                    //sw.WriteLine(pex4);
                    //sw.WriteLine(br);
                    //sw.WriteLine(hr);
                    //sw.WriteLine(zad);
                    //sw.WriteLine(ex5);
                    //sw.WriteLine(br);
                    //sw.WriteLine(answ);
                    //sw.WriteLine(aex5);
                    //sw.WriteLine(br);
                    //sw.WriteLine(zam);
                    //sw.WriteLine(pex5);
                    //sw.WriteLine(br);
                    //sw.WriteLine(hr);
                    sw.Close();
                }
            }
        }
        void Save_File()
        {
            try
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                writer.Write(zad);
                writer.Write(ex1);
                writer.Write(br);
                writer.Write(answ);
                writer.Write(aex1);
                writer.Write(br);
                writer.Write(zam);
                writer.Write(pex1);
                writer.Write(br);
                writer.Write(hr);
                writer.Write(zad);
                writer.Write(ex2);
                writer.Write(br);
                writer.Write(answ);
                writer.Write(aex2);
                writer.Write(br);
                writer.Write(zam);
                writer.Write(pex2);
                writer.Write(br);
                writer.Write(hr);
                writer.Write(zad);
                writer.Write(ex3);
                writer.Write(br);
                writer.Write(answ);
                writer.Write(aex3);
                writer.Write(br);
                writer.Write(zam);
                writer.Write(pex3);
                writer.Write(br);
                writer.Write(hr);
                writer.Write(zad);
                writer.Write(ex4);
                writer.Write(br);
                writer.Write(answ);
                writer.Write(aex4);
                writer.Write(br);
                writer.Write(zam);
                writer.Write(pex4);
                writer.Write(br);
                writer.Write(hr);
                writer.Write(zad);
                writer.Write(ex5);
                writer.Write(br);
                writer.Write(answ);
                writer.Write(aex5);
                writer.Write(br);
                writer.Write(zam);
                writer.Write(pex5);
                writer.Write(br);
                writer.Write(hr);
                writer.Close();
                //textBox1.Modified = false;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка сохранения", MessageBoxButtons.OK);
            }
        }
    }
}
