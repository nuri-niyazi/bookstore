using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ayca_Kahraman
{
    public partial class Form15 : Form
    {
        public Form3 frm3;
        public Form15()
        {
            InitializeComponent();
        }
        

        private void Form15_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.gorselprogramlama.com");
        }
    }
}
