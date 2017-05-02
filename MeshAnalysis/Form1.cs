using System;
using System.Windows.Forms;

namespace MeshAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void theoryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Theory theory = new Theory();
            theory.Closed += (o, args) =>
            {
                Show();
                theory.Dispose();
            };
            theory.Show();
        }

        private void practiceButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Select select = new Select();
            select.Closed += (o, args) =>
            {
                Show();
                select.Dispose();
            };
            select.Show();
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Adress = System.IO.Path.GetFullPath(@"ex.xml");
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
