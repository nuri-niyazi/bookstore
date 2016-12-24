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
    public partial class Form10 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form7 frm7;
        public Form10 frm10;
        public Form10()
        {
            InitializeComponent();

        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
   
        public int row = 0;

        public void showList()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Clients", bag);
            adtr.Fill(dtst, "Clients");
            dataGridView1.DataSource = dtst.Tables["Clients"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo2()
        {
            int status;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Snf,Dogm_Yeri from Clients";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            bag.Close();
            oku.Dispose();
        }   

        private void Form10_Load(object sender, EventArgs e)
        {
            showList();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "ЕГН на клиента";
            dataGridView1.Columns[1].HeaderText = "Име";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[5].HeaderText = "GSM номер";
            dataGridView1.Columns[6].HeaderText = "Дата на регистрацията";
            dataGridView1.Columns[7].HeaderText = "Отстъпка ползвана от клиента";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["Clients"].Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
  
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string egn;
            
            try
            {
                int row = 0;
                for (row = 0; row <= dataGridView1.Rows.Count; row++)
                {

                    if (dataGridView1.Rows[row].Cells[0].Selected == true)
                    {
                        break;

                    }
                }
                egn = dataGridView1.Rows[row].Cells[0].Value.ToString();

                DialogResult cevap;
                cevap = MessageBox.Show("Наистина ли искате да изтривате този запис!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from Clients WHERE EGN='" + egn + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["Clients"].Clear();
                    showList();
                }
            }
            catch
            { ;}
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Clients", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from Clients";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "Clients");
            }

            adtr.SelectCommand.CommandText = " Select * From Clients" +
                 " where(EGN like '%" + textBox1.Text + "%' OR FirstName like '%" + textBox1.Text + "%' OR LastName like '%" + textBox1.Text + "%' )";
            dtst.Tables["Clients"].Clear();
            adtr.Fill(dtst, "Clients");
            bag.Close();     
        }

    }
}
