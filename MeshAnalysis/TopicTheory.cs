using System.Windows.Forms;

namespace MeshAnalysis
{
    /// <summary>
    /// Форма с теорией по заданной теме
    /// </summary>
    public partial class TopicTheory : Form
    {
        public TopicTheory()
        {
            InitializeComponent();
            webBrowser1.Navigate(System.IO.Path.GetFullPath(Program.TAdress));
        }

    }
}
