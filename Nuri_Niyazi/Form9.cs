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
    public partial class Form9 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form7 frm7;
        public Form11 frm11;

        public Form9()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm7.bag.Open();
                frm7.kmt.Connection = frm7.bag;
                frm7.kmt.CommandText = "UPDATE kitapbil SET Barkod_No='" + textBox1.Text + "',Kitap_Adi='" + textBox2.Text + "',Demirbas='" + textBox3.Text + "',Yayinevi='" + textBox4.Text + "',Yazara='" + textBox5.Text + "',Yazarb='" + textBox6.Text + "',Yazarc='" + textBox7.Text + "',Stok_Sayisi='" + textBox8.Text + "',Basim_Tarihi='" + textBox9.Text + "',Sayfa_Say='" + textBox10.Text + "',Cilt='" + textBox11.Text + "',Baskisi='" + textBox12.Text + "',Sbn_Num='" + textBox13.Text + "',Fiyati='" + textBox14.Text + "',Anahtar_Söz='" + textBox15.Text + "' WHERE Barkod_No='" + frm7.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                frm7.kmt.ExecuteNonQuery();
                frm7.kmt.Dispose();
                frm7.bag.Close();
                frm7.dtst.Tables["kitapbil"].Clear();
                frm7.göster1();
                this.Close();
            }
            catch
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
