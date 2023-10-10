using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace project1
{
    public partial class Form1 : Form
    {
        private string folderPath = @"C:\Users\Frankie\Desktop\Fall 2023\COP4365\Stock Data";
        private string timePeriod = "Day";
        SplitContainer splitContainer1 = new SplitContainer();
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
            string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");

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
            string filePath = Path.Combine(folderPath, fileName);

            // Using relative path instead of absolute
            string currentDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Directory.GetParent(currentDirectory).FullName;
            string parentDirectory1 = Directory.GetParent(parentDirectory).FullName;
            string parentDirectory2 = Directory.GetParent(parentDirectory1).FullName;
            string parentDirectory3 = Directory.GetParent(parentDirectory2).FullName;
            string parentDirectory4 = Directory.GetParent(parentDirectory3).FullName;
            string stockDataPath = Path.Combine(parentDirectory4, "Stock Data");
            string filePath1 = Path.Combine(stockDataPath, fileName);
            Debug.Write("filePath1: " + filePath1);
            Debug.WriteLine("");

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

            // Also add a reset button to go back once there is stock data
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
            //splitContainer1.Dock = DockStyle.Fill; // Dock the split container to fill the form
            //this.Controls.Add(splitContainer1); // Add the split container to the form

            // why the fuck is the fucking piece of shit fucking stupid fucking software so fucking shit fuck this fuck you visual studio fuck off
            //Chart chart1 = new Chart();
            //chart1.Dock = DockStyle.Fill; // Dock the chart to fill the left panel
            //splitContainer1.Panel1.Controls.Add(chart1); // Add the chart to the left panel of the split container

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoGenerateColumns = true; // make the columns eventually
            dataGridView1.DataSource = candlesticks;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secondLayout(false);
            firstLayout(true);
        }
    }
}