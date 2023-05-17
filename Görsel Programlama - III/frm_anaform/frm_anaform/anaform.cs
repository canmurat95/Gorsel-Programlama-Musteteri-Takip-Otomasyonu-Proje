using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frm_anaform
{
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }

        private void anaform_Load(object sender, EventArgs e)
        {

        }

        private void kullaniciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_ekle a = new kullanici_ekle();
            a.ShowDialog();
        }

        private void müşteriKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
        musteri_kayit a = new musteri_kayit();
            a.ShowDialog();
        }

        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteri_liste a = new musteri_liste();
            a.ShowDialog();
        }

        private void kullaniciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_liste a = new kullanici_liste();
            a.ShowDialog();
        }

        private void üüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void katagoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katagoriekle a = new katagoriekle();
            a.ShowDialog();
        }

        private void ürünListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void katagoriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katagori_listele a = new katagori_listele();
            a.ShowDialog();
        }

        private void satışListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void katagoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katagoriekle a = new katagoriekle();
            a.ShowDialog();

        }

        private void katagoriListeiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katagori_listele a = new katagori_listele();
            a.ShowDialog();
        }

        private void ürunlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunlerliste a = new urunlerliste();
            a.ShowDialog();

        }

        private void satışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satiskayit a = new satiskayit();
            a.ShowDialog();
        }

        private void satışListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satislistele a = new satislistele();
            a.ShowDialog();

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
