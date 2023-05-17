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
    public partial class satislistele : Form
    {
        public satislistele()
        {
            InitializeComponent();
        }
        public void fnk_satis_liste()
        {
            string sql = "SELECT satis.s_id as 'Satış No',musteri.m_adsoyad as 'Müşteri',m_firma as 'Firma',urun.u_adi as 'Ürün',satis.s_adet as 'Adet',urun.u_fiyat as 'Fiyat',(urun.u_fiyat*satis.s_adet) as'Tutar'  FROM satis LEFT JOIN musteri ON musteri.m_id=satis.s_musteri LEFT JOIN urun ON urun.u_id=satis.s_urun";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void satislistele_Load(object sender, EventArgs e)
        {
            fnk_satis_liste();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT satis.s_id as 'Satış No',musteri.m_adsoyad as 'Müşteri',musteri.m_firma as 'Firma',urun.u_adi as 'Ürün',satis.s_adet as 'Adet' FROM satis LEFT JOIN musteri ON musteri.m_id=satis.s_musteri LEFT JOIN urun ON urun.u_id=satis.s_urun WHERE m_adsoyad like '%" + textBox1.Text + "%' or u_adi like '%" + textBox1.Text + "%' or m_firma like '%" + textBox1.Text + "%'";
            SqlConnection con = new SqlConnection(Form1.baglanti);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
