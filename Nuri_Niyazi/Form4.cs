using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nuri_Niyazi
{
    public partial class Form4 : Form
    {
        public Form6 frm6;
        public Form5 frm5;
        public Form3 frm3;
        public Form4()
        {
            InitializeComponent();
            
            frm5 = new Form5();
            frm6 = new Form6();
          
            frm5.frm4 = this;
            frm6.frm4 = this;
            
            
        }



        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");   
        public OleDbCommand kmt = new OleDbCommand();   
        public OleDbDataAdapter adtr = new OleDbDataAdapter();   
        public DataSet dtst = new DataSet();
        
        public int row = 0;
           
        

        public void göster()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From üyebil", bag);
            adtr.Fill(dtst, "üyebil");
            dataGridView1.DataSource = dtst.Tables["üyebil"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo()   
        {   
            int durum;   
            bag.Open();   
            kmt.Connection = bag;   
            kmt.CommandText = "Select Sinifi from üyebil";   
            OleDbDataReader oku;   
            oku = kmt.ExecuteReader();   
            while (oku.Read())   
            {   
                durum = frm5.comboBox1.FindString(oku[0].ToString());   
                if (durum == -1) frm5.comboBox1.Items.Add(oku[0].ToString());   
             }   
            bag.Close();   
            oku.Dispose();   
        }   

        private void Form4_Load(object sender, EventArgs e)
        {
            göster();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "Üye Adı";
            dataGridView1.Columns[1].HeaderText = "Üye Soyadı";
            dataGridView1.Columns[2].HeaderText = "Kişi/Öğrenci No";
            dataGridView1.Columns[3].HeaderText = "Sınıfı";
            dataGridView1.Columns[4].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[6].HeaderText = "E-Posta";
            dataGridView1.Columns[7].HeaderText = "Adres";
            dataGridView1.Columns[8].HeaderText = "Şehir";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["üyebil"].Clear();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silinecek;
            try
            {
                int row = 0;
                for (row = 0; row <= dataGridView1.Rows.Count; row++)
                {
                    
                    if (dataGridView1.Rows[row].Cells[0].Selected == true || dataGridView1.Rows[row].Cells[1].Selected == true || dataGridView1.Rows[row].Cells[2].Selected == true || dataGridView1.Rows[row].Cells[3].Selected == true || dataGridView1.Rows[row].Cells[4].Selected == true || dataGridView1.Rows[row].Cells[5].Selected == true || dataGridView1.Rows[row].Cells[6].Selected == true || dataGridView1.Rows[row].Cells[7].Selected == true || dataGridView1.Rows[row].Cells[8].Selected == true)
                    {
                        break;

                    }
                }
                silinecek = dataGridView1.Rows[row].Cells[0].Value.ToString();

                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from üyebil WHERE Üye_Adi='" + silinecek + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["üyebil"].Clear();
                    göster();
                }
            }
            catch
            { ;}
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            frm6.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From üyebil", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from üyebil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "üyebil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From üyebil" +
                 " where(Üye_Adi like '%" + textBox1.Text + "%' )";
            dtst.Tables["üyebil"].Clear();
            adtr.Fill(dtst, "üyebil");
            bag.Close();     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From üyebil", bag);
            if (textBox2.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from üyebil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "üyebil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From üyebil" +
                 " where(Tc_Kimlik like '%" + textBox2.Text + "%' )";
            dtst.Tables["üyebil"].Clear();
            adtr.Fill(dtst, "üyebil");
            bag.Close();     
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frm6.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm6.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm6.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm6.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm6.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm6.textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm6.textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm6.textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
