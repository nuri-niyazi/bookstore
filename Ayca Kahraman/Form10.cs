using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ayca_Kahraman
{
    public partial class Form10 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form9 frm9;
        public Form7 frm7;
        public Form11 frm11;
        public Form12 frm12;
        public Form10()
        {
            InitializeComponent();

            frm11 = new Form11();
            frm12 = new Form12();

            frm11.frm10 = this;
            frm12.frm10 = this;
        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
   
        public int row = 0;

        public void göster2()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From okuyucubil", bag);
            adtr.Fill(dtst, "okuyucubil");
            dataGridView1.DataSource = dtst.Tables["okuyucubil"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo2()
        {
            int durum;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Snf,Dogm_Yeri from okuyucubil";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                durum = frm11.comboBox1.FindString(oku[0].ToString());
                if (durum == -1) frm11.comboBox1.Items.Add(oku[0].ToString());
                durum = frm11.comboBox2.FindString(oku[1].ToString());
                if (durum == -1) frm11.comboBox2.Items.Add(oku[1].ToString());
            }
            bag.Close();
            oku.Dispose();
        }   

        private void Form10_Load(object sender, EventArgs e)
        {
            göster2();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Sınıfı";
            dataGridView1.Columns[3].HeaderText = "Okul No";
            dataGridView1.Columns[4].HeaderText = "Doğum Yeri";
            dataGridView1.Columns[5].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[6].HeaderText = "Cinsiyet";
            dataGridView1.Columns[7].HeaderText = "Adres";
            dataGridView1.Columns[8].HeaderText = "Ev Telefonu";
            dataGridView1.Columns[9].HeaderText = "Cep Telefonu";
            dataGridView1.Columns[10].HeaderText = "E-Mail";
            dataGridView1.Columns[11].HeaderText = "Üyeliğiniz Varmı?";
            dataGridView1.Columns[12].HeaderText = "Üyelik Başlangış Tarihiniz";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["okuyucubil"].Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            frm12.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silinecek;
            try
            {
                int row = 0;
                for (row = 0; row <= dataGridView1.Rows.Count; row++)
                {

                    if (dataGridView1.Rows[row].Cells[0].Selected == true || dataGridView1.Rows[row].Cells[1].Selected == true || dataGridView1.Rows[row].Cells[2].Selected == true || dataGridView1.Rows[row].Cells[3].Selected == true || dataGridView1.Rows[row].Cells[4].Selected == true || dataGridView1.Rows[row].Cells[5].Selected == true || dataGridView1.Rows[row].Cells[6].Selected == true || dataGridView1.Rows[row].Cells[7].Selected == true || dataGridView1.Rows[row].Cells[8].Selected == true || dataGridView1.Rows[row].Cells[9].Selected == true || dataGridView1.Rows[row].Cells[10].Selected == true || dataGridView1.Rows[row].Cells[11].Selected == true || dataGridView1.Rows[row].Cells[12].Selected == true)
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
                    kmt.CommandText = "DELETE from okuyucubil WHERE Tc_No='" + silinecek + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["okuyucubil"].Clear();
                    göster2();
                }
            }
            catch
            { ;}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm11.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From okuyucubil", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from okuyucubil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "okuyucubil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From okuyucubil" +
                 " where(Adi_Syd like '%" + textBox1.Text + "%' )";
            dtst.Tables["okuyucubil"].Clear();
            adtr.Fill(dtst, "okuyucubil");
            bag.Close();     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From okuyucubil", bag);
            if (textBox2.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from okuyucubil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "okuyucubil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From okuyucubil" +
                 " where(Dogm_Yeri like '%" + textBox2.Text + "%' )";
            dtst.Tables["okuyucubil"].Clear();
            adtr.Fill(dtst, "okuyucubil");
            bag.Close();     
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frm12.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm12.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm12.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm12.textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm12.textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm12.textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm12.textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frm12.textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            frm12.textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            frm12.textBox10.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            frm12.textBox11.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }
    }
}
