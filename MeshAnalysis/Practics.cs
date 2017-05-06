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
    /// <summary>
    /// Форма с тестами
    /// </summary>
    public partial class Practics : Form
    {
        //int good = 0, bad = 0, chains = 0, chains1, chains2;

        int allex = 0;

        //int chains3, chains4, chains5;
        //string ex1 = "Задача 1\n", ex2 = "Задача 2", ex3 = "Задача 3",
        //    ex4 = "Задача 4", ex5 = "Задача 5", br = "<br>", hr = "<hr>",
        //    pex1, pex2, pex3, pex4, pex5,
        //    aex1, aex2, aex3, aex4, aex5, try1, zam = "Заметки: ", answ = "Ответ: ", zad = "Условие: ";
        //int r = 0, gr = 0, b = 0;

        private int _exerciseNumber;//Номер текущего вопроса
        private int _bad;//Количество неправильных ответов
        private int _good;//Количество правильных ответов
        private readonly List<Result> _results = new List<Result>();
        private readonly Excercises _excercises;

        public Practics()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            using (var reader = new StreamReader(Program.Adress))
            {
                var serializer = new XmlSerializer(typeof(Excercises));
                _excercises = serializer.Deserialize(reader) as Excercises;
            }
            NewExercise();
            MessageBox.Show("ВНИМАНИЕ! На ввод правильного ответа для каждой задачи дано 3(три) попытки. Ответ вводить с точность до тысячных(три знака после запятой), разделяя целую и дробную части запятой(,)(Например: 32,000)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (allex != 5)
            {
                MessageBox.Show("Вы не закончили тест!");
            }
            else Close();
        }

        //Тест
        private void NewExercise()
        {
            if (_exerciseNumber >= _excercises.Count)
            {
                return;
            }
            pictureBox1.Image = _excercises[_exerciseNumber].Caption.GetImage();
            if (pictureBox1.Image == null)
            {
                pictureBox1.Hide();
            }
            else
            {
                pictureBox1.Show();
            }
            textBox1.Text = _excercises[_exerciseNumber].Caption.ToString();
            casesControl1.SetCases(_excercises[_exerciseNumber].Cases);
            answerButton.Enabled = true;
            sketchControl1.StartNewSketch();
            //casesControl1.isSel = 0;
            notesTextBox.Clear();
            
        }

        //Первая задача
        private void ex1Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 0;
            NewExercise();
            
            tableLayoutPanel1.Enabled = true;
        }

        //Вторая задача
        private void ex2Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 1;
            NewExercise();
            
            tableLayoutPanel1.Enabled = true;
        }

        //Третья задача
        private void ex3Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 2;
            NewExercise();
            
            tableLayoutPanel1.Enabled = true;
        }

        //Четвёртая задача
        private void ex4Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 3;
            NewExercise();
            
            tableLayoutPanel1.Enabled = true;
        }

        //Пятая задача
        private void ex5Button_Click(object sender, EventArgs e)
        {
            _exerciseNumber = 4;
            NewExercise();
            
            tableLayoutPanel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TopicTheory newForm = new TopicTheory())
            {
                newForm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Theory newForm = new Theory())
            {
                newForm.ShowDialog();
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
            //            
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
                    //Здесь нужно брать нарисованную картинку и помещать в Sketch
                    Sketch = sketchControl1.GetSketch(),
                    Notes = notesTextBox.Text
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
                    //Здесь нужно брать нарисованную картинку и помещать в Sketch
                    Sketch = sketchControl1.GetSketch(),
                    Notes = notesTextBox.Text
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

        private void Save()
        {
            using (SaveFileDialog saveFile1 = new SaveFileDialog())
            {
                saveFile1.DefaultExt = "*.html";
                saveFile1.Filter = "html|*.html";
                if (saveFile1.ShowDialog() != DialogResult.OK
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
                        sw.WriteLine(result.Excercise.Caption.Text);
                        //Иллюстрация к заданию
                        sw.WriteLine("<br/>\r\n<img src=\"{0}\"/><br/>", result.Excercise.Caption.ImageBase64.Source);
                        sw.WriteLine("<h3>{0}</h3>\r\n", "Результат");
                        sw.WriteLine(result.Message.Replace("\r\n", "<br/>"));
                        //Заметки
                        sw.WriteLine("<h3>{0}</h3><br/>", "Заметки");
                        sw.WriteLine(result.Notes.Replace("\r\n", "<br/>"));
                        //Если есть картинка, то добавляем её в раздел "Заметки"
                        if (result.Sketch != null)
                        {
                            sw.WriteLine("<img src=\"{0}\"/><br/>", result.Sketch.ImageToBase64());
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
        //void Save_File()
        //{
        //    try
        //    {
        //        StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
        //        writer.Write(zad);
        //        writer.Write(ex1);
        //        writer.Write(br);
        //        writer.Write(answ);
        //        writer.Write(aex1);
        //        writer.Write(br);
        //        writer.Write(zam);
        //        writer.Write(pex1);
        //        writer.Write(br);
        //        writer.Write(hr);
        //        writer.Write(zad);
        //        writer.Write(ex2);
        //        writer.Write(br);
        //        writer.Write(answ);
        //        writer.Write(aex2);
        //        writer.Write(br);
        //        writer.Write(zam);
        //        writer.Write(pex2);
        //        writer.Write(br);
        //        writer.Write(hr);
        //        writer.Write(zad);
        //        writer.Write(ex3);
        //        writer.Write(br);
        //        writer.Write(answ);
        //        writer.Write(aex3);
        //        writer.Write(br);
        //        writer.Write(zam);
        //        writer.Write(pex3);
        //        writer.Write(br);
        //        writer.Write(hr);
        //        writer.Write(zad);
        //        writer.Write(ex4);
        //        writer.Write(br);
        //        writer.Write(answ);
        //        writer.Write(aex4);
        //        writer.Write(br);
        //        writer.Write(zam);
        //        writer.Write(pex4);
        //        writer.Write(br);
        //        writer.Write(hr);
        //        writer.Write(zad);
        //        writer.Write(ex5);
        //        writer.Write(br);
        //        writer.Write(answ);
        //        writer.Write(aex5);
        //        writer.Write(br);
        //        writer.Write(zam);
        //        writer.Write(pex5);
        //        writer.Write(br);
        //        writer.Write(hr);
        //        writer.Close();
        //        //textBox1.Modified = false;

        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message, "Ошибка сохранения", MessageBoxButtons.OK);
        //    }
        //}
    }
}
