using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;


namespace Ayca_Kahraman
{
    public partial class Form3 : Form
    {

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        public string Pcommand;
        public bool isOpen;

        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form7 frm7;
        public Form8 frm8;
        public Form9 frm9;
        public Form10 frm10;
        public Form11 frm11;
        public Form12 frm12;
        public Form14 frm14;
        public Form15 frm15;
        string[] söz = { "Savaşlar bize, düşmanlarımızı sevmeyi değil, müttefiklerimizden nefret etmeyi öğretir.W.L. George","Yazılı olmayan kanunların en büyük sorunu sildirmek için başvuracak kimseninin olmamasıdır.Glaser and Way","Çoban uyudu mu kurt emin olur.Mevlana","Başına gelenlerle ilgili başkasını suçla ve hayatına devam et!Alan Woods","Kabalık, zayıf kişinin güç taklididir.Eric Hoffer","Hayalgücü bilgiden daha önemlidir.","Herkes tarafından doğru kabul edilen şeyler büyük olasılıkla yanlıştır.","Oyun bittiğinde Şah ve piyon aynı kutuya girer. ","Tecrübe çok acımasız bir öğretmen; önce sınavı yapıyor, dersi sonra öğretiyor.","Hedefi olmayan gemiye hiçbir rüzgar yardım edemez. Montaigne","Kaptanın ustalığı deniz durgunken anlaşılmaz. Lukianos" };


        
        Random rastgele = new Random();
        int a;


        public Form3()
        {
            InitializeComponent();
            frm4 = new Form4();
            frm5 = new Form5();
            frm6 = new Form6();
            frm7 = new Form7();
            frm8 = new Form8();
            frm9 = new Form9();
            frm10 = new Form10();
            frm11 = new Form11();
            frm12 = new Form12();
            frm14 = new Form14();
            frm15 = new Form15();


            frm4.frm3 = this;
            frm5.frm3 = this;
            frm6.frm3 = this;
            frm7.frm3 = this;
            frm8.frm3 = this;
            frm9.frm3 = this;
            frm10.frm3 = this;
            frm11.frm3 = this;
            frm12.frm3 = this;
            frm14.frm3 = this;
            frm15.frm3 = this;
            
        }

        public void Play(bool loop)
        {
            if (isOpen)
            {
                Pcommand = "play MediaFile";
                if (loop)
                    Pcommand += " REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }   

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Programdan çıkmak istiyormusunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text =DateTime.Now.ToLongTimeString();
            label1.Text = string.Format("{0:dd MMMM yyyy dddd}",DateTime.Now);


            a = rastgele.Next(9);
            label4.Text = söz [a];
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frm4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm7.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm10.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm14.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm15.ShowDialog();
        }

       
    }
}
