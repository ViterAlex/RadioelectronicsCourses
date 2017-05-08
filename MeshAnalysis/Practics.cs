using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using MeshAnalysis.Properties;
using XmlTypes;

namespace MeshAnalysis
{
    /// <summary>
    /// Форма с тестами
    /// </summary>
    public partial class Practics : Form
    {
        int allex = 0;

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
                        sw.WriteLine("<h3>{0}</h3>\r\n", Resources.ReportResultHtmltHeader);
                        sw.WriteLine(result.Message.Replace("\r\n", "<br/>"));
                        //Заметки
                        sw.WriteLine("<h3>{0}</h3><br/>", Resources.ReportNotesHtmlHeader);
                        sw.WriteLine(result.Notes.Replace("\r\n", "<br/>"));
                        //Если есть картинка, то добавляем её в раздел "Заметки"
                        if (result.Sketch != null)
                        {
                            sw.WriteLine("<img src=\"{0}\"/><br/>", result.Sketch.ImageToBase64());
                        }
                        sw.WriteLine("</td></tr>");
                    }
                    sw.WriteLine("</table>\r\n</body>\r\n</html>");
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
