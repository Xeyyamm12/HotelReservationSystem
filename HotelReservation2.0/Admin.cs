using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;


namespace HotelReservation2._0
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                Delete(id);
            }
        }
        // delete function for delete button
        public void Delete(int id)
        {
            connect.Open();
            string script = "DELETE FROM Client WHERE ID = @id";
            SqlCommand command = new SqlCommand(script, connect);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Succesfully deleted!");
            Refresh();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //search bar
            connect.Open();
            string script = "SELECT*FROM Client WHERE Name = @name";
            SqlCommand command = new SqlCommand(script, connect);
            command.Parameters.AddWithValue("@name", textBox1.Text.ToLower());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
        private void Admin_Load(object sender, EventArgs e)
        {

        }
        SqlConnection connect = new SqlConnection(DBSQL.conString);
        //Show all
        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            string script = "SELECT*FROM Client";
            SqlCommand command = new SqlCommand(script, connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }
        int i = 0;
        //Refresh function
        public void Refresh()
        {
            connect.Open();
            string script = "SELECT*FROM Client";
            SqlCommand command = new SqlCommand(script, connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
        //Modify
            connect.Open();
            string script = @"UPDATE Client SET Status=@status
                                WHERE ID=@id";
            SqlCommand command = new SqlCommand(script, connect);
            command.Parameters.AddWithValue("id", dataGridView1.Rows[i].Cells[0].Value);
            command.Parameters.AddWithValue("@status", comboBox1.Text);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Modified!");
            Refresh();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            comboBox1.Text = dataGridView1.Rows[i].Cells[11].Value.ToString(); 
        }
    }
}
