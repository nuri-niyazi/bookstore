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
    public partial class Form8 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form7 frm7;
        public Form9 frm9;
        public Form10 frm10;
        public Form12 frm12;
        public Form8()
        {
            InitializeComponent();
            
          
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            frm7.combo1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label19.Text = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label19.Text = textBox2.Text;
            if (textBox2.Text != "")
            {
                frm7.bag.Open();
                frm7.kmt.Connection = frm7.bag;
                frm7.kmt.CommandText = "INSERT INTO kitapbil(Barkod_No,Kitap_Adi,Demirbas,Dolap_Ab,Yayinevi,Yazara,Yazarb,Yazarc,Stok_Sayisi,Kategorisi,Basim_Tarihi,Sayfa_Say,Cilt,Baskisi,Sbn_Num,Fiyati,Anahtar_Söz) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox2.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "') ";
                frm7.kmt.ExecuteNonQuery();
                frm7.kmt.Dispose();
                frm7.bag.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
                textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear();
                textBox11.Clear(); textBox12.Clear(); textBox13.Clear(); textBox14.Clear(); textBox15.Clear();

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    if (this.Controls[i] is ComboBox) this.Controls[i].Text = "";
                }
                frm7.dtst.Tables["kitapbil"].Clear();
                frm7.göster1();
                frm7.combo1();
                MessageBox.Show("Kayıt işlemi tamamlandı !");

              

                
            }   
        }
    }
}
