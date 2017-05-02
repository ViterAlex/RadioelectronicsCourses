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

            foreach (var file in Directory.EnumerateFiles(Path.GetFullPath("xml")))
            {
                var btn = new Button
                          {
                              Anchor = AnchorStyles.None,
                              BackColor = Color.FromArgb(68, 187, 255),
                              Size = new Size(250, 50),
                              Font = new Font(Font.FontFamily, 10, GraphicsUnit.Point),
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
                    webBrowser1.Navigate(Path.GetFullPath(doc.Root.Attribute("theory").Value));
                };
                btn.Text = doc.Root.Attribute("title").Value;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
