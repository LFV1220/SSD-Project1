using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace project1
{
    public partial class Form1 : Form
    {
        private string timePeriod = "Day";
        DataGridView dataGridView1 = new DataGridView();

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

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(uniqueTickers.ToArray());
        }

        // Function to change to the first layout/starting page 
        private void firstLayout(bool status)
        {
            comboBox1.Visible = status;
            radioButton1.Visible = status;
            radioButton2.Visible = status;
            radioButton3.Visible = status;
            button1.Visible = status;
            button2.Visible = status;
        }

        // Function to change to the second layout/starting page
        private void secondLayout(bool status)
        {
            button3.Visible = status;
            dataGridView1.Visible = status;
            chart1.Visible = status;
            chart2.Visible = status;
        }

        // Change this part into setters/getters
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
            if (comboBox1.SelectedIndex == -1)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a ticker symbol.", "No Ticker Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Look for file matching ticker symbol and date period and open it
            string fileName = comboBox1.SelectedItem.ToString() + "-" + timePeriod + ".csv";
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


            displayData(candlesticks);


            // Add the DataGridView to the form
            this.Controls.Add(dataGridView1);

        }

        // Function to use and open a CSV file for stock data
        private void openFile(object sender, EventArgs e)
        {
            // OpenFileDialog

            // Make form items invisible
            // Use Chart control and DataGridView (or something like that) to display stock information

            // Also add a reset button to go back once there is stock data
        }

        // Function to read data from file
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
                        candlestick cs = new candlestick(line);
                        string date = cs.date;
                        candlesticks.Add(cs);
                    }
                }
            }
            return candlesticks;
        }

        private void displayData(BindingList<candlestick> candlesticks)
        {
            // Setting up and displaying stock data on datagridview
            dataGridView1.Dock = DockStyle.Fill; // TODO: CHANGE SIZE EVENTUALLY
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = candlesticks;

            chart1.Series.Clear();
            chart2.Series.Clear();

            Series candlestickSeries = new Series("Candlestick")
            {
                ChartType = SeriesChartType.Stock,
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

                // Change candlestick based on the open and close values
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

            for (int i = 0; i < candlesticks.Count; i++)
            {
                DataPoint dataPoint = new DataPoint
                {
                    XValue = DateTime.Parse(candlesticks[i].date).ToOADate(),
                    YValues = new double[] { (double)candlesticks[i].volume }
                };
                volumeSeries.Points.Add(dataPoint);
            }

            chart1.Series.Add(candlestickSeries);
            chart2.Series.Add(volumeSeries);

            chart1.ChartAreas[0].AxisY.Minimum = yValues.Min();
            chart1.ChartAreas[0].AxisY.Maximum = yValues.Max();
            chart2.ChartAreas[0].AxisY.Minimum = volumeValues.Min();
            chart2.ChartAreas[0].AxisY.Maximum = volumeValues.Max();

            // Setting up the title and labels
            string tickerName = comboBox1.SelectedItem.ToString() + "-" + timePeriod;
            chart1.Titles.Clear();
            chart1.Titles.Add(new Title(tickerName));
            chart2.Titles.Clear();
            chart2.Titles.Add(new Title(tickerName + " - Volume Chart"));
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            secondLayout(false);
            firstLayout(true);
        }
    }
}