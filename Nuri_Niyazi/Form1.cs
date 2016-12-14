using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nuri_Niyazi
{
    public partial class Form1 : Form
    {
        public Form3 frm3;

        public Form1()
        {
            InitializeComponent();
            frm3 = new Form3();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "admin")

                    
                    this.Visible = false;
                    frm3.ShowDialog();
                    
                    
                
            }
            else
                MessageBox.Show("Грешно потребителско име или парола", "Грешка");
            
            
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
