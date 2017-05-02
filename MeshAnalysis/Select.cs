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
            foreach (var file in Directory.EnumerateFiles(Path.GetFullPath("xml")))
            {
                var btn = new Button
                {
                    Anchor = AnchorStyles.None,
                    BackColor = Color.FromArgb(68, 187, 255),
                    Size = new Size(250, 50),
                    Font = new Font(Font.FontFamily, 10, FontStyle.Bold, GraphicsUnit.Point),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance =
                    {
                        BorderColor = Color.FromArgb(17, 34, 51),
                        BorderSize = 1
                    }
                };
                var doc = XDocument.Load(file);
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
                btn.Text = doc.Root.Attribute("title").Value;
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
