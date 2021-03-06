﻿using System;
using System.Globalization;
using System.Windows.Forms;
using XmlTypes;

namespace Controls
{
    public partial class CaseControl : UserControl
    {
        public CaseControl()
        {
            InitializeComponent();
            numericUpDown1.Minimum = decimal.MinValue;
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown1.DecimalPlaces = 3;
        }

        public Case Case { get; private set; }
        public string Answer
        {
            get
            {
                return Math.Round(numericUpDown1.Value, 3).ToString(CultureInfo.CurrentCulture);
            }
        }

        private string _value;
        public CaseControl(Case @case)
            : this()
        {
            Case = @case;
            label1.Text = @case.Id;
            label2.Text = @case.Si;
            _value = @case.Value;
        }

        /// <summary>
        /// Проверка правильности введённого значения
        /// </summary>
        public bool IsCorrectAnswer()
        {
            //Введённое значение округляется до 3 символов и сравнивается со строковым значением из файла.
            return numericUpDown1.Value.ToString("f3", CultureInfo.CurrentCulture).Equals(_value);
        }
    }
}
