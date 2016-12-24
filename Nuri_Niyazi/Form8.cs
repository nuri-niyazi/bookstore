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
    public partial class Form8 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form8 frm8;
        public Form7 frm7;
        public Form10 frm10;
        public Form8()
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
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From TakenBooks", bag);
            adtr.Fill(dtst, "TakenBooks");
            dataGridView1.DataSource = dtst.Tables["TakenBooks"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo2()
        {
            int status;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select Snf,Dogm_Yeri from TakenBooks";
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
            dataGridView1.Columns[0].HeaderText = "Име на книга";
            dataGridView1.Columns[1].HeaderText = "Автор";
            dataGridView1.Columns[2].HeaderText = "Дата на взимане";
            dataGridView1.Columns[3].HeaderText = "ЕГН на клиента";
            dataGridView1.Columns[4].HeaderText = "Име";
            dataGridView1.Columns[5].HeaderText = "Фамилия";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtst.Tables["TakenBooks"].Clear();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From TakenBooks", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from TakenBooks";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "TakenBooks");
            }

            adtr.SelectCommand.CommandText = " Select * From TakenBooks" +
                 " where(EGN like '%" + textBox1.Text + "%' OR FirstName like '%" + textBox1.Text + "%' OR LastName like '%" + textBox1.Text + "%'  OR Title like '%" + textBox1.Text + "%'  OR Author like '%" + textBox1.Text + "%' OR DateTaked like '%" + textBox1.Text + "%')";
            dtst.Tables["TakenBooks"].Clear();
            adtr.Fill(dtst, "TakenBooks");
            bag.Close();     
        }
    }
}
