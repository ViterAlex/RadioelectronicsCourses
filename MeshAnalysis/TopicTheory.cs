using System.Windows.Forms;

namespace MeshAnalysis
{
    public partial class TopicTheory : Form
    {
        public TopicTheory()
        {
            InitializeComponent();
            webBrowser1.Navigate(System.IO.Path.GetFullPath(Program.TAdress));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
    }
}
