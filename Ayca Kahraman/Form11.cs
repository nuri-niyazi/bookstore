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
    public partial class Form11 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form9 frm9;
        public Form10 frm10;
        public Form7 frm7;
        public Form12 frm12;
        public Form11()
        {
            InitializeComponent();
          
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            frm10.combo2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                frm10.bag.Open();
                frm10.kmt.Connection = frm10.bag;
                frm10.kmt.CommandText = "INSERT INTO okuyucubil(Tc_No,Adi_Syd,Snf,Okulno,Dogm_Yeri,Dogm_Trh,Cnsyt,Adres,Ev_Tel,Cep_Tel,E_Mail,Üyelik_Var,Üyelk_Tar) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "') ";
                frm10.kmt.ExecuteNonQuery();
                frm10.kmt.Dispose();
                frm10.bag.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
                textBox9.Clear(); textBox10.Clear(); textBox11.Clear();

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    if (this.Controls[i] is ComboBox) this.Controls[i].Text = "";
                }
                frm10.dtst.Tables["okuyucubil"].Clear();
                frm10.göster2();
                frm10.combo2();
                MessageBox.Show("Kayıt işlemi tamamlandı !");

            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
