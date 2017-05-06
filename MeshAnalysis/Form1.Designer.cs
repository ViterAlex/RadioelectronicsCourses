namespace MeshAnalysis
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.theoryButton = new System.Windows.Forms.Button();
            this.practiceButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // theoryButton
            // 
            this.theoryButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.theoryButton.BackColor = global::MeshAnalysis.Properties.Settings.Default.ButtonBackColor;
            this.theoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.theoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.theoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.theoryButton.ForeColor = global::MeshAnalysis.Properties.Settings.Default.ButtonForeColor;
            this.theoryButton.Location = new System.Drawing.Point(193, 86);
            this.theoryButton.Name = "theoryButton";
            this.theoryButton.Size = new System.Drawing.Size(291, 57);
            this.theoryButton.TabIndex = 0;
            this.theoryButton.Text = "Теория";
            this.theoryButton.UseVisualStyleBackColor = false;
            this.theoryButton.Click += new System.EventHandler(this.theoryButton_Click);
            // 
            // practiceButton
            // 
            this.practiceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.practiceButton.AutoEllipsis = true;
            this.practiceButton.BackColor = global::MeshAnalysis.Properties.Settings.Default.ButtonBackColor;
            this.practiceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.practiceButton.FlatAppearance.BorderSize = 2;
            this.practiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.practiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.practiceButton.ForeColor = global::MeshAnalysis.Properties.Settings.Default.ButtonForeColor;
            this.practiceButton.Location = new System.Drawing.Point(193, 165);
            this.practiceButton.Margin = new System.Windows.Forms.Padding(0);
            this.practiceButton.Name = "practiceButton";
            this.practiceButton.Size = new System.Drawing.Size(291, 56);
            this.practiceButton.TabIndex = 1;
            this.practiceButton.Text = "Практика";
            this.practiceButton.UseVisualStyleBackColor = false;
            this.practiceButton.Click += new System.EventHandler(this.practiceButton_Click);
            // 
            // allButton
            // 
            this.allButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.allButton.AutoEllipsis = true;
            this.allButton.BackColor = global::MeshAnalysis.Properties.Settings.Default.ButtonBackColor;
            this.allButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.allButton.FlatAppearance.BorderSize = 2;
            this.allButton.FlatStyle = global::MeshAnalysis.Properties.Settings.Default.ButtonFlatStyle;
            this.allButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.allButton.ForeColor = global::MeshAnalysis.Properties.Settings.Default.ButtonForeColor;
            this.allButton.Location = new System.Drawing.Point(193, 244);
            this.allButton.Margin = new System.Windows.Forms.Padding(0);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(291, 56);
            this.allButton.TabIndex = 2;
            this.allButton.Text = "Итоговый тест";
            this.allButton.UseVisualStyleBackColor = false;
            this.allButton.Visible = false;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(645, 381);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.practiceButton);
            this.Controls.Add(this.theoryButton);
            this.Name = "Form1";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button theoryButton;
        private System.Windows.Forms.Button practiceButton;
        private System.Windows.Forms.Button allButton;
    }
}

