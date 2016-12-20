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
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Authors", bag);
            adtr.Fill(dtst, "Authors");
            dataGridView1.DataSource = dtst.Tables["Authors"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo1()
        {
            int durum;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Dolap_Ab,Kategorisi from Authors";
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
            dataGridView1.Columns[0].HeaderText = "Номер на автор";
            dataGridView1.Columns[1].HeaderText = "Име";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Националност";
            dataGridView1.Columns[4].HeaderText = "Дата на раждане";
            dataGridView1.Columns[5].HeaderText = "Месторождение";
            dataGridView1.Columns[6].HeaderText = "Дата на смъртта";
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["Authors"].Clear();
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
                    kmt.CommandText = "DELETE from Authors WHERE Barkod_No ='" + silinecek + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["Authors"].Clear();
                    göster1();
                }
            }
            catch
            { ;}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Authors", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from Authors";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "Authors");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From Authors" +
                 " where(AuthorID like '%" + textBox1.Text + "%' OR FirstName like '%" + textBox1.Text + "%' OR LastName like '%" + textBox1.Text + "%')";
            dtst.Tables["Authors"].Clear();
            adtr.Fill(dtst, "Authors");
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
