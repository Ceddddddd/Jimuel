using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jimuel
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Jimuel;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            d1();
            lbl1();
            lbl2();
            lbl3();
            lbl4();
            lbl5();
        }
        private void lbl5() {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to calculate the sum of guests and inviters
                    string query = @"
                       SELECT COUNT(*) AS Total_Males
FROM (
    SELECT gender FROM Guests_table WHERE gender = 'Female'
    UNION ALL
    SELECT gender FROM Inviters_table WHERE gender = 'Female'
) AS MaleCounts;";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int totalGuestsAndInviters = Convert.ToInt32(command.ExecuteScalar());

                    // Display the result in the label
                    l5.Text = totalGuestsAndInviters.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void lbl4() {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to calculate the sum of guests and inviters
                    string query = @"
                       SELECT COUNT(*) AS Total_Males
FROM (
    SELECT gender FROM Guests_table WHERE gender = 'Male'
    UNION ALL
    SELECT gender FROM Inviters_table WHERE gender = 'Male'
) AS MaleCounts;";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int totalGuestsAndInviters = Convert.ToInt32(command.ExecuteScalar());

                    // Display the result in the label
                    l4.Text = totalGuestsAndInviters.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void lbl3() {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to calculate the sum of guests and inviters
                    string query = @"
                        SELECT count(*) from Inviters_table";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int totalGuestsAndInviters = Convert.ToInt32(command.ExecuteScalar());

                    // Display the result in the label
                    l3.Text = totalGuestsAndInviters.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void lbl2() {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to calculate the sum of guests and inviters
                    string query = @"
                        SELECT count(*) from Guests_table";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int totalGuestsAndInviters = Convert.ToInt32(command.ExecuteScalar());

                    // Display the result in the label
                    l2.Text = totalGuestsAndInviters.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void lbl1()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to calculate the sum of guests and inviters
                    string query = @"
                        SELECT 
                            (SELECT COUNT(*) FROM Guests_table) + (SELECT COUNT(*) FROM Inviters_table) AS TotalGuestsAndInviters;";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int totalGuestsAndInviters = Convert.ToInt32(command.ExecuteScalar());

                    // Display the result in the label
                    l1.Text = totalGuestsAndInviters.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d1()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select the desired data
                    string query = @"
                        SELECT 
                            G.Name AS GuestName,
                            I.Name AS InviterName,
                            L.Timein,
                            E.Minister
                        FROM 
                            Logbook L
                        JOIN 
                            Guests_table G ON L.GuestID = G.GuestID
                        JOIN 
                            Events_table E ON L.EventID = E.EventID
                        JOIN 
                            Inviters_table I ON L.InvitersID = I.InvitersID;";

                    // Create a SqlCommand object to execute the query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Open the connection
                    connection.Open();

                    // Create a SqlDataAdapter to fetch the data
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Create a DataTable to store the fetched data
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the data from the database
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 163; // Set the width to 150 pixels, for example
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                   
             }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            guest guest = new guest();
            guest.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            logbook logbook = new logbook();
            logbook.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
