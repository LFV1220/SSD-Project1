using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace project1
{
    public partial class Form1 : Form
    {
        private string timePeriod = "Day";
        DataGridView dataGridView1 = new DataGridView();
        string file;

        public Form1()
        {
            InitializeComponent();
            this.loadTickers();
        }

        // Function to load unique ticker symbols into the combobox
        private void loadTickers()
        {
            // Get all .csv files from the Stock Data Folder
            string[] csvFiles = Directory.GetFiles(getFolderPath(), "*.csv");

            // To store unique ticker names
            HashSet<string> uniqueTickers = new HashSet<string>();

            // Iterate through the files to get ticker names
            foreach (string csvFile in csvFiles)
            {
                string[] fileNameParts = Path.GetFileNameWithoutExtension(csvFile).Split('-');

                if (fileNameParts.Length >= 1)
                {
                    string tickerName = fileNameParts[0];
                    uniqueTickers.Add(tickerName);
                }
            }

            comboBox1_ticker.Items.Clear();
            comboBox1_ticker.Items.AddRange(uniqueTickers.ToArray());
        }

        // Function to change to the first layout/starting page 
        private void firstLayout(bool status)
        {
            comboBox1_ticker.Visible = status;
            radioButton1.Visible = status;
            radioButton2.Visible = status;
            radioButton3.Visible = status;
            button1_viewTicker.Visible = status;
            button2_openFile.Visible = status;
            label1_ticker.Visible = status;
            label2_fromDate.Visible = status;
            label3_toDate.Visible = status;
            dateTimePicker1_fromDate.Visible = status;
            dateTimePicker2_toDate.Visible = status;
        }

        // Function to change to the second layout/starting page
        private void secondLayout(bool status)
        {
            button3_reset.Visible = status;
            dataGridView1.Visible = status;
            chart1_stockData.Visible = status;
            chart2_volume.Visible = status;
        }

        // Function to set the time period
        private void radioButton_CheckedChanged_setPeriod(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                timePeriod = "Day";
            }
            else if (radioButton2.Checked)
            {
                timePeriod = "Week";
            }
            else if (radioButton3.Checked)
            {
                timePeriod = "Month";
            }
        }

        // Function to get the relative path of the Stock Data folder
        private string getFolderPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Directory.GetParent(currentDirectory).FullName;
            string parentDirectory1 = Directory.GetParent(parentDirectory).FullName;
            string parentDirectory2 = Directory.GetParent(parentDirectory1).FullName;
            string parentDirectory3 = Directory.GetParent(parentDirectory2).FullName;
            string parentDirectory4 = Directory.GetParent(parentDirectory3).FullName;
            string stockDataPath = Path.Combine(parentDirectory4, "Stock Data");
            return stockDataPath;
        }

        // Function to view ticker information when button is clicked  
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a ticker is selected
            if (comboBox1_ticker.SelectedIndex == -1)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a ticker symbol.", "No Ticker Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make sure there is a valid date range
            if (dateTimePicker2_toDate.Value < dateTimePicker1_fromDate.Value)
            {
                // Error, invalid date range
                MessageBox.Show("Please make sure the \"from\" date is before the \"to\" date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Look for file matching ticker symbol and date period and open it
            string fileName = comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod + ".csv";
            string stockDataPath = getFolderPath();
            string filePath = Path.Combine(stockDataPath, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                MessageBox.Show("File not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BindingList<candlestick> candlesticks = readData(filePath);

            // Change layouts
            firstLayout(false);
            secondLayout(true);

            // Show the stock data
            displayData(candlesticks);

            // Add the DataGridView to the form
            this.Controls.Add(dataGridView1);
        }

        // Function to use and open a CSV file for stock data
        private void openFile(object sender, EventArgs e)
        {
            // OpenFileDialog
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                file = filePath;
                BindingList<candlestick> candlesticks = readData(filePath);

                // Change layouts
                firstLayout(false);
                secondLayout(true);

                // Show the stock data
                displayData(candlesticks);

                // Add the DataGridView to the form
                this.Controls.Add(dataGridView1);
            }
            else
            {
                // Error opening selected file
                MessageBox.Show("Unable to open selected file. Please try again.", "Unable to open selected file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Function to read data from .csv file
        private BindingList<candlestick> readData(string filePath)
        {
            BindingList<candlestick> candlesticks = new BindingList<candlestick>();
            string referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line != referenceString)
                    {
                        // Pass the data to create a candlestick object
                        candlestick cs = new candlestick(line);
                        DateTime csDate = DateTime.Parse(cs.date);

                        // Check if the date is in the range
                        if (csDate >= dateTimePicker1_fromDate.Value && csDate <= dateTimePicker2_toDate.Value)
                        {
                            candlesticks.Add(cs);
                        }
                    }
                }
            }
            return candlesticks;
        }

        // Function to display the stock data as a datagridview, stock price chart, and volume chart
        private void displayData(BindingList<candlestick> candlesticks)
        {
            // Setting up and displaying stock data on DataGridView
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = candlesticks;

            chart1_stockData.Series.Clear();
            chart2_volume.Series.Clear();

            Series candlestickSeries = new Series("Candlestick")
            {
                ChartType = SeriesChartType.Candlestick, // Use Candlestick chart type
                XValueType = ChartValueType.Date,
            };

            Series volumeSeries = new Series("Volume")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Date,
            };

            List<double> yValues = new List<double>();
            List<double> volumeValues = new List<double>();

            foreach (var cs in candlesticks)
            {
                DataPoint dataPoint = new DataPoint
                {
                    XValue = DateTime.Parse(cs.date).ToOADate(),
                    YValues = new double[] { (double)cs.open, (double)cs.high, (double)cs.low, (double)cs.close }
                };

                // Candlestick size based on price difference
                double priceDifference = Math.Abs((double)cs.close - (double)cs.open);
                dataPoint.SetCustomProperty("PriceDifference", priceDifference.ToString());

                // Set the color based on open and close values
                if (cs.open < cs.close)
                {
                    dataPoint.Color = Color.Green;
                }
                else
                {
                    dataPoint.Color = Color.Red;
                }

                candlestickSeries.Points.Add(dataPoint);
                volumeValues.Add((double)cs.volume);

                yValues.Add((double)cs.open);
                yValues.Add((double)cs.high);
                yValues.Add((double)cs.low);
                yValues.Add((double)cs.close);
            }

            // For the volume chart
            for (int i = 0; i < candlesticks.Count; i++)
            {
                DataPoint dataPoint = new DataPoint
                {
                    XValue = DateTime.Parse(candlesticks[i].date).ToOADate(),
                    YValues = new double[] { (double)candlesticks[i].volume }
                };
                volumeSeries.Points.Add(dataPoint);
            }

            chart1_stockData.Series.Add(candlestickSeries);
            chart2_volume.Series.Add(volumeSeries);

            chart1_stockData.ChartAreas[0].AxisY.Minimum = yValues.Min();
            chart1_stockData.ChartAreas[0].AxisY.Maximum = yValues.Max();
            chart1_stockData.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            chart2_volume.ChartAreas[0].AxisY.Minimum = volumeValues.Min();
            chart2_volume.ChartAreas[0].AxisY.Maximum = volumeValues.Max();
            chart2_volume.ChartAreas[0].AxisY.LabelStyle.Format = "F0";

            // Setting up the title and labels
            string tickerName = comboBox1_ticker.SelectedIndex != -1
                ? comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod
                : Path.GetFileNameWithoutExtension(file);

            chart1_stockData.Titles.Clear();
            chart1_stockData.Titles.Add(new Title(tickerName));
            chart2_volume.Titles.Clear();
            chart2_volume.Titles.Add(new Title(tickerName + " - Volume Chart"));
            chart1_stockData.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";
            chart2_volume.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";
        }


        // Function to go back to the first page/layout when the reset button is clicked
        private void button3_Click_reset(object sender, EventArgs e)
        {
            secondLayout(false);
            firstLayout(true);
        }

    }
}