using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frm_anaform
{
    public partial class Form1 : Form
    {
        public static string baglanti = "Data Source=DESKTOP-A782K95\\SQLEXPRESS01;Initial Catalog=gp_2020;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_ad = textBox1.Text;
            string kullanici_sifre = textBox2.Text;
            veritabani_sinifi islemim = new veritabani_sinifi();
            islemim.girisyap(kullanici_ad, kullanici_sifre, this);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
