using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ayca_Kahraman
{
    public partial class Form1 : Form
    {
        public Form3 frm3;
        public Form2 frm2;
        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
            frm2.frm1 = this;
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
                    frm2.ShowDialog();
                    
                    
                
            }
            else
                MessageBox.Show("Girmiş olduğunuz Kullanıcı Adı / Şifre yanlıştır. Lütfen tekrar deneyiniz.", "Hata");
            
            
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
