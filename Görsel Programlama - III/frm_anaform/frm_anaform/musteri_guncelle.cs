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
    public partial class musteri_guncelle : Form
    {
        public musteri_guncelle()
        {
            InitializeComponent();
        }
        public int g_m_id;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            string sql = "UPDATE musteri SET musteriAdSoyad='" + textBox1.Text + "',musteriTel='" + textBox2.Text + "',musteriAdres='" + textBox3.Text + "',musteriFirma='" + textBox4.Text + "' WHERE m_id=" + g_m_id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi ! ");
            this.Close();
        }

        private void musteri_guncelle_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM musteri WHERE m_id =" + g_m_id;
            SqlConnection con = new SqlConnection(Form1.baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true)
            {
                textBox1.Text = Convert.ToString(dr["m_adsoyad"]);
                textBox2.Text = Convert.ToString(dr["m_tel"]);
                textBox3.Text = Convert.ToString(dr["m_adres"]);
                textBox4.Text = Convert.ToString(dr["m_firma"]);
            }
            else
            {
                MessageBox.Show("Kayıt Bulunamadı ");
            }

        }
    }
}
