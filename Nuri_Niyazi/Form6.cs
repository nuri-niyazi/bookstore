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
    public partial class Form6 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6()
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
                frm4.bag.Open();
                frm4.kmt.Connection = frm4.bag;
                frm4.kmt.CommandText = "UPDATE üyebil SET Üye_Adi='" + textBox1.Text + "',Üy_Soydi='" + textBox2.Text + "',Nosu='" + textBox3.Text + "',Sinifi='" + comboBox1.Text + "',Tc_Kimlik='" + textBox4.Text + "',Telefonu='" + textBox5.Text + "',E_Posta='" + textBox6.Text + "',Adresi='" + textBox7.Text + "',Sehir='" + textBox8.Text + "' WHERE Üye_Adi='" + frm4.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                frm4.kmt.ExecuteNonQuery();
                frm4.kmt.Dispose();
                frm4.bag.Close();
                frm4.dtst.Tables["üyebil"].Clear();
                frm4.göster();
                this.Close();
            }
            catch
            {
                ;
            }
        }
    }
}
