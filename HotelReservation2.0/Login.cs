using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            pictureBox1.Parent = pictureBox4;
            pictureBox2.Parent = pictureBox4;
            pictureBox3.Parent = pictureBox4;
            label1.Parent = pictureBox4;
            label2.Parent = pictureBox4;
            button1.Parent = pictureBox4;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Xeyyam" & textBox2.Text == "1234")
            {
                Admin a = new Admin();
                a.Show();
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
         }
    }
}
