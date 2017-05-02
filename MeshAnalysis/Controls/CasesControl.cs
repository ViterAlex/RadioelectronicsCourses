using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeshAnalysis.Controls
{
    public partial class CasesControl : UserControl
    {
        public CasesControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие, которое будет вызываться при исчерпании попыток.
        /// </summary>
        public event EventHandler LastAttempt;

        private int _attempts;//счётчик попыток
        public byte SelectedCaseId { get; set; }
        public bool IsLastAttempt
        {
            get
            {
                return _attempts == 3;
            }
        }
        public CasesControl(Cases cases)
            : this()
        {
        }

        public void SetCases(Cases cases)
        {
            flowLayoutPanel1.Controls.Clear();
            _attempts = 0;//если заполняем вариантами ответов, то это новый вопрос.
            foreach (var @case in cases.CaseList)
            {
                //Здесь добавляем нужный контрол. Вмето RadioButton добавляем CaseControl
                var cc = new CaseControl(@case);
                flowLayoutPanel1.Controls.Add(cc);
            }
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            SelectedCaseId = (byte)rb.Tag;
        }
        /// <summary>
        /// Проверка правильности введённых ответов
        /// </summary>
        public bool CheckAnswers()
        {
            var result = true;
            foreach (var caseControl in flowLayoutPanel1.Controls.OfType<CaseControl>())
            {
                result = result && caseControl.IsCorrectAnswer();
            }
            _attempts++;
            return result;
        }

        public string GetAnswers()
        {
            var sb = new StringBuilder();
            int correct = 0, incorrect = 0;
            foreach (var caseControl in flowLayoutPanel1.Controls.OfType<CaseControl>())
            {
                string result;
                if (caseControl.IsCorrectAnswer())
                {
                    result = "Правильно";
                    correct++;
                }
                else
                {
                    result = "Неправильно";
                    incorrect++;
                }
                sb.AppendFormat("{0}. Ваш ответ: {1}. {2}", caseControl.Case.Id, caseControl.Answer, result);
                sb.AppendLine();
            }
            sb.AppendFormat("Правильных ответов: {0}. Неправильных ответов: {1}", correct, incorrect);
            sb.AppendLine();
            sb.AppendFormat("Осталось попыток: {0}", 3 - _attempts);
            return sb.ToString();
        }

        protected virtual void OnLastAttempt()
        {
            LastAttempt?.Invoke(this, EventArgs.Empty);
        }
    }
}