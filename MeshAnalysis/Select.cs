using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MeshAnalysis
{
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
                btn.Click += (sender, args) =>
                {
                    Hide();
                    Program.Adress = file;
                    Program.TAdress = Path.GetFullPath(doc.Root.Attribute("theory").Value);
                    Practics practics = new Practics();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Adress = System.IO.Path.GetFullPath(@"clme.xml");
            Program.TAdress = System.IO.Path.GetFullPath(@"TheoryFiles\EqTr\ClMe\ClMe.html");
            Practics practics = new Practics();
            practics.Closed += (o, args) =>
            {
                Show();
                practics.Dispose();
            };
            practics.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Adress = System.IO.Path.GetFullPath(@"twnome.xml");
            Program.TAdress = System.IO.Path.GetFullPath(@"TheoryFiles\MeOfNoPo\MeOfNoPo.html");
            Practics practics = new Practics();
            practics.Closed += (o, args) =>
            {
                Show();
                practics.Dispose();
            };
            practics.Show();
        }
    }
}
