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
    public partial class Form7 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form9 frm9;
        public Form10 frm10;
        public Form11 frm11;
        public Form12 frm12;
        public Form7()
        {
            InitializeComponent();
            
            frm8 = new Form8();
            frm9 = new Form9();
            
            frm8.frm7 = this;
            frm9.frm7 = this;
          
        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
       
        public int row = 0;

        public void göster1()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kitapbil", bag);
            adtr.Fill(dtst, "kitapbil");
            dataGridView1.DataSource = dtst.Tables["kitapbil"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo1()
        {
            int durum;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Dolap_Ab,Kategorisi from kitapbil";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                durum = frm8.comboBox1.FindString(oku[0].ToString());
                if (durum == -1) frm8.comboBox1.Items.Add(oku[0].ToString());
                durum = frm8.comboBox2.FindString(oku[1].ToString());
                if (durum == -1) frm8.comboBox2.Items.Add(oku[1].ToString());
            }
            bag.Close();
            oku.Dispose();
        }   

        private void Form7_Load(object sender, EventArgs e)
        {
            göster1();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "Barkod No";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Demirbaş No";
            dataGridView1.Columns[3].HeaderText = "Dolap Adı";
            dataGridView1.Columns[4].HeaderText = "Yayın Evi";
            dataGridView1.Columns[5].HeaderText = "Yazar1";
            dataGridView1.Columns[6].HeaderText = "Yazar2";
            dataGridView1.Columns[7].HeaderText = "Yazar3";
            dataGridView1.Columns[8].HeaderText = "Stok Sayısı";
            dataGridView1.Columns[9].HeaderText = "Kategorisi";
            dataGridView1.Columns[10].HeaderText = "Basım Tarihi";
            dataGridView1.Columns[11].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[12].HeaderText = "Cilt No";
            dataGridView1.Columns[13].HeaderText = "Baskısı";
            dataGridView1.Columns[14].HeaderText = "ISBN Numarası";
            dataGridView1.Columns[15].HeaderText = "Fiyatı";
            dataGridView1.Columns[16].HeaderText = "Anahtar Sözcük";
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["kitapbil"].Clear();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm8.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            frm9.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silinecek;
            try
            {
                int row = 0;
                for (row = 0; row <= dataGridView1.Rows.Count; row++)
                {

                    if (dataGridView1.Rows[row].Cells[0].Selected == true || dataGridView1.Rows[row].Cells[1].Selected == true || dataGridView1.Rows[row].Cells[2].Selected == true || dataGridView1.Rows[row].Cells[3].Selected == true || dataGridView1.Rows[row].Cells[4].Selected == true || dataGridView1.Rows[row].Cells[5].Selected == true || dataGridView1.Rows[row].Cells[6].Selected == true || dataGridView1.Rows[row].Cells[7].Selected == true || dataGridView1.Rows[row].Cells[8].Selected == true || dataGridView1.Rows[row].Cells[9].Selected == true || dataGridView1.Rows[row].Cells[10].Selected == true || dataGridView1.Rows[row].Cells[11].Selected == true || dataGridView1.Rows[row].Cells[12].Selected == true || dataGridView1.Rows[row].Cells[13].Selected == true || dataGridView1.Rows[row].Cells[14].Selected == true || dataGridView1.Rows[row].Cells[15].Selected == true || dataGridView1.Rows[row].Cells[16].Selected == true)
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
                    kmt.CommandText = "DELETE from kitapbil WHERE Barkod_No ='" + silinecek + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["kitapbil"].Clear();
                    göster1();
                }
            }
            catch
            { ;}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kitapbil", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from kitapbil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "kitapbil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From kitapbil" +
                 " where(Barkod_No like '%" + textBox1.Text + "%' )";
            dtst.Tables["kitapbil"].Clear();
            adtr.Fill(dtst, "kitapbil");
            bag.Close();     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kitapbil", bag);
            if (textBox2.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from kitapbil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "kitapbil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From kitapbil" +
                 " where(Kitap_Adi like '%" + textBox2.Text + "%' )";
            dtst.Tables["kitapbil"].Clear();
            adtr.Fill(dtst, "kitapbil");
            bag.Close();     
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frm9.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm9.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm9.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm9.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm9.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm9.textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm9.textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm9.textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frm9.textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            frm9.textBox10.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            frm9.textBox11.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            frm9.textBox12.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            frm9.textBox13.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            frm9.textBox14.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            frm9.textBox15.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
        }
    }
}
