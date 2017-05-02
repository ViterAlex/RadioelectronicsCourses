using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MeshAnalysis
{
    public partial class Theory : Form
    {
        public Theory()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
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
                    webBrowser1.Navigate(Path.GetFullPath(doc.Root.Attribute("theory").Value));
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
