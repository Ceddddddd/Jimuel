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
    public partial class Form2 : Form
    {
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Jimuel;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
            d1();
        }
        private void d1()
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
                    dataGridView1.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 335; // Set the width to 150 pixels, for example
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
            int guestid = int.Parse(textBox1.Text);
            string gender = textBox2.Text;
            string name = textBox3.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "INSERT INTO Inviters_table (InvitersID, gender, Name) VALUES (@GuestID, @Gender, @Name)";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@GuestID", guestid);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Name", name);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Fill the textboxes with the values from the selected row
                textBox1.Text = row.Cells["InvitersID"].Value.ToString();
                textBox2.Text = row.Cells["gender"].Value.ToString();
                textBox3.Text = row.Cells["Name"].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int guestid = int.Parse(textBox1.Text);
            string gender = textBox2.Text;
            string name = textBox3.Text;

            // Assuming you have a SqlConnection object named "connection"
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "UPDATE Inviters_table SET gender = @Gender, Name = @Name WHERE InvitersID = @GuestID";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@GuestID", guestid);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Name", name);

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

        private void button7_Click(object sender, EventArgs e)
        {
            int guestid = int.Parse(textBox1.Text);

            // Assuming you have a SqlConnection object named "connection"
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query with parameters
                string query = "DELETE FROM Inviters_table WHERE InvitersID = @GuestID";

                // Create and open a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@GuestID", guestid);

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

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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

        }

        private void button5_Click(object sender, EventArgs e)
        {
            logbook logbook = new logbook();
            logbook.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }
    }
    
}
