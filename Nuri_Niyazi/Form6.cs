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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm4.bag.Open();
                frm4.kmt.Connection = frm4.bag;
                frm4.kmt.CommandText = "UPDATE Books SET Title='" + textBox1.Text + "',Author='" + textBox2.Text + "',Category='" + textBox3.Text + "',ISBN='" + textBox4.Text + "',Pages='" + textBox5.Text + "',ShelfNumber='" + textBox6.Text + "',DatePurchased='" + dateTimePicker7.Value.ToShortDateString() + "',Price='" + textBox8.Text + "',Availability=" + Convert.ToInt32(checkBox9.Checked) + " WHERE BookID=" + frm4.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                frm4.kmt.ExecuteNonQuery();
                frm4.kmt.Dispose();
                frm4.bag.Close();
                frm4.dtst.Tables["Books"].Clear();
                frm4.view();
                this.Close();
            }
            catch
            {
                ;
            }
        }
    }
}
