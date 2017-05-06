using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MeshAnalysis
{
    /// <summary>
    /// Форма с выбором тестов
    /// </summary>
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
            Load += (sender, args) => CreateButtons();
        }

        private void CreateButtons()
        {
            foreach (var file in Directory.EnumerateFiles(Path.GetFullPath("xml")))
            {
                var doc = XDocument.Load(file);
                var btn = Program.CreateButton(doc.Root.Attribute("title").Value, Font);
                //Клик по создаваемой кнопке
                btn.Click += (sender, args) =>
                {
                    Hide();
                    Program.Adress = file;
                    Program.TAdress = Path.GetFullPath(doc.Root.Attribute("theory").Value);
                    Practics practics = new Practics();
                    //Закрытие формы практики
                    practics.Closed += (_, __) =>
                    {
                        Show();
                        practics.Dispose();
                    };
                    practics.Show();
                };
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
