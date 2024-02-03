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
    public partial class logbook : Form
    {
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Jimuel;Integrated Security=True";
        public logbook()
        {
            InitializeComponent();
            d1();
            d2();
            d3();
            d4();
        }
        private void d1()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select the desired data
                    string query = @"
                        select * from Guests_table";

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
                        column.Width = 120; // Set the width to 150 pixels, for example
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        private void d2()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select the desired data
                    string query = @"
                        select * from Inviters_table";

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
                    dataGridView2.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        column.Width = 116; // Set the width to 150 pixels, for example
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        private void d3()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select the desired data
                    string query = @"
                        select * from Events_table";

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
                    dataGridView3.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView3.Columns)
                    {
                        column.Width = 100; // Set the width to 150 pixels, for example
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        private void d4()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL query to select the desired data
                    string query = @"
                        select * from Logbook";

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
                    dataGridView4.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView4.Columns)
                    {
                        column.Width = 100; // Set the width to 150 pixels, for example
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int logbookId = int.Parse(textBox1.Text);
            int eventid = int.Parse(textBox2.Text);
            int guestid = int.Parse(textBox3.Text);
            int invitersid = int.Parse(textBox4.Text);
            DateTime dateTime = DateTime.Now;

            // Assuming you have a SqlConnection object named "connection"
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "INSERT INTO Logbook (LogbookID, Timein, EventID, GuestID, InvitersID) VALUES (@LogbookID, @Timein, @EventID, @GuestID, @InvitersID)";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@LogbookID", logbookId);
                    command.Parameters.AddWithValue("@Timein", dateTime);
                    command.Parameters.AddWithValue("@EventID", eventid);
                    command.Parameters.AddWithValue("@GuestID", guestid);
                    command.Parameters.AddWithValue("@InvitersID", invitersid);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if rows were affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.");
                            d1();
                            d2();
                            d3();
                            d4();
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int logbookId = int.Parse(textBox1.Text);
            int eventid = int.Parse(textBox2.Text);
            int guestid = int.Parse(textBox3.Text);
            int invitersid = int.Parse(textBox4.Text);
            DateTime dateTime = DateTime.Now;

            // Assuming you have a SqlConnection object named "connection"
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "UPDATE Logbook SET Timein = @Timein, EventID = @EventID, GuestID = @GuestID, InvitersID = @InvitersID WHERE LogbookID = @LogbookID";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@LogbookID", logbookId);
                    command.Parameters.AddWithValue("@Timein", dateTime);
                    command.Parameters.AddWithValue("@EventID", eventid);
                    command.Parameters.AddWithValue("@GuestID", guestid);
                    command.Parameters.AddWithValue("@InvitersID", invitersid);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if rows were affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                            d1();
                            d2();
                            d3();
                            d4();
                        }
                        else
                        {
                            MessageBox.Show("No rows updated.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int logbookId = int.Parse(textBox1.Text);

            // Assuming you have a SqlConnection object named "connection"
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "DELETE FROM Logbook WHERE LogbookID = @LogbookID";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@LogbookID", logbookId);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if rows were affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data deleted successfully.");
                            d1();
                            d2();
                            d3();
                            d4();
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                // Fill the textboxes with the values from the selected row
                textBox1.Text = row.Cells["LogbookID"].Value.ToString();
                textBox2.Text = row.Cells["EventID"].Value.ToString();
                textBox3.Text = row.Cells["GuestID"].Value.ToString();
                textBox4.Text = row.Cells["InvitersID"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            guest guest = new guest();
            guest.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }
    }
}

