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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            comboBox1_ticker = new ComboBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            button1_viewTicker = new Button();
            button2_openFile = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button3_reset = new Button();
            form1BindingSource = new BindingSource(components);
            form1BindingSource1 = new BindingSource(components);
            form1BindingSource2 = new BindingSource(components);
            chart1_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2_volume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dateTimePicker1_fromDate = new DateTimePicker();
            dateTimePicker2_toDate = new DateTimePicker();
            label1_ticker = new Label();
            label2_fromDate = new Label();
            label3_toDate = new Label();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2_volume).BeginInit();
            SuspendLayout();
            // 
            // comboBox1_ticker
            // 
            comboBox1_ticker.FormattingEnabled = true;
            comboBox1_ticker.Location = new Point(322, 169);
            comboBox1_ticker.Name = "comboBox1_ticker";
            comboBox1_ticker.Size = new Size(240, 23);
            comboBox1_ticker.TabIndex = 0;
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
            // button1_viewTicker
            // 
            button1_viewTicker.Location = new Point(558, 396);
            button1_viewTicker.Name = "button1_viewTicker";
            button1_viewTicker.Size = new Size(134, 63);
            button1_viewTicker.TabIndex = 4;
            button1_viewTicker.Text = "View Ticker";
            button1_viewTicker.UseVisualStyleBackColor = true;
            button1_viewTicker.Click += button1_Click;
            // 
            // button2_openFile
            // 
            button2_openFile.Location = new Point(570, 508);
            button2_openFile.Name = "button2_openFile";
            button2_openFile.Size = new Size(110, 37);
            button2_openFile.TabIndex = 5;
            button2_openFile.Text = "Open File (.csv)";
            button2_openFile.UseVisualStyleBackColor = true;
            button2_openFile.Click += openFile;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button3_reset
            // 
            button3_reset.Location = new Point(1104, 603);
            button3_reset.Name = "button3_reset";
            button3_reset.Size = new Size(115, 42);
            button3_reset.TabIndex = 6;
            button3_reset.Text = "Reset";
            button3_reset.UseVisualStyleBackColor = true;
            button3_reset.Visible = false;
            button3_reset.Click += button3_Click_reset;
            // 
            // chart1_stockData
            // 
            chartArea3.Name = "ChartArea1";
            chart1_stockData.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1_stockData.Legends.Add(legend3);
            chart1_stockData.Location = new Point(654, 24);
            chart1_stockData.Name = "chart1_stockData";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            chart1_stockData.Series.Add(series3);
            chart1_stockData.Size = new Size(582, 259);
            chart1_stockData.TabIndex = 7;
            chart1_stockData.Text = "chart1";
            chart1_stockData.Visible = false;
            // 
            // chart2_volume
            // 
            chartArea4.Name = "ChartArea1";
            chart2_volume.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart2_volume.Legends.Add(legend4);
            chart2_volume.Location = new Point(654, 300);
            chart2_volume.Name = "chart2_volume";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart2_volume.Series.Add(series4);
            chart2_volume.Size = new Size(582, 267);
            chart2_volume.TabIndex = 8;
            chart2_volume.Text = "chart2";
            chart2_volume.Visible = false;
            // 
            // dateTimePicker1_fromDate
            // 
            dateTimePicker1_fromDate.Location = new Point(396, 286);
            dateTimePicker1_fromDate.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            dateTimePicker1_fromDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1_fromDate.Name = "dateTimePicker1_fromDate";
            dateTimePicker1_fromDate.Size = new Size(200, 23);
            dateTimePicker1_fromDate.TabIndex = 9;
            dateTimePicker1_fromDate.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker2_toDate
            // 
            dateTimePicker2_toDate.Location = new Point(657, 286);
            dateTimePicker2_toDate.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            dateTimePicker2_toDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker2_toDate.Name = "dateTimePicker2_toDate";
            dateTimePicker2_toDate.Size = new Size(200, 23);
            dateTimePicker2_toDate.TabIndex = 10;
            // 
            // label1_ticker
            // 
            label1_ticker.AutoSize = true;
            label1_ticker.Location = new Point(322, 141);
            label1_ticker.Name = "label1_ticker";
            label1_ticker.Size = new Size(44, 15);
            label1_ticker.TabIndex = 11;
            label1_ticker.Text = "Ticker: ";
            // 
            // label2_fromDate
            // 
            label2_fromDate.AutoSize = true;
            label2_fromDate.Location = new Point(396, 268);
            label2_fromDate.Name = "label2_fromDate";
            label2_fromDate.Size = new Size(41, 15);
            label2_fromDate.TabIndex = 12;
            label2_fromDate.Text = "From: ";
            // 
            // label3_toDate
            // 
            label3_toDate.AutoSize = true;
            label3_toDate.Location = new Point(657, 268);
            label3_toDate.Name = "label3_toDate";
            label3_toDate.Size = new Size(25, 15);
            label3_toDate.TabIndex = 13;
            label3_toDate.Text = "To: ";
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "All Stock Files|*.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly Stocks|*-Month.csv";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label3_toDate);
            Controls.Add(label2_fromDate);
            Controls.Add(label1_ticker);
            Controls.Add(dateTimePicker2_toDate);
            Controls.Add(dateTimePicker1_fromDate);
            Controls.Add(chart2_volume);
            Controls.Add(chart1_stockData);
            Controls.Add(button3_reset);
            Controls.Add(button2_openFile);
            Controls.Add(button1_viewTicker);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(comboBox1_ticker);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2_volume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1_ticker;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button button1_viewTicker;
        private Button button2_openFile;
        private ContextMenuStrip contextMenuStrip1;
        private Button button3_reset;
        private BindingSource form1BindingSource;
        private BindingSource form1BindingSource1;
        private BindingSource form1BindingSource2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1_stockData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2_volume;
        private DateTimePicker dateTimePicker1_fromDate;
        private DateTimePicker dateTimePicker2_toDate;
        private Label label1_ticker;
        private Label label2_fromDate;
        private Label label3_toDate;
        private OpenFileDialog openFileDialog1;
    }
}