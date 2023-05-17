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
    public partial class satiskayit : Form
    {
        public satiskayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int stok = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Stok"].Value);
            int m_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Müşteri No"].Value);
            int u_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Ürün No"].Value);
            int adet = Convert.ToInt32(textBox_adet.Text);
            if (m_id == 0)
            {
                MessageBox.Show("Lütfen Müşteri Seçiniz");
            }
            else if (u_id == 0)
            {
                MessageBox.Show("Lütfen Ürün Seçiniz ");
            }
            else if (stok < adet)
            {
                MessageBox.Show("Stokta Yeterli Ürün Bulunmamaktadır");
            }
            else
            {
                string sql = ("INSERT INTO satis VALUES ('" + m_id + "','" + u_id + "','" + adet + "')");
                SqlConnection con = new SqlConnection(Form1.baglanti);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                stok = stok - adet;
                string yenistok = "UPDATE urun SET u_stok ='" + stok + "' WHERE u_id=" + u_id;
                SqlConnection baglan = new SqlConnection(Form1.baglanti);
                baglan.Open();
                SqlCommand cm = new SqlCommand(yenistok, baglan);
                cm.ExecuteNonQuery();
                cm.Dispose();
                baglan.Close();
                MessageBox.Show("Satış İşlemi Tamamlandı ");
                this.Close();

            }
        }
        public void fnk_musteri()
        {
            string sql = ("SELECT m_id as 'Müşteri No',m_adsoyad as 'Müşteri' FROM musteri");
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public void fnk_urun()
        {
            string sql = ("SELECT u_id as 'Ürün No',u_adi as 'Ürün',u_stok as 'Stok' FROM urun");
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        private void satiskayit_Load(object sender, EventArgs e)
        {
            fnk_musteri();
            fnk_urun();
        }
    }
}
