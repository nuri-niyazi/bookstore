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
    public partial class Form8 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form7 frm7;
        public Form9 frm9;
        public Form10 frm10;

        public Form8()
        {
            InitializeComponent();
            
          
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            frm7.combo1();
        }
    }
}
