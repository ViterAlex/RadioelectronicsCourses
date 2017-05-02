using System;
using System.Windows.Forms;

namespace MeshAnalysis
{
    static class Program
    {
        public static string Adress { get; set; }
        public static string TAdress { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
