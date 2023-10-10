namespace project1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button3 = new Button();
            form1BindingSource = new BindingSource(components);
            form1BindingSource1 = new BindingSource(components);
            form1BindingSource2 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource2).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(322, 169);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 23);
            comboBox1.TabIndex = 0;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(621, 169);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Daily";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton_CheckedChanged_setPeriod;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(721, 169);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Weekly";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton_CheckedChanged_setPeriod;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(821, 169);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(70, 19);
            radioButton3.TabIndex = 3;
            radioButton3.Text = "Monthly";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton_CheckedChanged_setPeriod;
            // 
            // button1
            // 
            button1.Location = new Point(551, 309);
            button1.Name = "button1";
            button1.Size = new Size(134, 63);
            button1.TabIndex = 4;
            button1.Text = "View Ticker";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(563, 421);
            button2.Name = "button2";
            button2.Size = new Size(110, 37);
            button2.TabIndex = 5;
            button2.Text = "Open File (.csv)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += openFile;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button3
            // 
            button3.Location = new Point(558, 416);
            button3.Name = "button3";
            button3.Size = new Size(115, 42);
            button3.TabIndex = 6;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button button1;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private Button button3;
        private BindingSource form1BindingSource;
        private BindingSource form1BindingSource1;
        private BindingSource form1BindingSource2;
    }
}