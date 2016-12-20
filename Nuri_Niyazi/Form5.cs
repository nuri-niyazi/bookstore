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
            if (textBox1.Text != "")
            {
                frm4.bag.Open();
                frm4.kmt.Connection = frm4.bag;

                frm4.kmt.CommandText = "INSERT INTO Books(Title,Author,Category,ISBN,Pages,ShelfNumber,DatePurchased,Price, Availability) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker7.Value.ToShortDateString() + "','" + textBox8.Text + "','" + Convert.ToInt32(checkBox9.Checked) + "') ";
                frm4.kmt.ExecuteNonQuery();
                frm4.kmt.Dispose();
                frm4.bag.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); dateTimePicker7.Text="";
                textBox6.Clear(); textBox6.Clear(); textBox8.Clear(); textBox4.Clear();


                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
    
                }
                frm4.dtst.Tables["Books"].Clear();
                frm4.view();
                frm4.combo();
                MessageBox.Show("Книгата е добавена успешно !");

            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

