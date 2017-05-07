namespace MeshAnalysis.Controls
{
    partial class SketchControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SketchControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sketchPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.penWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.figuresToolStrip = new System.Windows.Forms.ToolStrip();
            this.modeSelector = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.colorSelectControl1 = new MeshAnalysis.Controls.ColorSelectControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.figuresToolStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.sketchPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(81, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 220);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // sketchPanel
            // 
            this.sketchPanel.AutoSize = true;
            this.sketchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sketchPanel.BackColor = System.Drawing.Color.White;
            this.sketchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sketchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sketchPanel.Location = new System.Drawing.Point(3, 3);
            this.sketchPanel.Name = "sketchPanel";
            this.sketchPanel.Size = new System.Drawing.Size(320, 148);
            this.sketchPanel.TabIndex = 2;
            this.sketchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sketchPanel_Paint);
            this.sketchPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sketchPanel_MouseDown);
            this.sketchPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sketchPanel_MouseMove);
            this.sketchPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sketchPanel_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.colorSelectControl1);
            this.flowLayoutPanel1.Controls.Add(this.penWidthNumericUpDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 157);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 60);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // penWidthNumericUpDown
            // 
            this.penWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.penWidthNumericUpDown.DecimalPlaces = 1;
            this.penWidthNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.penWidthNumericUpDown.Location = new System.Drawing.Point(58, 16);
            this.penWidthNumericUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.penWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penWidthNumericUpDown.Name = "penWidthNumericUpDown";
            this.penWidthNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.penWidthNumericUpDown.TabIndex = 7;
            this.penWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.figuresToolStrip, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(410, 251);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // figuresToolStrip
            // 
            this.figuresToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.figuresToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.figuresToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeSelector});
            this.figuresToolStrip.Location = new System.Drawing.Point(0, 0);
            this.figuresToolStrip.Name = "figuresToolStrip";
            this.tableLayoutPanel2.SetRowSpan(this.figuresToolStrip, 2);
            this.figuresToolStrip.Size = new System.Drawing.Size(78, 251);
            this.figuresToolStrip.TabIndex = 6;
            this.figuresToolStrip.Text = "figuresToolStrip";
            // 
            // modeSelector
            // 
            this.modeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(73, 23);
            this.modeSelector.SelectedIndexChanged += new System.EventHandler(this.modeSelector_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.redoButton,
            this.undoButton,
            this.toolStripSeparator1,
            this.clearButton});
            this.toolStrip2.Location = new System.Drawing.Point(78, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(332, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel1.Text = "Размер кисти";
            // 
            // clearButton
            // 
            this.clearButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(63, 22);
            this.clearButton.Text = "Очистить";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = global::MeshAnalysis.Properties.Resources.Undo;
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "Отменить";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = global::MeshAnalysis.Properties.Resources.Redo;
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "Повторить";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // colorSelectControl1
            // 
            this.colorSelectControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.colorSelectControl1.FillColor = System.Drawing.Color.Orange;
            this.colorSelectControl1.Location = new System.Drawing.Point(3, 3);
            this.colorSelectControl1.Name = "colorSelectControl1";
            this.colorSelectControl1.Size = new System.Drawing.Size(49, 46);
            this.colorSelectControl1.StrokeColor = System.Drawing.Color.Black;
            this.colorSelectControl1.TabIndex = 0;
            // 
            // SketchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "SketchControl";
            this.Size = new System.Drawing.Size(410, 251);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.figuresToolStrip.ResumeLayout(false);
            this.figuresToolStrip.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown penWidthNumericUpDown;
        private System.Windows.Forms.Panel sketchPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip figuresToolStrip;
        private ColorSelectControl colorSelectControl1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripComboBox modeSelector;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton clearButton;
    }
}
