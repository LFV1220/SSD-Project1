namespace project1
{
    public partial class Form1 : Form
    {
        private string timePeriod = "";

        public Form1()
        {
            InitializeComponent();
            this.loadTickers();
        }

        // Function to load unique ticker symbols into the combobox
        private void loadTickers()
        {
            // Get all .csv files from the Stock Data Folder
            string path = @"C:\Users\Frankie\Desktop\Fall 2023\COP4365\Stock Data";
            string[] csvFiles = Directory.GetFiles(path, "*.csv");

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

        // Function to check if Daily radio button is selected
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.timePeriod = "Daily";
        }

        // Function to check if Weekly radio button is selected
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.timePeriod = "Weekly";
        }

        // Function to check if Monthly radio button is selected
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.timePeriod = "Monthly";
        }

        // Function to view ticker information when button is clicked  
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a ticker is selected
            if(comboBox1.SelectedIndex == -1) {
                // Error, no ticker selected
                MessageBox.Show("Please select a ticker symbol.", "No Ticker Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Validate the date (calculate range based on time period)

            // Look for file matching ticker symbol and date period and open it
            // Loop through CSV file lines until correct date is found 

            // Make form items invisible
            // Use Chart control and DataGridView (or something like that) to display stock information

            // Also add a reset button to go back once there is stock data
        }

        // Function to use and open a CSV file for stock data
        private void openFile(object sender, EventArgs e)
        {
            // Get the time period
            // Validate the date (calculate range based on time period)

            // Loop through CSV file lines until correct date is found 

            // Make form items invisible
            // Use Chart control and DataGridView (or something like that) to display stock information

            // Also add a reset button to go back once there is stock data
        }

    }
}