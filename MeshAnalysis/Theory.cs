using System;
using System.IO;
using System.Windows.Forms;

namespace MeshAnalysis
{
    public partial class Theory : Form
    {
        public Theory()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(System.IO.Path.GetFullPath(@"TheoryFiles\EqTr\ClMe\ClMe.html"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(System.IO.Path.GetFullPath(@"TheoryFiles\EqTr\EqTrTh\EqTr.html"));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\EqTr\TrOfStIntoTr\TrOfStIntoTr.html"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\CoCuMe\CoCuMe.html"));
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\OvMe\OvMe.html"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\MeOfNoPo\MeOfNoPo.html"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\PrMe\PrMe.mht"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\CoOfRe\CoOfRe.html"));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.GetFullPath(@"TheoryFiles\OhLa\OhLa.html"));
        }
    }
}
