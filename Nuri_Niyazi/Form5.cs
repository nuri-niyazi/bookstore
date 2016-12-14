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
    public partial class Form5 : Form
    {
        
        public Form3 frm3;
        public Form4 frm4;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            frm4.combo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox4.Text != "" )   
            {
                frm4.bag.Open();   
                frm4.kmt.Connection = frm4.bag;
                frm4.kmt.CommandText = "INSERT INTO üyebil(Üye_Adi,Üy_Soydi,Nosu,Sinifi,Tc_Kimlik,Telefonu,E_Posta,Adresi,Sehir) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "') ";   
                frm4.kmt.ExecuteNonQuery();   
                frm4.kmt.Dispose();   
                frm4.bag.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
  
  
                for (int i = 0; i < this.Controls.Count; i++)   
                {   
                    if (this.Controls[i] is TextBox) this.Controls[i].Text = "";   
                    if (this.Controls[i] is ComboBox) this.Controls[i].Text = "";   
                }   
                frm4.dtst.Tables["üyebil"].Clear();
                frm4.göster();   
                frm4.combo();   
                MessageBox.Show("Kayıt işlemi tamamlandı !");   
                   
            }   

           
        }   
        }
    }

