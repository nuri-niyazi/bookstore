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
    public partial class Form12 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form7 frm7;
        public Form8 frm8;
        public Form9 frm9;
        public Form10 frm10;
        public Form11 frm11;
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm10.bag.Open();
                frm10.kmt.Connection = frm10.bag;
                frm10.kmt.CommandText = "UPDATE okuyucubil SET Tc_No='" + textBox1.Text + "',Adi_Syd='" + textBox2.Text + "',Snf='" + comboBox1.Text + "',Okulno='" + textBox3.Text + "',Dogm_Yeri='" + comboBox2.Text + "',Dogm_Trh='" + textBox4.Text + "',Cnsyt='" + textBox5.Text + "',Adres='" + textBox6.Text + "',Ev_Tel='" + textBox7.Text + "',Cep_Tel='" + textBox8.Text + "',E_Mail='" + textBox9.Text + "',Üyelik_Var='" + textBox10.Text + "',Üyelk_Tar='" + textBox11.Text + "' WHERE Üye_Adi='" + frm10.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                frm10.kmt.ExecuteNonQuery();
                frm10.kmt.Dispose();
                frm10.bag.Close();
                frm10.dtst.Tables["okuyucubil"].Clear();
                frm10.göster2();
                this.Close();
            }
            catch
            {
                ;
            }
        }
    }
}
