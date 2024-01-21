using System.Data.SqlClient;

namespace HotelReservation2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;
            button1.Parent = pictureBox1;
        }
        SqlConnection connect = new SqlConnection(DBSQL.conString);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int price = 30;
            int day = Convert.ToInt32(textBox2.Text);
            int total = price * day;
            label5.Text = $"Price: {total.ToString()}$";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int price = 30;
            int day = Convert.ToInt32(textBox2.Text);
            int total = price * day;

            connect.Open();
            string script = @"INSERT INTO Client(Name, Surname, Phone, Person, Day, Date, Floor, Room, CardNo, Price, Status)
                                                VALUES(@name, @surname,@phone, @person, @day, @date, @floor, @room, @cardno, @price, @status)";
            SqlCommand command = new SqlCommand(script, connect);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@surname", textBox5.Text);
            command.Parameters.AddWithValue("@phone", textBox4.Text);
            command.Parameters.AddWithValue("@person", textBox3.Text.ToString());
            command.Parameters.AddWithValue("@day", textBox2.Text);
            command.Parameters.AddWithValue("@date", dateTimePicker1.Text);
            command.Parameters.AddWithValue("@floor", comboBox1.Text);
            command.Parameters.AddWithValue("@room", comboBox2.Text);
            command.Parameters.AddWithValue("@cardno", textBox7.Text);
            command.Parameters.AddWithValue("@price", total.ToString());
            command.Parameters.AddWithValue("@status", textBox6.Text);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Reserved Succesfully");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
