﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MeshAnalysis.Properties;

namespace MeshAnalysis
{
    static class Program
    {
        public static string Adress { get; set; }
        public static string TAdress { get; set; }

        public static Button CreateButton(string text, Font font)
        {
            return new Button
                   {
                       Anchor = AnchorStyles.None,
                       BackColor = Settings.Default.NavButtonBackground,
                       Size = new Size(250, 50),
                       Font = Settings.Default.NavButtonFont,
                       FlatStyle = FlatStyle.Flat,
                       FlatAppearance =
                       {
                           BorderColor = Color.FromArgb(17, 34, 51),
                           BorderSize = 1
                       },
                       Text = text
                   };
        }
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
