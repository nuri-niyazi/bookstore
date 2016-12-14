using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Ayca_Kahraman
{
    public partial class Form2 : Form
    {
        public Form3 frm3;
        public Form1 frm1;
       
        public Form2()
        {
            InitializeComponent();
            frm3 = new Form3();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = "Kütüphane Programına Hoşgeldiniz    ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            string path = "C:\\windows\\media\\ding.wav";
            player.SoundLocation = path;
            player.Play();
            Close();
            this.Visible = false;
            frm3.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
